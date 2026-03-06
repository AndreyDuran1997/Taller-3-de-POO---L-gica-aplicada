using System;
using Shared;

namespace Exercises32
{
    // Rhombus support class
    class Diamond
    {
        // private attribute
        private int _size;

        // get and set
        public int Size
        {
            get { return _size; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("greater than 0.");
                _size = value;
            }
        }

        // Builder
        public Diamond(int size)
        {
            Size = size;
        }

        // Print diamond row
        private void PrintRow(int spaces, int symbols)
        {
            Console.Write(new string(' ', spaces));
            Console.WriteLine(new string('#', symbols));
        }

        // upper half
        private void DrawUpperHalf()
        {
            for (int i = 1; i <= Size; i++)
                PrintRow(Size - i, 2 * i - 1);
        }

        // lower half
        private void DrawLowerHalf()
        {
            for (int i = Size - 1; i >= 1; i--)
                PrintRow(Size - i, 2 * i - 1);
        }

        // complete rhombus
        public void Draw()
        {
            Console.WriteLine("\nRombo de tamano " + Size + ":\n");
            DrawUpperHalf();
            DrawLowerHalf();
            Console.WriteLine();
        }
    }
}