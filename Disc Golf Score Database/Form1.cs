using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Disc_Golf_Score_Database
{
    public partial class MainForm : Form
    {
        LinkedList<LinkedList<Game>> Database = new LinkedList<LinkedList<Game>>();
        LinkedList<Game> CurrentPointer;
        LinkedList<Game> Current = new LinkedList<Game>();
        private bool TESTRUN;
        private int max;
        private int min;
        Queue<Game> RootGameEdited = new Queue<Game>();

        int Max
        {
            get {return max;}
            set
            {
                if (value == -100)
                    max = -100; 
                if (value > max)
                    max = value;
            }
        }

        int Min
        {
            get { return min; }
            set
            {
                if (value == 100)
                    min = 100;
                if (value < min)
                    min = value;
            }
        }
        
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm loading = new LoadForm("Loading Database");
            loading.Show();
            loading.LoadDatabase();
            TESTRUN = loading.TESTRUN;
            this.Database = loading.Database;
            loading.Close();

            foreach (LinkedList<Game> player in Database)
            {
                NameCombo.Items.Add(player.First.Value.Player);
                foreach (Game game in player)
                    if (!TypeCombo.Items.Contains(game.Type))
                        TypeCombo.Items.Add(game.Type);
            }

            AssignCurrent(Database.First.Value);
            CurrentPointer = Database.First.Value;
            CompHandiCheck.Checked = true;
            TypeCombo.SelectedIndex = TypeCombo.FindString("(Normal)");
            TypeCombo.Text = TypeCombo.SelectedItem.ToString();
            Compute();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game NewGame;
            string Player = NameCombo.Text;
            string Comments = CommentBox.Text;
            DateTime Date = DateInput.Value;
            int Score;
            int Handicap = 0;
            string Type = TypeCombo.Text;

            if (Player == "")
            {
                MessageBox.Show("Who's playing, dufus?");
                return;
            }

            if (Type == "")
            {
                MessageBox.Show("What type of game is it?  That's kinda important, dufus.");
                return;
            }

            try { Score = Convert.ToInt16(ScoreTextBox.Text); }
            catch (FormatException)
            {
                MessageBox.Show("Enter in a real score, dork.", "Error, dork.");
                ScoreTextBox.Text = "";
                return;
            }

            if (HandicapCheck.Checked)
            {
                try { Handicap = Convert.ToInt16(HandicapText.Text); }
                catch (FormatException)
                {
                    MessageBox.Show("Enter in a real handicap, dork.", "Error, dork.");
                    HandicapText.Text = "";
                    return;
                }
            }

            NewGame = new Game(Score, Comments, Player, Date, Handicap, Type);

            if (SimulCheckbox.Checked)
            {
                if (ScoreBox.SelectedItem == null || ScoreBox.SelectedItem.ToString() == "-----Last 20 Games-----")
                {
                    MessageBox.Show("If simultaneous, select the game it's simultaneous with, dork.", "Error, dork.");
                    return;
                }

                string[] Parts = ScoreBox.SelectedItem.ToString().Split('\t');
                if (Parts[0] != NewGame.Date.ToShortDateString())
                {
                    MessageBox.Show("Can't be simultaneous; the games don't have the same date, dork.", "Error, dork.");
                    return;
                }

                foreach (LinkedList<Game> player in Database)
                    if (player.First.Value.Player == PlayerNameLabel.Text)
                    {
                        Game targetgame = new Game(Convert.ToInt16(Parts[1]), Parts[4], PlayerNameLabel.Text, Convert.ToDateTime(Parts[0]), Convert.ToInt32(Parts[2]), Parts[3]);
                        foreach (Game game in player)
                            if (targetgame.SameAs(game))
                            {
                                NewGame.SimultaneousGame = game;
                                break;
                            }
                    }
            }

            AddGame(NewGame, true);
            Save();

            ScoreTextBox.Text = "";
            NameCombo.Text = "";
            CommentBox.Text = "";
            SimulCheckbox.Checked = false;
        }

        private void Save()
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream output;
            string FileName;

            if (TESTRUN)
            {
                foreach (LinkedList<Game> targetlist in Database)
                {
                    FileName = "C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + targetlist.First.Value.Player;
                    output = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                    foreach (Game target in targetlist)
                        binary.Serialize(output, target);
                    output.Close();
                }

                output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\FileList", FileMode.Create, FileAccess.Write);
                foreach (LinkedList<Game> targetlist in Database)
                    binary.Serialize(output, targetlist.First.Value.Player);
                output.Close();
            }
            else
            {

                foreach (LinkedList<Game> targetlist in Database)
                {
                    FileName = "C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + targetlist.First.Value.Player;
                    output = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                    foreach (Game target in targetlist)
                        binary.Serialize(output, target);
                    output.Close();
                }

                output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\FileList", FileMode.Create, FileAccess.Write);
                foreach (LinkedList<Game> targetlist in Database)
                    binary.Serialize(output, targetlist.First.Value.Player);
                output.Close();

            }
        }

        private void AddGame(Game NewGame, bool compute)
        {
            bool NewPlayer = true;
            if (!TypeCombo.Items.Contains(NewGame.Type))
                TypeCombo.Items.Add(NewGame.Type);
            
            foreach (LinkedList<Game> player in Database)
            {
                if (NewGame.Player == player.First.Value.Player)
                {
                    NewPlayer = false;

                    foreach (Game game in player)
                    {
                        if (!game.DateIsBefore(NewGame.Date))
                        {
                            if (NewGame.Simultaneous)
                            {
                                if (NewGame.SimultaneousGame.SameAs(game))
                                {
                                    player.AddAfter(player.Find(game), NewGame);
                                    while (RootGameEdited.Count != 0)
                                        player.Find(RootGameEdited.Dequeue()).Value.SimultaneousGame = player.Find(NewGame).Value;

                                    AssignCurrent(player);
                                    if (compute)
                                        Compute();
                                    return;
                                }
                            }
                            else
                            {
                                player.AddBefore(player.Find(game), NewGame);
                                while (RootGameEdited.Count != 0)
                                    player.Find(RootGameEdited.Dequeue()).Value.SimultaneousGame = player.Find(NewGame).Value;

                                AssignCurrent(player);
                                if (compute)
                                    Compute();
                                return;
                            }
                        }
                    }
                    player.AddLast(NewGame);
                    AssignCurrent(player);
                    if (compute)
                        Compute();
                }
            }
            if (NewPlayer)
            {
                Database.AddLast(new LinkedList<Game>());
                Database.Last.Value.AddLast(NewGame);
                AssignCurrent(Database.Last.Value);
                if (compute)
                    Compute();
                NameCombo.Items.Add(NewGame.Player);
            }
        }

        private void Compute()
        {
            if (Current == null || Current.Count == 0)
                return;

            double OA; double CA; double OV; double CV; int OPS; int CPS; int OBS; int CBS; int OWS; int CWS; double AceAvg;
            OA = CA = OV = CV = AceAvg = 0; CBS = OBS = Min = 100; CWS = OWS = Max = -100; CPS = OPS = Math.Abs(Max - Min);
            int VarianceDiv = 0; int CurrentVarianceDiv = 0;

            Game[] Array1 = new Game[Current.Count];
            Current.CopyTo(Array1, 0);
            
            int CurrentMark = 20;
            while (CurrentMark <= Array1.Length && Array1[Array1.Length - CurrentMark].Simultaneous)
                CurrentMark++;

            int TempScore; int BackScore;
            for(int i = 0; i < Array1.Length; i++)
            {
                TempScore = Array1[i].Score;
                if (!CompHandiCheck.Checked)
                    TempScore = Array1[i].BareScore;
                OA += TempScore;
                if (Array1[i].Comments.Contains("Ace"))
                    AceAvg++;
                if (Array1.Length - i <= CurrentMark)
                    CA += TempScore;

                if (i > 0)
                {
                    if (Current.First.Value.Player == "[Test]")
                        Min = Min; 
                    int j = 0;
                    while (!Array1[j].SameAs(Array1[i].RootGame) && j < i)
                        j++;
                    int backtrack = 0;
                    do
                    {
                        VarianceDiv++; backtrack++;
                        BackScore = Array1[j - backtrack].Score;
                        if (!CompHandiCheck.Checked)
                            BackScore = Array1[j - backtrack].BareScore;
                        OV += Math.Abs(BackScore - TempScore);
                        if (Array1.Length - i <= CurrentMark)
                        {
                            CurrentVarianceDiv++;
                            CV += Math.Abs(BackScore - TempScore);
                        }
                    } while (backtrack < j && Array1[j - backtrack].Simultaneous && Array1[j - 1].RootGame.SameAs(Array1[j - backtrack].RootGame));
                }

                Max = TempScore;
                Min = TempScore;
                OPS = Math.Abs(Max - Min);
                OBS = Min;
                OWS = Max;
            }

            if (Current.First.Value.Player == "[Test]")
                Min = Min; 
            Min = 100; Max = -100;
            int Start;
            if (Array1.Length < CurrentMark)
                Start = 0;
            else
                Start = Array1.Length - CurrentMark;

            for (int i = Start; i < Array1.Length; i++)
            {
                TempScore = Array1[i].Score;
                if (!CompHandiCheck.Checked)
                    TempScore = Array1[i].BareScore;
                Max = TempScore;
                Min = TempScore;
                CPS = Math.Abs(Max - Min);
                CBS = Min;
                CWS = Max;
            }

            OA /= Current.Count;
            AceAvg /= Current.Count;
            if (Current.Count < CurrentMark)
                CA /= Current.Count;
            else
                CA /= CurrentMark;

            OV /= VarianceDiv;
            if (Current.Count < CurrentMark)
                CV /= VarianceDiv;
            else
                CV /= CurrentVarianceDiv;

            PlayerNameLabel.Text = Current.First.Value.Player;
            string output = "\t\tCurrent\tOverall";
            output += String.Format("\n\nAverage\t{0:F1}\t\t{1:F1}", CA, OA);
            output += String.Format("\n\nVariance\t{0:F1}\t\t{1:F1}", CV, OV);
            output += "\n\nOverall";
            output += String.Format("\nPoint Spread\t{0}\t\t{1}", CPS, OPS);
            output += String.Format("\n\nBest Game\t{0}\t\t{1}", CBS, OBS);
            output += String.Format("\n\nWorst Game\t{0}\t\t{1}", CWS, OWS);
            output += String.Format("\n\nTotal Games\t\t{0}", Current.Count);
            output += String.Format("\n\nAce Average\t\t{0:F3}", AceAvg);
            StatBox.Text = output;

            ScoreBox.Items.Clear();
            int setbreak = 0;
            foreach (Game game in Current)
            {
                ScoreBox.Items.Add(game.ToString());
                if (setbreak == Current.Count - CurrentMark - 1)
                    ScoreBox.Items.Add(String.Format("-----Last {0} Games-----", CurrentMark));
                setbreak++;
            }

            MoveLeftButton.Enabled = true;
            MoveRightButton.Enabled = true;
            if (Current.First.Value.Player == Database.First.Value.First.Value.Player)
                MoveLeftButton.Enabled = false;
            else if (Current.First.Value.Player == Database.Last.Value.First.Value.Player)
                MoveRightButton.Enabled = false;
        }

        private void AssignCurrent(LinkedList<Game> Target)
        {
            Current.Clear();
            foreach (Game game in Target)
                Current.AddLast(game);
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            LinkedList<Game>[] Array1 = new LinkedList<Game>[Database.Count];
            Database.CopyTo(Array1, 0);

            for (int i = 1; i < Array1.Length; i++)
                if (Array1[i].First.Value.Player == PlayerNameLabel.Text)
                {
                    CurrentPointer = Array1[i - 1];
                    Current.Clear();
                    
                    foreach (Game game in CurrentPointer)
                        if (game.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()))
                            Current.AddLast(game);
                    
                    if (Current.Count == 0)
                    {
                        AssignCurrent(Array1[i + 1]);
                        SearchTextBox.Text = "";
                    }
                    Compute();
                    return;
                }
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            LinkedList<Game>[] Array1 = new LinkedList<Game>[Database.Count];
            Database.CopyTo(Array1, 0);

            for (int i = Array1.Length - 2; i >= 0; i--)
                if (Array1[i].First.Value.Player == PlayerNameLabel.Text)
                {
                    CurrentPointer = Array1[i + 1];
                    Current.Clear();
                    
                    foreach (Game game in CurrentPointer)
                        if (game.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()))
                            Current.AddLast(game);
                    
                    if (Current.Count == 0)
                    {
                        AssignCurrent(Array1[i + 1]);
                        SearchTextBox.Text = "";
                    }
                    Compute();
                    return;
                }
        }

        private void EditSelected_Click(object sender, EventArgs e)
        {
            if (ScoreBox.SelectedItem == null || ScoreBox.SelectedItem.ToString() == "-----Last 20 Games-----")
            {
                MessageBox.Show("Pick a game to edit, you dolt.");
                return;
            }

            string[] Parts = ScoreBox.SelectedItem.ToString().Split('\t');
            NameCombo.Text = PlayerNameLabel.Text;
            NameCombo.SelectedItem = NameCombo.FindString(PlayerNameLabel.Text);
            ScoreTextBox.Text = Parts[1];
            if (Parts[0].Contains("*"))
                Parts[0] = Parts[0].Remove(Parts[0].IndexOf('*'));
            DateInput.Value = Convert.ToDateTime(Parts[0]);
            CommentBox.Text = Parts[4];
            HandicapText.Text = Parts[2];
            HandicapCheck.Checked = (Parts[2] != "0");
            TypeCombo.Text = Parts[3];
            TypeCombo.SelectedItem = TypeCombo.FindString(Parts[3]);

            int CurrentMark = ScoreBox.Items.Count - ScoreBox.FindString("---") - 1;
            
            Game[] array1;            
            foreach (LinkedList<Game> a in Database)
            {
                if (a.First.Value.Player == NameCombo.Text)
                {
                    array1 = new Game[a.Count];
                    a.CopyTo(array1, 0);
                    if (ScoreBox.SelectedIndex + CurrentMark > ScoreBox.Items.Count - 1 && ScoreBox.Items.Count > CurrentMark)
                    {
                        SimulCheckbox.Checked = array1[ScoreBox.SelectedIndex - 1].Simultaneous;

                        if (SimulCheckbox.Checked)
                        {
                            Game root = array1[ScoreBox.SelectedIndex - 1].RootGame;
                            a.Remove(array1[ScoreBox.SelectedIndex - 1]);
                            ScoreBox.Items.RemoveAt(ScoreBox.SelectedIndex);
                            ScoreBox.SelectedIndex = ScoreBox.FindStringExact(root.ToString());
                        }
                        else
                        {
                            int j = 0;
                            if (ScoreBox.SelectedIndex < array1.Length)
                                while (array1[ScoreBox.SelectedIndex + j].Simultaneous && array1[ScoreBox.SelectedIndex + j].SimultaneousGame.SameAs(array1[ScoreBox.SelectedIndex]))
                                {
                                    RootGameEdited.Enqueue(array1[ScoreBox.SelectedIndex + j]);
                                    j++;
                                }
                            
                            a.Remove(array1[ScoreBox.SelectedIndex - 1]);
                            ScoreBox.Items.RemoveAt(ScoreBox.SelectedIndex);
                        }
                    }
                    else
                    {
                        SimulCheckbox.Checked = array1[ScoreBox.SelectedIndex].Simultaneous;
                        if (SimulCheckbox.Checked)
                        {
                            Game root = array1[ScoreBox.SelectedIndex].RootGame;
                            a.Remove(array1[ScoreBox.SelectedIndex]);
                            ScoreBox.Items.RemoveAt(ScoreBox.SelectedIndex);
                            ScoreBox.SelectedIndex = ScoreBox.FindStringExact(root.ToString());
                        }
                        else
                        {
                            int j = 1;
                            while (array1[ScoreBox.SelectedIndex + j].Simultaneous && array1[ScoreBox.SelectedIndex + j].SimultaneousGame.SameAs(array1[ScoreBox.SelectedIndex]))
                            {
                                RootGameEdited.Enqueue(array1[ScoreBox.SelectedIndex + j]);
                                j++;
                            }
                            
                            a.Remove(array1[ScoreBox.SelectedIndex]);
                            ScoreBox.Items.RemoveAt(ScoreBox.SelectedIndex);
                        }
                    }
                    return;
                }
            }
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            GraphForm graph = new GraphForm();
            LinkedList<LinkedList<Game>> ToGraph = new LinkedList<LinkedList<Game>>();
            DialogResult answer;
            Queue<Game> ToRemove = new Queue<Game>();
            bool current = false; bool search = false;

            foreach (LinkedList<Game> player in Database)
            {
                answer = MessageBox.Show(String.Format("Graph games for {0}?", player.First.Value.Player), String.Format("Graph {0}?", player.First.Value.Player), MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    LinkedList<Game> New = new LinkedList<Game>();
                    foreach (Game game in player)
                    {
                        New.AddLast(new Game(game.Score, game.Comments, game.Player, game.Date, game.Handicap, game.Type));
                        New.Last.Value.SimultaneousGame = game.SimultaneousGame;
                    }
                    ToGraph.AddLast(New);
                }
            }

            answer = MessageBox.Show("Graph only the most current games?", "Only current?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
                current = true;
            answer = MessageBox.Show("Graph only the current search results?", "Search results only?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
                search = true;

            if (current)
            {
                foreach (LinkedList<Game> player in ToGraph)
                {
                    Game[] Player = new Game[player.Count];
                    player.CopyTo(Player, 0);

                    int CurrentMark = 20;
                    while (CurrentMark <= Player.Length && Player[Player.Length - CurrentMark].Simultaneous)
                        CurrentMark++;

                    for (int i = 0; i < Player.Length - CurrentMark; i++)
                        ToRemove.Enqueue(Player[i]);
                }
            }

            if (search)
            {
                foreach (LinkedList<Game> player in ToGraph)
                {
                    foreach (Game game in player)
                        if (!game.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()) && !ToRemove.Contains(game))
                            ToRemove.Enqueue(game);
                }
            }

            while (ToRemove.Count != 0)
            {
                LinkedListNode<LinkedList<Game>> pointer = ToGraph.First;

                while (pointer != null)
                {
                    if (ToRemove.Peek().Player == pointer.Value.First.Value.Player)
                    {
                        pointer.Value.Remove(ToRemove.Dequeue());
                        break;
                    }
                    else
                        pointer = pointer.Next;
                }

                if (pointer == null)
                    MessageBox.Show("Somehow, a game was put in here that doesn't exist.  Weird, huh?");
            }

            graph.PassIn(ToGraph);
            graph.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ScoreBox.SelectedItem == null || ScoreBox.SelectedItem.ToString().Contains("-----Last"))
            {
                MessageBox.Show("Pick a game to delete, you dolt.");
                return;
            }

            string[] Parts = ScoreBox.SelectedItem.ToString().Split('\t');

            string warningmessage;
            if (Parts[2] == "")
                warningmessage = String.Format("Are you sure you wish to delete {0}'s game on {1}, score of {2}?", PlayerNameLabel.Text, Parts[0], Parts[1]);
            else
                warningmessage = String.Format("Are you sure you wish to delete {0}'s game on {1}, score of {2} ({3})?", PlayerNameLabel.Text, Parts[0], Parts[1], Parts[2]);
            DialogResult result = MessageBox.Show(warningmessage, "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Game[] array1;
                array1 = new Game[CurrentPointer.Count];
                CurrentPointer.CopyTo(array1, 0);
                if (ScoreBox.SelectedIndex + 20 > ScoreBox.Items.Count - 1 && ScoreBox.Items.Count > 20)
                    CurrentPointer.Remove(array1[ScoreBox.SelectedIndex - 1]);
                else
                    CurrentPointer.Remove(array1[ScoreBox.SelectedIndex]);
                ScoreBox.Items.RemoveAt(ScoreBox.SelectedIndex);
                AssignCurrent(CurrentPointer);
                if (CurrentPointer.Count == 0)
                {
                    Database.Remove(CurrentPointer);
                    AssignCurrent(Database.First.Value);
                }
                Compute();
                Save();
                return;
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Current.Clear();

            foreach (Game game in CurrentPointer)
                if (game.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()))
                    Current.AddLast(game);

            Compute();
        }

        private void ScoreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScoreBox.SelectedItem == null)
                SimultanText.Text = "(Select a game)";
            else
            {
                string[] Parts = ScoreBox.SelectedItem.ToString().Split('\t');
                if (Parts[0].Contains("*"))
                    Parts[0] = Parts[0].Remove(Parts[0].IndexOf('*'));
                Game TempGame = new Game(Convert.ToInt16(Parts[1]), Parts[4], PlayerNameLabel.Text, Convert.ToDateTime(Parts[0]), Convert.ToInt32(Parts[2]), Parts[3]);
                foreach (LinkedList<Game> player in Database)
                    if (player.First.Value.Player == PlayerNameLabel.Text)
                        foreach (Game game in player)
                            if (game.SameAs(TempGame))
                            {
                                if (!game.Simultaneous)
                                    SimultanText.Text = game.ToString().Replace("\t", " | ");
                                else
                                    SimultanText.Text = game.SimultaneousGame.ToString().Replace("\t", " | ");
                            }
                        
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void HandicapCheck_CheckedChanged(object sender, EventArgs e)
        {
            HandicapText.Enabled = HandicapCheck.Checked;
        }

        private void addPlayerFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream input;
            BinaryFormatter binary = new BinaryFormatter();
            string FileName;

            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            FileName = open.FileName;
            if (FileName == "" || FileName == null)
                return;

            foreach (LinkedList<Game> player in Database)
            {
                if (FileName.EndsWith(player.First.Value.Player))
                {
                    MessageBox.Show("This player is already in the database, and I won't allow you to add or overwrite.");
                    return;
                }
            }

            try { input = new FileStream(FileName, FileMode.Open, FileAccess.Read); }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error: the file you selected doesn't actually exist, you twit.");
                return;
            }

            while (true)
            {
                try
                {
                    Game NewGame = (Game)binary.Deserialize(input);
                    if (NewGame.Type == null)
                        NewGame.Type = "(Normal)";
                    AddGame(NewGame, false);
                }
                catch (SerializationException)
                {
                    break;
                }
            }

            input.Close();
            Compute();
            Save();
        }
    }
}