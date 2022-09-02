using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Test
{
    public class Etudiant
    {
        private string nom;
        private string prenom;
        private List<Note> notes;

        public Etudiant(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            Notes = new List<Note>();
        }

        public void AjouterNote(Note note)
        {
            if(note != null)
            {
                Notes.Add(note);
            }
        }

        public double PointsAccumules()
        {
            double cumul = 0;
            foreach(Note n in Notes)
            {
                cumul += n.Ponderation;
            }

            return cumul;
        }

        public double Moyenne()
        {
            double moyenne = 0;

            foreach (Note n in Notes)
            {
                moyenne += n.ValeurReelle();
            }
            return moyenne;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        internal List<Note> Notes { get => notes; set => notes = value; }
    }
}
