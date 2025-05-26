using System;
using System.Threading;

namespace ChatbotCybersecurity
{
    public static class ASCIIArt
    {
        // Typing effect method
        private static void TypeEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // ASCII Shield Art with Typing Effect
        public static void DisplayShield()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] artLines = new string[]
            {
                "[ C L I C K ░ S H I E L D ]",
                "║█░░░░░░░░░░░░░░░░░░░░░░░█║",
                "║█░       (•‿•)         ░█║    < Heyyy, I'm ClickShield!",
                "║█░  Your cyber buddy   ░█║",
                "║█░  and digital shield.░█║",
                "║█░░░░░░░░░░░░░░░░░░░░░░░█║",
                "         /__\\",
                "       [_____]  "
            };
            

            foreach (string line in artLines)
            {
                TypeEffect(line, 40);
            }

            Console.ResetColor();
            Console.WriteLine(); // Space after art
        }
    }
}