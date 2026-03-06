using System;
using Shared;

namespace Exercises33
{
    // inherits Exercise from Shared
    class ExerciseMatrices : Exercise
    {
        // Builder father
        public ExerciseMatrices() : base("EJERCICIO 33 - MULTIPLICACION DE MATRICES") { }

        // override header
        public override void ShowHeader()
        {
            base.ShowHeader();
            Console.WriteLine("Crea A (m x n) y B (n x p), calcula C = A x B");
        }

        // abstract method implementation
        public override void Run()
        {
            ShowHeader();
            int m = ConsoleExtension.GetInt("\nIngrese m (filas de A): ");
            int n = ConsoleExtension.GetInt("Ingrese n (columnas A / filas B): ");
            int p = ConsoleExtension.GetInt("Ingrese p (columnas de B): ");

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

    // Main program
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