using System.Linq.Expressions;

namespace LabTest_Test
{
    [TestClass]
    public class MotoTest
    {
        Moteur moteur;
        Roue roue;
        string style;
        int tailleReservoir;
        double distanceParcourue;

        int dureeVieKm;
        int autonomieKm;
        string couleur;
        int anneeDeProduction;
        string marque;
        string modele;

        Moto moto;
        
        [TestInitialize]
        public void Init()
        {
            moteur = new Moteur(1, 2, 3, 4);
            roue = new Roue(1, 2, 3, 4, '5',6,"7");
            style = "1";
            tailleReservoir = 1;
            distanceParcourue = 0;

            dureeVieKm = 2;
            autonomieKm = (int)Math.Floor(tailleReservoir / moteur.ConsommationParKm);
            couleur = "Red";
            anneeDeProduction = 2021;
            marque = "1";
            modele = "1";

            moto = new Moto(dureeVieKm, style, tailleReservoir, moteur, roue, couleur, marque, modele);
        }

        [TestCleanup]
        public void Clean()
        {
            moteur = null;
            roue = null;
            style = null;
            tailleReservoir = 0;
            distanceParcourue = 0;

            dureeVieKm = 0;
            autonomieKm = 0;
            couleur = null;
            anneeDeProduction = 0;
            marque = null;
            modele = null;
        }

        [TestMethod]
        public void Moto_BonneValeurs_MarcheBien()
        {
            Assert.AreEqual(style, moto.Style);
            Assert.AreEqual(tailleReservoir, moto.TailleReservoir);
            Assert.AreEqual(moteur, moto.Moteur);            
            Assert.AreEqual(distanceParcourue, moto.DistanceParcourue);
            Assert.AreEqual(dureeVieKm, moto.DureeVieKm);
            Assert.AreEqual(autonomieKm, moto.AutonomieKm);
            Assert.AreEqual(couleur, moto.Couleur);
            Assert.AreEqual(anneeDeProduction, moto.AnneeDeProduction);
            Assert.AreEqual(marque, moto.Marque);
            Assert.AreEqual(modele, moto.Modele);
        }

        [TestMethod]
        public void Moto_ValideRoue()
        {
            for (int i = 0; i < moto.Roues.Length; i++)
            {
                Assert.AreEqual(moto.Roues[i].Largeur, roue.Largeur);
                Assert.AreEqual(moto.Roues[i].PourcentageHauteur, roue.PourcentageHauteur);
                Assert.AreEqual(moto.Roues[i].DiametreJante, roue.DiametreJante);
                Assert.AreEqual(moto.Roues[i].IndiceCharge, roue.IndiceCharge);
                Assert.AreEqual(moto.Roues[i].IndiceVitesse, roue.IndiceVitesse);
                Assert.AreEqual(moto.Roues[i].Pression, roue.Pression);
                Assert.AreEqual(moto.Roues[i].Type, roue.Type);
            }
        }

        [TestMethod]
        public void Demarrer_CouleurValide_AppelBienDemarrerMoteur()
        {
            string valeur = "Vrooooom !";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Demarrer();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Demarrer_CouleurPasValide_AppelBienDemarrerMoteur()
        {
            {
                string valeur = "Vrooooom !";

                using (var texte = new StringWriter())
                {
                    Console.SetOut(texte);

                    moto.Couleur = "PasBien";
                    moto.Demarrer();

                    var resultat = texte.ToString().Trim();

                    Assert.AreEqual(valeur, resultat);
                }
            }
        }

        [TestMethod]
        public void DiminuerPression_BaissePression()
        {
            moto.DiminuerPression();

            for (int i = 0; i < moto.Roues.Length; i++)
            {
                Assert.AreEqual(roue.Pression - 1, moto.Roues[i].Pression);
            }
        }

        [TestMethod]
        public void AjouterPression_PressionBas_MontePression()
        {
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 20;
            }
            moto.AjouterPression();

            Assert.AreEqual(35, moto.Roues[0].Pression);
        }

        [TestMethod]
        public void AjouterPression_PressionHaut_MemePression()
        {
            int pression = moto.Roues[0].Pression;

            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 26;
            }
            moto.AjouterPression();

            Assert.AreEqual(pression, roue.Pression);
        }

        [TestMethod]
        public void TournerSerrer_AfficheBien()
        {
            string valeur = "Pour faire le tournant serré, vous avez dû incliner la moto.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.TournerSerrer();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void FaireLePlein_PeuPression_AfficheBien()
        {
            string valeur = "Pour faire le tournant serré, vous avez dû incliner la moto.";

            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 1;
                valeur += "\r\nVous avez gonflé le pneu.";
            }

            valeur += "\r\nVous avez fait le plein !";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.FaireLePlein();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void FaireLePlein_PressionNormale_AfficheBien()
        {
            string valeur = "Pour faire le tournant serré, vous avez dû incliner la moto.";

            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 60;
            }

            valeur += "\r\nVous avez fait le plein !";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.FaireLePlein();

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void AjouterUsure_BcpUse_AfficheBien()
        {
            string valeur = $"Votre {moto.GetType().Name} a dépassée sa durée de vie, elle peut vous lâcher à tout moment !";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.AjouterUsure(10);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void AjouterUsure_PeuUse_AfficheRien()
        {
            string valeur = "";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.AjouterUsure(0);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }
        
        [TestMethod]
        public void Rouler_PeuPression_AfficheBien()
        {
            moto.AutonomieKm = 200;
            moto.DureeVieKm = 200;

            string valeur = "Vous avez roulé 5 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 1;
                valeur += "\r\nVous avez gonflé le pneu.";
            }
            valeur += "\r\nVous avez fait le plein !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Rouler_HautPression_AfficheBien()
        {
            moto.AutonomieKm = 200;
            moto.DureeVieKm = 200;

            string valeur = "Vous avez roulé 5 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 200;
            }
            valeur += "\r\nVous avez fait le plein !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Rouler_PeuUsure_AfficheBien()
        {
            moto.AutonomieKm = 200;
            moto.DureeVieKm = 200;

            string valeur = "Vous avez roulé 5 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 200;
            }
            valeur += "\r\nVous avez fait le plein !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Rouler_HautUsure_AfficheBien()
        {
            moto.AutonomieKm = 200;
            moto.DureeVieKm = 1;

            string valeur = "Vous avez roulé 5 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 200;
            }
            valeur += "\r\nVous avez fait le plein !";
            valeur += $"\r\nVotre {moto.GetType().Name} a dépassée sa durée de vie, elle peut vous lâcher à tout moment !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Rouler_BasAutonomie_AfficheBien()
        {
            moto.AutonomieKm = 4;
            moto.DureeVieKm = 200;

            string valeur = "Vous avez roulé 4 km. Vous devez faire le plein avant de continuer le voyage.";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 200;
            }
            valeur += "\r\nVous avez fait le plein !";

            valeur += "\r\nVous avez roulé 1 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            valeur += "\r\nVous avez fait le plein !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }

        [TestMethod]
        public void Rouler_HautAutonomie_AfficheBien()
        {
            moto.AutonomieKm = 200;
            moto.DureeVieKm = 200;

            string valeur = "Vous avez roulé 5 km !";
            valeur += "\r\nPour faire le tournant serré, vous avez dû incliner la moto.";
            foreach (Roue roue in moto.Roues)
            {
                roue.Pression = 200;
            }
            valeur += "\r\nVous avez fait le plein !";
            valeur += "\r\nLe voyage est fini.";

            using (var texte = new StringWriter())
            {
                Console.SetOut(texte);
                moto.Rouler(5);

                var resultat = texte.ToString().Trim();

                Assert.AreEqual(valeur, resultat);
            }
        }
    }
}
