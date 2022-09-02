namespace LabTest_Test
{
    [TestClass]
    public class MoteurTest
    {
        int taille;
        int nbCylindres;
        int puissanceChevauxVapeur;
        double consommationParKm;

        Moteur moteur;

        [TestInitialize]
        public void Init()
        {
            taille = 1;
            nbCylindres = 2;
            puissanceChevauxVapeur = 3;
            consommationParKm = 4;

            moteur = new Moteur(taille, nbCylindres, puissanceChevauxVapeur, consommationParKm);
        }

        [TestCleanup]
        public void Clean()
        {
            taille = 0;
            nbCylindres = 0;
            puissanceChevauxVapeur = 0;
            consommationParKm = 0;

            moteur = null;
        }

        [TestMethod]
        public void Moteur_ValeurCorrectes_MoteurMemeValeur()
        {
            Assert.AreEqual(taille, moteur.Taille);
            Assert.AreEqual(nbCylindres, moteur.NbCylindres);
            Assert.AreEqual(puissanceChevauxVapeur, moteur.PuissanceChevauxVapeur);
            Assert.AreEqual(consommationParKm, moteur.ConsommationParKm);
        }

        [TestMethod]
        public void DemarrerMoteur_AfficheBien()
        {
            string valeur = "Vrooooom !";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moteur.DemarrerMoteur();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }
    }
}