using System;
using System.Collections.Generic;
using System.Threading;

namespace TextBasedGameApi.Utilities.ConsoleUtils
{
    public static class ConsoleOutputUtils
    {
        public static void slowWrite(string value, int msPolling = 100, int charPollingFraction = 2, bool endWithNewLine = false)
        {
            foreach (string word in value?.Split(' '))
            {
                Thread.Sleep(msPolling);
                if (Console.CursorLeft + word.Length > Console.WindowWidth-2)
                    Console.WriteLine();

                foreach (char c in word)
                {
                    Console.Write(c);
                    Thread.Sleep(msPolling / charPollingFraction);
                }
                Console.Write(Properties.Resources.SpaceCharacter);
                
            }

            if (endWithNewLine)
            {
                Console.WriteLine();
            }
        }
    }
}
