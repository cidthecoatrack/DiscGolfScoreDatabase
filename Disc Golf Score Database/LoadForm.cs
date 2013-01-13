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
    public partial class LoadForm : Form
    {
        public LinkedList<LinkedList<Game>> Database = new LinkedList<LinkedList<Game>>();
        public bool TESTRUN = false;
        
        public LoadForm(string Operation)
        {
            InitializeComponent();
            this.Text = Operation;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void LoadDatabase()
        {
            FileStream input;
            BinaryFormatter binary = new BinaryFormatter();
            LinkedList<string> FileNames = new LinkedList<string>();
            progressBar.Maximum = 0;

            if (TESTRUN)
            {
                MessageBox.Show("LOADING TEST DATA", "Trial run", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\FileList", FileMode.Open, FileAccess.Read); }
                catch (FileNotFoundException)
                {
                    FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\FileList", FileMode.OpenOrCreate, FileAccess.Read);
                    output.Close();
                    input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\FileList", FileMode.Open, FileAccess.Read);
                }

                while (true)
                {
                    try
                    {
                        FileNames.AddLast((string)binary.Deserialize(input));
                        progressBar.Maximum++;
                    }
                    catch (SerializationException)
                    {
                        break;
                    }
                }

                foreach (string File in FileNames)
                {
                    try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.Open, FileAccess.Read); }
                    catch (FileNotFoundException)
                    {
                        FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.OpenOrCreate, FileAccess.Read);
                        output.Close();
                        input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.Open, FileAccess.Read);
                    }

                    while (true)
                    {
                        try
                        {
                            binary.Deserialize(input);
                            progressBar.Maximum++;
                        }
                        catch (SerializationException)
                        {
                            break;
                        }
                    }

                    input.Close();
                }

                progressBar.Value = 0;
                foreach (string File in FileNames)
                {
                    try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.Open, FileAccess.Read); }
                    catch (FileNotFoundException)
                    {
                        FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.OpenOrCreate, FileAccess.Read);
                        output.Close();
                        input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolfTEST\\" + File, FileMode.Open, FileAccess.Read);
                    }

                    while (true)
                    {
                        try
                        {
                            Game NewGame = (Game)binary.Deserialize(input);
                            AddGame(NewGame);
                            progressBar.Value++;
                        }
                        catch (SerializationException)
                        {
                            break;
                        }
                    }

                    input.Close();
                }
            }
            else
            {
                try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\FileList", FileMode.Open, FileAccess.Read); }
                catch (FileNotFoundException)
                {
                    FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\FileList", FileMode.OpenOrCreate, FileAccess.Read);
                    output.Close();
                    input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\FileList", FileMode.Open, FileAccess.Read);
                }

                while (true)
                {
                    try
                    {
                        FileNames.AddLast((string)binary.Deserialize(input));
                        progressBar.Maximum++;
                    }
                    catch (SerializationException)
                    {
                        break;
                    }
                }

                foreach (string File in FileNames)
                {
                    try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.Open, FileAccess.Read); }
                    catch (FileNotFoundException)
                    {
                        FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.OpenOrCreate, FileAccess.Read);
                        output.Close();
                        input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.Open, FileAccess.Read);
                    }

                    while (true)
                    {
                        try
                        {
                            binary.Deserialize(input);
                            progressBar.Maximum++;
                        }
                        catch (SerializationException)
                        {
                            break;
                        }
                    }

                    input.Close();
                }

                progressBar.Value = 0;
                foreach (string File in FileNames)
                {
                    try { input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.Open, FileAccess.Read); }
                    catch (FileNotFoundException)
                    {
                        FileStream output = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.OpenOrCreate, FileAccess.Read);
                        output.Close();
                        input = new FileStream("C:\\Users\\Cid the Coatrack\\Documents\\DiscGolf\\" + File, FileMode.Open, FileAccess.Read);
                    }

                    while (true)
                    {
                        try
                        {
                            Game NewGame = (Game)binary.Deserialize(input);
                            AddGame(NewGame);
                            progressBar.Value++;
                        }
                        catch (SerializationException)
                        {
                            break;
                        }
                    }

                    input.Close();
                }
            }
        }

        private void AddGame(Game NewGame)
        {
            bool NewPlayer = true;

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
                                    return;
                                }
                            }
                            else
                            {
                                player.AddBefore(player.Find(game), NewGame);
                                return;
                            }
                        }
                    }
                    player.AddLast(NewGame);
                }
            }
            if (NewPlayer)
            {
                Database.AddLast(new LinkedList<Game>());
                Database.Last.Value.AddLast(NewGame);
            }
        }
    }
}