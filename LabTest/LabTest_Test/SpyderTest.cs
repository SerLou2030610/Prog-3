using LabTest;

namespace LabTest_Test
{
    [TestClass]
    public class SpyderTest
    {
        Spyder spyder;
        Moteur moteur;
        Roue roue;
        string style;
        int tailleReservoir;
        int distanceParcourue;
        int dureeVieKm;
        int autonomieKm;
        string couleur;
        int anneeDeProduction;
        string marque;
        string modele;

        [TestInitialize]
        public void Init()
        {
            moteur = new Moteur(1, 2, 3, 4);
            roue = new Roue(1, 2, 3, 4, '5', 6, "7");
            style = "Spyder";
            tailleReservoir = 1;
            distanceParcourue = 0;
            dureeVieKm = 2;
            autonomieKm = (int)Math.Floor(tailleReservoir / moteur.ConsommationParKm);
            couleur = "Red";
            anneeDeProduction = 2020;
            marque = "3";
            modele = "4";
            spyder = new Spyder(dureeVieKm, tailleReservoir, moteur, roue, couleur, marque, modele);
        }

        [TestCleanup]
        public void Clean()
        {
            style = null;
            tailleReservoir = 0;
            distanceParcourue = 0;
            dureeVieKm = 0;
            autonomieKm = 0;
            couleur = null;
            anneeDeProduction = 0;
            marque = null;
            modele = null;
            moteur = null;
            roue = null;
            spyder = null;
        }

        [TestMethod]
        public void Spyder_BonneValeur_MarcheBien()
        {
            Assert.AreEqual(style, spyder.Style);
            Assert.AreEqual(tailleReservoir, spyder.TailleReservoir);
            Assert.AreEqual(moteur, spyder.Moteur);
            //Assert.AreEqual(roue, spyder.Roues[0]);
            Assert.AreEqual(distanceParcourue, spyder.DistanceParcourue);
            Assert.AreEqual(dureeVieKm, spyder.DureeVieKm);
            Assert.AreEqual(autonomieKm, spyder.AutonomieKm);
            Assert.AreEqual(couleur, spyder.Couleur);
            Assert.AreEqual(anneeDeProduction, spyder.AnneeDeProduction);
            Assert.AreEqual(marque, spyder.Marque);
            Assert.AreEqual(modele, spyder.Modele);
        }

        [TestMethod]
        public void TournerSerrer_AfficheBien()
        {
            string valeur = "Pour faire le tournant serré, vous avez simplement tourné la direction de la Spyder.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                spyder.TournerSerrer();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }


    }
}