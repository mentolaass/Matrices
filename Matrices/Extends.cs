using Matrices.Exceptions;
using System;

namespace Matrices
{
    public static class Extends
    {
        /// <summary>
        /// Get transpose matrix.
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static Matrix Transport(this Matrix mat)
        {
            double[,] matrix = new double[mat.cols, mat.rows];
            for (int i = 0; i < mat.rows; i++)
            {
                for (int j = 0; j < mat.cols; j++)
                {
                    matrix[i, j] = mat[j, i];
                }
            }
            return new Matrix(matrix);
        }

        /// <summary>
        /// Obtain the minor of ther matrix by params.
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="MatrixIncorrectSize"></exception>
        public static Matrix GetMinor(this Matrix mat, int x, int y)
        {
            double[,] minor = new double[mat.rows - 1, mat.cols - 1];
            try
            {
                int xtemp = 0, ytemp = 0;
                for (int i = 0; i < mat.cols; i++)
                {
                    if (x != i)
                    {
                        ytemp = 0;
                        for (int j = 0; j < mat.cols; j++)
                        {
                            if (y != j)
                                minor[xtemp, ytemp++] = mat[i, j];
                        }
                        xtemp++;
                    }
                }
                return new Matrix(minor);
            }
            catch { throw new MatrixIncorrectSize("The parameters for finding the minor are wrong."); }
        }

        /// <summary>
        /// Obtain the determinant of the matrix.
        /// </summary>
        /// <param name="mat"></param>
        /// <returns>Determinant</returns>
        public static int GetDeterminant(this Matrix mat)
        {
            if (mat.cols == 1)
                return (int)mat[0, 0];

            double determinant = 0;

            for (int i = 0; i < mat.cols; i++)
            {
                determinant += Math.Pow(-1, i) * mat[0, i] * mat.GetMinor(0, i).GetDeterminant();
            }

            return (int)determinant;
        }

        /// <summary>
        /// Obtain the alg cmp of the matrix.
        /// </summary>
        /// <param name="mat"></param>
        /// <returns>Algebraic Complement</returns>
        public static Matrix GetAlgebraicComplement(this Matrix mat)
        {
            double[,] matrix = new double[mat.rows, mat.cols];
            double determinant = mat.GetDeterminant() > 0 ? -1 : 1;

            for (int j = 0; j < mat.rows; j++)
            {
                for (int i = 0; i < mat.rows; i++)
                {
                    Matrix minor = mat.GetMinor(j, i);
                    matrix[j, i] = (i + j) % 2 == 0 ? -determinant * minor.GetDeterminant() : determinant * minor.GetDeterminant();
                }
            }
                
            return new Matrix(matrix);
        }

        /// <summary>
        /// (matrix)^-1
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Matrix Inverse(this Matrix mat)
        {
            if (mat.cols != mat.rows)
                throw new ArgumentException("Inversed matrix is exists only: quadratic, unexpressed.");

            Matrix tMat = mat.Transport();
            int determinant = tMat.GetDeterminant();

            if (determinant == 0)
                throw new ArgumentException("Determinant matrix is 0 - inversed matrix is not exists.");

            tMat = tMat.GetAlgebraicComplement();
            double[,] matrix = new double[tMat.rows, tMat.cols];

            for (int i = 0; i < tMat.rows; i++)
                for (int j = 0; j < tMat.cols; j++)
                    matrix[i, j] += (1.0 / (double)determinant) * tMat[i, j];

            return new Matrix(matrix);
        }
    }
}
