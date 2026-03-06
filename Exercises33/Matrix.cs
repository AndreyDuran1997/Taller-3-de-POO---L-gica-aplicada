using System;
using Shared;

namespace Exercises33
{
    // Matrix support class
    class Matrix
    {
        // private attributes
        private int _rows;
        private int _cols;
        private int[,] _data;

        // get and set Rows
        public int Rows
        {
            get { return _rows; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las filas deben ser mayores que 0.");
                _rows = value;
            }
        }

        // get and set Cols
        public int Cols
        {
            get { return _cols; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las columnas deben ser mayores que 0.");
                _cols = value;
            }
        }

        // Builder
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _data = new int[Rows, Cols];
        }

        // Fill matrix A[i,j] = (i+1) * j
        public void FillAsMatrixA()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    _data[i, j] = (i + 1) * j;
        }

        // Fill matrix B[i,j] = (j+1) * i
        public void FillAsMatrixB()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    _data[i, j] = (j + 1) * i;
        }

        // Multiply this matrix by another
        public Matrix Multiply(Matrix other)
        {
            if (this.Cols != other.Rows)
                throw new InvalidOperationException("Dimensiones incompatibles.");

            Matrix result = new Matrix(this.Rows, other.Cols);
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < other.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < this.Cols; k++)
                        sum += this._data[i, k] * other._data[k, j];
                    result._data[i, j] = sum;
                }
            return result;
        }

        // Print matrix in console
        public void Print(string name)
        {
            Console.WriteLine("\nMatriz " + name + " [" + Rows + " x " + Cols + "]");
            for (int i = 0; i < Rows; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < Cols; j++)
                    Console.Write(_data[i, j] + " ");
                Console.WriteLine("]");
            }
        }
    }
}