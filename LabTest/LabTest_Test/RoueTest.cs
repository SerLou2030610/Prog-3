namespace LabTest_Test
{
    [TestClass]
    public class RoueTest
    {
        int largeur;
        int pourcentageHauteur;
        int diametreJante;
        int indiceCharge;
        char indiceVitesse;
        int pression;
        string type;

        Roue roue;


        [TestInitialize]
        public void Init()
        {
            largeur = 1;
            pourcentageHauteur = 2;
            diametreJante = 3;
            indiceCharge = 4;
            indiceVitesse = '5';
            pression = 6;
            type = "7";

            roue = new Roue(largeur, pourcentageHauteur, diametreJante, indiceCharge, indiceVitesse, pression, type);
        }

        [TestCleanup]
        public void Clean()
        {
            largeur = 0;
            pourcentageHauteur = 0;
            diametreJante = 0;
            indiceCharge = 0;
            indiceVitesse = ' ';
            pression = 0;
            type = null;

            roue = null;
        }

        [TestMethod]
        public void Roue_ValeursCorrectes_RoueMemeValeurs()
        {
            Assert.AreEqual(largeur, roue.Largeur);
            Assert.AreEqual(pourcentageHauteur, roue.PourcentageHauteur);
            Assert.AreEqual(diametreJante, roue.DiametreJante);
            Assert.AreEqual(indiceCharge, roue.IndiceCharge);
            Assert.AreEqual(indiceVitesse, roue.IndiceVitesse);
            Assert.AreEqual(pression, roue.Pression);
            Assert.AreEqual(type, roue.Type);
        }

        [TestMethod]
        public void Roue2_Roue_Roue2MemeValeurs()
        {
            Roue roue2 = new Roue(roue);

            Assert.AreEqual(roue.Largeur, roue2.Largeur);
            Assert.AreEqual(roue.PourcentageHauteur, roue2.PourcentageHauteur);
            Assert.AreEqual(roue.DiametreJante, roue2.DiametreJante);
            Assert.AreEqual(roue.IndiceCharge, roue2.IndiceCharge);
            Assert.AreEqual(roue.IndiceVitesse, roue2.IndiceVitesse);
            Assert.AreEqual(roue.Pression, roue2.Pression);
            Assert.AreEqual(roue.Type, roue2.Type);
        }

        [TestMethod]
        public void GonflerPneu_AjoutPression_ChangeRouePression()
        {
            int ajoutPression = 8;
            roue.GonflerPneu(ajoutPression);

            Assert.AreEqual(pression + ajoutPression, roue.Pression);
        }

        [TestMethod]
        public void GonflerPneu_AfficheBien()
        {
            string valeur = "Vous avez gonflé le pneu.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                roue.GonflerPneu(0);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }
    }
}