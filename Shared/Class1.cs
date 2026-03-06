using System;

namespace Shared
{
    // Clase de extension para leer datos desde consola
    public class ConsoleExtension
    {
        // Lee un numero entero positivo desde consola
        public static int GetInt(string message)
        {
            int number;
            bool isValid;

            do
            {
                Console.Write(message);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            while (!isValid);

            return number;
        }
    }
}