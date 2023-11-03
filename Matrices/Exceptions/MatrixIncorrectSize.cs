using System;

namespace Matrices.Exceptions
{
    public class MatrixIncorrectSize : Exception
    {
        public MatrixIncorrectSize(string message) : base(message) { }
    }
}
