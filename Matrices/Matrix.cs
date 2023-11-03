using Matrices.Exceptions;
using Action = Matrices.Models.Action;

namespace Matrices
{
    public class Matrix
    {
        public int rows { get => data.GetLength(0); }
        public int cols { get => data.GetLength(1); }
        public double[,] data { get; set; }
        public int size { get => rows * cols; }
        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public Matrix(double[,] data)
        {
            this.data = data;
        }

        /// <summary>
        /// Return matrix in string format.
        /// </summary>
        /// <returns>Example return:
        /// [ [x11,x12,x13], 
        /// [x21,x22,x23] ]</returns>
        public string GetString()
        {
            string result = "[";
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    double num = this[i, j];

                    // if element is last
                    if (j == this.cols - 1)
                    {
                        if (i != this.rows - 1)
                            result += $"{num}],";
                        else
                            result += $"{num}]";

                        continue;
                    } else if (j == 0) // if element is first
                    {
                        result += $"[{num},";
                        continue;
                    }

                    result += $"{num},";
                }
            }
            return result += "]";
        }

        public static Matrix operator + (Matrix left, Matrix right)
        {
            return left.TakeAction(Action.COMPOUNDING, right);
        }

        public static Matrix operator - (Matrix left, Matrix right)
        {
            return left.TakeAction(Action.SUBTRACTION, right);
        }

        public static Matrix operator * (Matrix left, Matrix right)
        {
            return left.TakeAction(Action.MULTIPLICATION, right);
        }

        public static Matrix operator / (Matrix left, Matrix right)
        {
            return left.TakeAction(Action.DIVISION, right);
        }

        public static bool operator == (Matrix left, Matrix right)
        {
            if (left.rows == right.rows && left.cols == right.cols)
            {
                return true;
            }

            for (int i = 0; i < left.rows; i++)
            {
                for (int j = 0; j < left.cols; j++)
                {
                    if (left[i, j] != right[i, j])
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool operator != (Matrix left, Matrix right)
        {
            return !(left == right);
        }

        public override bool Equals(object mat)
        {
            return mat is Matrix;
        }

        /// <summary>
        /// dont work method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        private Matrix COMPOUND(Matrix mat)
        {
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    matrix[i, j] = mat[i, j] + mat[i, j];
                }
            }
            return new Matrix(matrix);
        }

        private Matrix MULTIPLICATE(Matrix mat)
        {
            int newRows = rows;
            int newCols = mat.cols;

            double[,] matrix = new double[newRows, newCols];

            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < mat.cols; j++)
                    for (int k = 0; k < this.cols; k++)
                        matrix[i, j] += this[i, k] * mat[k, j];

            return new Matrix(matrix);
        }

        private Matrix SUBTRACTE(Matrix mat)
        {
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    matrix[i, j] = this[i, j] - mat[i, j];
                }
            }
            return new Matrix(matrix);
        }

        private Matrix DIVIDE(Matrix mat)
        {
            return this * mat.Inverse();
        }

        /// <summary>
        /// Performs an action with the passed matrix.
        /// </summary>
        /// <param name="act"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        /// <exception cref="MatrixIncorrectSize">Incorrect matrix size to some actions.</exception>
        public Matrix TakeAction(Action act, Matrix mat)
        {
            if (act == Action.SUBTRACTION || act == Action.COMPOUNDING)
            {
                if (this.rows == mat.rows && this.cols == mat.cols)
                    return (act == Action.SUBTRACTION ? SUBTRACTE(mat) : COMPOUND(mat));
                else
                    throw new MatrixIncorrectSize("In order to add or subtract a matrix, they need to be the same size.");
            } else
            {
                if (this.cols == mat.rows)
                    return (act == Action.MULTIPLICATION ? MULTIPLICATE(mat) : DIVIDE(mat));
                else
                    throw new MatrixIncorrectSize($"To {(act == Action.MULTIPLICATION ? "multiply" : "divide")} matrices, it is necessary that whether the columns of a matrix are equal to the rows of another matrix.");
            }
        }
    }
}
