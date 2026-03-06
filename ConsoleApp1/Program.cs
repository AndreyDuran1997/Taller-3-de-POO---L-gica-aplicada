using System;
using Shared;

// Taller de logica - Ejercicio 33
// Multiplicacion de matrices

namespace Ejercicio33
{
    // Clase de apoyo para las matrices
    class Matrix
    {
        // Atributos privados
        private int _rows;
        private int _cols;
        private int[,] _data;

        // Propiedad Rows con get y set
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

        // Propiedad Cols con get y set
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

        // Constructor
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _data = new int[Rows, Cols];
        }

        // Llena la matriz con formula A[i,j] = (i+1) * j
        public void FillAsMatrixA()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    _data[i, j] = (i + 1) * j;
        }

        // Llena la matriz con formula B[i,j] = (j+1) * i
        public void FillAsMatrixB()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    _data[i, j] = (j + 1) * i;
        }

        // Multiplica esta matriz por otra
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

        // Imprime la matriz en consola
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

    // Clase hija - hereda de Exercise
    class ExerciseMatrices : Exercise
    {
        // Constructor llama al padre
        public ExerciseMatrices() : base("EJERCICIO 33 - MULTIPLICACION DE MATRICES") { }

        // Extiende el encabezado del padre
        public override void ShowHeader()
        {
            base.ShowHeader();
            Console.WriteLine("Crea A (m x n) y B (n x p), calcula C = A x B");
        }

        // Implementacion del metodo abstracto
        public override void Run()
        {
            ShowHeader();
            int m = ReadPositiveInt("\nIngrese m (filas de A): ");
            int n = ReadPositiveInt("Ingrese n (columnas A / filas B): ");
            int p = ReadPositiveInt("Ingrese p (columnas de B): ");

            Matrix matrixA = new Matrix(m, n);
            matrixA.FillAsMatrixA();

            Matrix matrixB = new Matrix(n, p);
            matrixB.FillAsMatrixB();

            Matrix matrixC = matrixA.Multiply(matrixB);

            matrixA.Print("A");
            matrixB.Print("B");
            matrixC.Print("C = A x B");
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            ExerciseMatrices ejercicio = new ExerciseMatrices();
            ejercicio.Run();

            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}