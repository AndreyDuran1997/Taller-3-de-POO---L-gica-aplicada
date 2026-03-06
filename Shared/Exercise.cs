using System;

namespace Shared
{
    // Abstract base class
    public abstract class Exercise
    {
        // private attribute
        private string _title = string.Empty;

        // get and set
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The title is empty.");
                _title = value;
            }
        }

        // Builder
        public Exercise(string title)
        {
            Title = title;
        }

        // Sample header
        public virtual void ShowHeader()
        {
            Console.WriteLine("\n*** " + Title + " ***");
        }

        // Abstract child method
        public abstract void Run();
    }
}