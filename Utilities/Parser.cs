using System;

namespace Game
{
    public class Parser
    {
        public int ParseIntFromConsole()
        {
            bool isParsed = false;
            int value = 0;
            while (!isParsed)
            {
                isParsed = Int32.TryParse(Console.ReadLine(), out value);
                isParsed = isParsed && value > 0;
                if (!isParsed)
                {
                    Console.WriteLine("Value should be an integer and greater than 0");
                }
            }
            return value;
        }
    }
}