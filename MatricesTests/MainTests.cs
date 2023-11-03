using Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatricesTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void TestDeterminantMatrice()
        {
            Matrix matrix1 = new Matrix(new double[,] 
            { 
                {95, 9, 9},
                {4, 91 , 30},
                {30, 5, 4},
            }); // solve 3896

            Matrix matrix2 = new Matrix(new double[,]
            {
                {4,1,-3,8,1},
                {6,5,1,-3,9},
                {6,8,3,8,7},
                {2,9,-8,1,2},
                {-9,-9,8,-5,-6},
            }); // solve 10822

            Matrix matrix3 = new Matrix(new double[,]
            {
                {9, 1},
                {4, 9},
            }); // solve 77

            Matrix matrix4 = new Matrix(new double[,]
            {
                {4, 4, -5, 6},
                {10, 4, 7, 4},
                {-2, -8, 3, 3},
                {-5, -8, -8, -1},
            }); // solve -4320

            Matrix matrix5 = new Matrix(new double[,]
            {
                {4, -4, 1},
                {-4, 2 , 1},
                {4, 1, 4},
            }); // solve -64

            Assert.IsTrue(matrix1.GetDeterminant() == 3896);
            Assert.IsTrue(matrix2.GetDeterminant() == 10822);
            Assert.IsTrue(matrix3.GetDeterminant() == 77);
            Assert.IsTrue(matrix4.GetDeterminant() == -4320);
            Assert.IsTrue(matrix5.GetDeterminant() == -64);
        }

        [TestMethod]
        public void TestInverseMatrice()
        {
            Matrix mt1 = new Matrix(new double[,] { { 3, 4 }, { 5, 7 } }).Inverse();
            Matrix mt2 = new Matrix(new double[,] { { 2, 5, 7 }, { 6, 3, 4 }, { 5, -2, -3 } }).Inverse();

            Assert.IsTrue(mt1 == new Matrix(new double[,] { { 7, -4 }, { -5, 3 } }));
            Assert.IsTrue(mt2 == new Matrix(new double[,] { { 1, -1, 1 }, { -38, 41, 34 }, { 27, -29, 24 } }));
        }

        [TestMethod]
        public void TestOperationsMatrices()
        {
            Matrix mt1 = new Matrix(new double[,] { { 3, 4, 4 }, { 5, 7, 1 }, { 4, 2, 3 } }).Inverse();
            Matrix mt2 = new Matrix(new double[,] { { 2, 5, 7 }, { 6, 3, 4 }, { 5, -2, -3 } }).Inverse();

            Assert.IsTrue(mt1 + mt2 == new Matrix(new double[,] { { 5, 9, 11 }, { 11, 10, 5 }, { 9, 0, 1 } }));
            Assert.IsTrue(mt1 - mt2 == new Matrix(new double[,] { { 1, -1, -3 }, { -1, 4, -3 }, { -1, 4, 5 } }));
            Assert.IsTrue(mt1 * mt2 == new Matrix(new double[,] { { 50, 19, 29 }, { 57, 44, 61 }, { 35, 20, 30 } }));
        }

        /// <summary>
        /// special fail to work output
        /// </summary>
        [TestMethod]
        public void OutputStringMatrix()
        {
            Matrix matrix1 = new Matrix(new double[,]
            {
                {95, 9, 9},
                {4, 91 , 30},
                {30, 5, 4},
            }); // solve 3896

            Matrix matrix2 = new Matrix(new double[,]
            {
                {4,1,-3,8,1},
                {6,5,1,-3,9},
                {6,8,3,8,7},
            });

            Matrix matrix3 = new Matrix(new double[,]
            {
                {9, 1},
                {4, 9},
            });

            Matrix matrix4 = new Matrix(new double[,]
            {
                {4, 4, -5, 6},
                {10, 4, 7, 4},
                {-2, -8, 3, 3},
                {-5, -8, -8, -1},
            });

            Matrix matrix5 = new Matrix(new double[,]
            {
                {4, -4, 1},
                {-4, 2 , 1},
                {4, 1, 4},
            });


            Matrix matrix6 = new Matrix(new double[,]
            {
                {4, -4},
                {-4, 2},
                {4, 1},
            });

            Matrix matrix7 = new Matrix(new double[,]
            {
                {4, -4, -4 ,5 ,1 ,2 ,4},
            });

            Console.WriteLine(matrix1.GetString());
            Console.WriteLine(matrix2.GetString());
            Console.WriteLine(matrix3.GetString());
            Console.WriteLine(matrix4.GetString());
            Console.WriteLine(matrix5.GetString());
            Console.WriteLine(matrix6.GetString());
            Console.WriteLine(matrix7.GetString());
            Console.WriteLine(matrix1.GetString());
            Console.WriteLine(matrix1.GetString());

            Assert.Fail();
        }
    }
}
