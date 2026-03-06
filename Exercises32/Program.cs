using System;
using Shared;

namespace Exercises32
{
    // inherits Exercise from Shared
    class ExerciseDiamond : Exercise
    {
        // Builder father
        public ExerciseDiamond() : base("EJERCICIO 32 - ROMBO") { }

        // override header
        public override void ShowHeader()
        {
            base.ShowHeader();
            Console.WriteLine("Dibuja un rombo con el simbolo #");
        }

        // abstract method implementation
        public override void Run()
        {
            ShowHeader();
            int size = ConsoleExtension.GetInt("\nIngrese el tamano del rombo: ");
            Diamond diamond = new Diamond(size);
            diamond.Draw();
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            ExerciseDiamond ejercicio = new ExerciseDiamond();
            ejercicio.Run();

            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}