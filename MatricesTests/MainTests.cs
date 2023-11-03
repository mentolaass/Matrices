using Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatricesTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void TestDeterminantMatrice()
        {
            Matrix mt1 = new Matrix(new double[,] { { 11, -2 }, { 7, 5 } });
            Matrix mt2 = new Matrix(new double[,] { { 3, 3, -1 }, { 4, 1, 3 }, { 1, -2, -2 } });
            Matrix mt3 = new Matrix(new double[,] { { -2, 1, 3, 2 }, { 3, 0, -1, 2 }, { -5, 2, 3, 0 }, { 4, -1, 2, -3 } });

            int dmt1 = mt1.GetDeterminant();
            int dmt2 = mt2.GetDeterminant();
            int dmt3 = mt3.GetDeterminant();

            Assert.AreEqual(dmt1, 69);
            Assert.AreEqual(dmt2, 54);
            Assert.AreEqual(dmt3, -80);
        }

        [TestMethod]
        public void TestInverseMatrice()
        {
            Matrix mt1 = new Matrix(new double[,] { { 3, 4 }, { 5, 7 } }).Inverse();
            Matrix mt2 = new Matrix(new double[,] { { 2, 5, 7 }, { 6, 3, 4 }, { 5, -2, -3 } }).Inverse();

            Assert.AreEqual(mt1, new Matrix(new double[,] { { 7, -4 }, { -5, 3 } }));
            Assert.AreEqual(mt2, new Matrix(new double[,] { { 1, -1, 1 }, { -38, 41, 34 }, { 27, -29, 24 } }));
        }

        [TestMethod]
        public void TestOperationsMatrices()
        {
            Matrix mt1 = new Matrix(new double[,] { { 3, 4, 4 }, { 5, 7, 1 }, { 4, 2, 3 } }).Inverse();
            Matrix mt2 = new Matrix(new double[,] { { 2, 5, 7 }, { 6, 3, 4 }, { 5, -2, -3 } }).Inverse();

            Assert.AreEqual(mt1 + mt2, new Matrix(new double[,] { { 5, 9, 11 }, { 11, 10, 5 }, { 9, 0, 1 } }));
            Assert.AreEqual(mt1 - mt2, new Matrix(new double[,] { { 1, -1, -3 }, { -1, 4, -3 }, { -1, 4, 5 } }));
            Assert.AreEqual(mt1 * mt2, new Matrix(new double[,] { { 50, 19, 29 }, { 57, 44, 61 }, { 35, 20, 30 } }));
        }
    }
}
