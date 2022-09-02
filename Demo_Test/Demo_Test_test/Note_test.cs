using Demo_Test;

namespace Demo_Test_test
{
    [TestClass]
    public class Note_test
    {
        double ponderation;
        double score;
        Note n;

        [TestInitialize]
        public void Init()
        {
            ponderation = 2;
            score = 3;
            n = new Note(ponderation, score);
        }

        [TestCleanup]
        public void Clean()
        {
            ponderation = 0;
            score = 0;
            n = null;
        }

        [TestMethod]
        public void Note_valeursCorrectes_NoteMemeValeur()
        {
            Assert.AreEqual<double>(ponderation, n.Ponderation);
            Assert.AreEqual<double>(score, n.Score);
        }

        [TestMethod]
        public void ValeurReelle_ValeurCorrecte_ScoreFoixPonderation()
        {
            double valeurReelle = score * ponderation;

            Assert.AreEqual<double>(n.ValeurReelle(), valeurReelle);
        }
    }
}