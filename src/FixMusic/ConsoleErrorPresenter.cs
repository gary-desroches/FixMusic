using System;

namespace FixMusic
{
    class ConsoleErrorPresenter : IErrorPresenter
    {
        public void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
