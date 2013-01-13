using System;
using System.Collections.Generic;
using System.Text;

namespace Disc_Golf_Score_Database
{
    [Serializable]
    public class Game
    {
        public int Score;
        public string Comments;
        public string Player;
        public DateTime Date;
        public Game SimultaneousGame;
        public int Handicap;
        public string Type;

        public int BareScore
        {
            get { return Score + Handicap; }
        }
        
        public Game(int Score, string Comments, string Player, DateTime Date, int Handicap, string Type)
        {
            this.Score = Score;
            this.Comments = Comments;
            this.Player = Player;
            this.Date = Date;
            this.Handicap = Handicap;
            this.Type = Type;
        }

        public bool Simultaneous
        {
            get { return SimultaneousGame != null; }
        }

        public Game RootGame
        {
            get { return FindRootGame(SimultaneousGame); }
        }

        private Game FindRootGame(Game start)
        {
            if (start == null)
                return null;
            else if (start.Simultaneous)
                return FindRootGame(start.SimultaneousGame);
            else
                return start;
        }

        public bool SameAs(Game Compare)
        {
            if (Compare == null)
                return false;
            if (Player == Compare.Player)
                if (Date.ToShortDateString() == Compare.Date.ToShortDateString())
                    if (Type == Compare.Type)
                        if (Handicap == Compare.Handicap)
                            if (Score == Compare.Score)
                                if (Comments == Compare.Comments)
                                    return true;
            return false;
        }

        public bool DateIsBefore(DateTime CompareDate)
        {
            if (CompareDate.Year < Date.Year)
                return false;
            if (CompareDate.Year == Date.Year && CompareDate.Month < Date.Month)
                return false;
            if (CompareDate.Year == Date.Year && CompareDate.Month == Date.Month && CompareDate.Day <= Date.Day)
                return false;
            return true;
        }

        public override string ToString()
        {
            string simul = "";
            if (Simultaneous)
                simul = "*";
            string output = String.Format("{0}", Date.ToShortDateString());
            if (output == "1/1/1753")
                output = "Pre-dating";
            output += String.Format("{0}\t{1}\t{2}\t{3}\t{4}", simul, Score, Handicap, Type, Comments);
            return output;
        }
    }
}
