using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Test
{
    public class Note
    {
        private double score;
        private double ponderation;

        public Note(double ponderation, double score)
        {
            Ponderation = ponderation;
            Score = score;
        }

        public double ValeurReelle()
        {
            return Score * ponderation;
        }

        public double Ponderation { get => ponderation; set => ponderation = value; }
        public double Score { get => score; set => score = value; }
    }
}
