using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Disc_Golf_Score_Database
{
    public partial class GraphForm : Form
    {
        LinkedList<LinkedList<Game>> Players = new LinkedList<LinkedList<Game>>();
        private int max; private int min; private int ysplit; private int DayCount = 0;
        LinkedList<string> Dates = new LinkedList<string>();
        LinkedList<Color> Colors = new LinkedList<Color>();
        public string GraphType;
        public bool Outliers;
        public bool ByDate;
        public bool Handicap;

        int YSplit
        {
            get { return ysplit; }
            set
            {
                while (value > 10 || value < 4)
                {
                    if (value > 10)
                        value /= 2;
                    if (value < 4)
                        value += 2;
                }
                if (YDivide < value)
                    ysplit = YDivide;
                else
                    ysplit = YDivide / value;
            }
        }

        int YDivide
        {
            get { return Math.Abs(Max - Min) + 1; }
        }
        
        int Max
        {
            get { return max; }
            set
            {
                if (value > max)
                    max = value;
            }
        }

        int Min
        {
            get { return min; }
            set
            {
                if (value < min)
                    min = value;
            }
        }

        public GraphForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void PassIn(LinkedList<LinkedList<Game>> Players)
        {
            foreach(LinkedList<Game> player in Players)
            {
                if (player.Count > 1)
                {
                    LinkedList<Game> New = new LinkedList<Game>();
                    foreach (Game game in player)
                    {
                        Max = game.Score; Min = game.Score;
                        AddDate(game.Date);
                        New.AddLast(new Game(game.Score, game.Comments, game.Player, game.Date, game.Handicap, game.Type));
                        New.Last.Value.SimultaneousGame = game.SimultaneousGame;
                    }
                    this.Players.AddLast(New);
                }
            }
            
            YSplit = YDivide;

            TimeSpan answer = Convert.ToDateTime(Dates.Last.Value) - Convert.ToDateTime(Dates.First.Value);
            DayCount = answer.Days + 5;

            Random rnd = new Random();
            for (int i = 0; i < this.Players.Count; i++)
                Colors.AddLast(Color.FromArgb((rnd.Next(0, 255)), (rnd.Next(0, 255)), (rnd.Next(0, 255))));
        }

        private void XAxisPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font arial = new Font("Arial", 10, FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.DirectionVertical);

            string date; int xprev = -15; int x; string prevdate = "";
            string[] dates = new string[Dates.Count];
            Dates.CopyTo(dates, 0);

            for (int CountIndex = 0; CountIndex < dates.Length; CountIndex++)
            {
                string[] split = dates[CountIndex].Split('/');
                date = split[0] + '/' + split[2];

                if (date != prevdate)
                {
                    prevdate = date;

                    x = (NumberofDays(dates[CountIndex]) + 1) * GraphPanel.Width / (DayCount + 1) - 9;
                    if (x < xprev + 15)
                        x = xprev + 15;

                    g.DrawString(date, arial, Brushes.Chocolate, x, 0, format);
                    xprev = x;
                }
            }
        }

        private void YAxisPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font arial = new Font("Arial", 10, FontStyle.Bold);

            for (int i = Min; i <= Max; i += YSplit)
                g.DrawString(i.ToString(), arial, Brushes.Chocolate, 0, GraphPanel.Height - 10 - (i + Math.Abs(Min)) * GraphPanel.Height / YDivide);
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x; int y;

            for (int i = Min; i <= Max; i += YSplit)
            {
                y = GraphPanel.Height - 2 - (i + Math.Abs(Min)) * GraphPanel.Height / YDivide;
                g.DrawLine(Pens.LightBlue, 0, y, GraphPanel.Width, y);
            }

            g.DrawLine(Pens.Black, 0, GraphPanel.Height, 0, 0);
            g.DrawLine(Pens.Black, 0, GraphPanel.Height - 2 - GraphPanel.Height * Math.Abs(Min) / YDivide, GraphPanel.Width, GraphPanel.Height - 2 - GraphPanel.Height * Math.Abs(Min) / YDivide);

            string[] dates = new string[Dates.Count];
            Dates.CopyTo(dates, 0);

            Color[] colors = new Color[Colors.Count];
            Colors.CopyTo(colors, 0);
            LinkedList<Game>[] player = new LinkedList<Game>[Players.Count];
            Players.CopyTo(player, 0);
            for (int BIG = 0; BIG < player.Length; BIG++)
            {
                Point[] graphdata = new Point[player[BIG].Count];
                Game[] arrayplayer = new Game[player[BIG].Count];
                player[BIG].CopyTo(arrayplayer, 0);
                Pen pen = new Pen(colors[BIG]);

                for (int i = 0; i < arrayplayer.Length; i++)
                {
                    for (int CountIndex = 0; CountIndex < dates.Length; CountIndex++)
                    {
                        if (arrayplayer[i].Date.ToShortDateString() == dates[CountIndex])
                        {
                            x = Convert.ToInt32(((NumberofDays(dates[CountIndex])) * GraphPanel.Width + 5)/ (DayCount + 1));
                            y = Convert.ToInt32(GraphPanel.Height - GraphPanel.Height * (arrayplayer[i].Score + Math.Abs(Min)) / YDivide) - 2;

                            graphdata[i] = new Point(x, y);

                            if (i > 0)
                            {
                                int j = i;
                                while (arrayplayer[i].Simultaneous && !arrayplayer[j].SameAs(arrayplayer[i].SimultaneousGame))
                                    j--;
                                j--;
                                int stop = j;
                                do
                                {
                                    g.DrawLine(pen, graphdata[j], graphdata[i]);
                                    j--;
                                    if (j < 0)
                                        break;
                                } while (arrayplayer[stop].Simultaneous && !arrayplayer[j].SameAs(arrayplayer[stop].SimultaneousGame));
                                if (arrayplayer[stop].Simultaneous && arrayplayer[j].SameAs(arrayplayer[stop].SimultaneousGame))
                                    g.DrawLine(pen, graphdata[j], graphdata[i]);
                            }
                        }
                    }
                    foreach (Point point in graphdata)
                        g.FillRectangle(Brushes.DarkSlateBlue, point.X - 1, point.Y - 1, 3, 3);
                }
            }
        }

        private void AddDate(DateTime NewDate)
        {
            if (!Dates.Contains(NewDate.ToShortDateString()))
            {
                foreach (string Date in Dates)
                {
                    DateTime ToCompare = Convert.ToDateTime(Date);

                    if (NewDate.CompareTo(ToCompare) < 0)
                    {
                        Dates.AddBefore(Dates.Find(Date), NewDate.ToShortDateString());
                        return;
                    }
                }
                Dates.AddLast(NewDate.ToShortDateString());
            }
        }

        private void LegendPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int i = 0; Font arial = new Font("Times New Roman", 10, FontStyle.Regular);
            Color[] colors = new Color[Colors.Count];
            Colors.CopyTo(colors, 0);
            LinkedList<Game>[] player = new LinkedList<Game>[Players.Count];
            Players.CopyTo(player, 0);
            for (int BIG = 0; BIG < player.Length; BIG++)
            {
                i++;
                Brush brush = new SolidBrush(colors[BIG]);
                g.DrawString(player[BIG].First.Value.Player, arial, brush, 0, i * LegendPanel.Height / (Players.Count + 1));
            }

        }

        private int NumberofDays(string date)
        {
            TimeSpan answer = Convert.ToDateTime(date) - Convert.ToDateTime(Dates.First.Value);

            return answer.Days;
        }
    }
}