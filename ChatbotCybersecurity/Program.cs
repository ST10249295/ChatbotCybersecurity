using ChatbotCybersecurity;
using System;
using System.IO;
using System.Media;

namespace ChatBotCybersecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            PlayVoiceGreeting();
            ASCIIArt.DisplayShield();
            ChatBot.GreetUser();

            Console.WriteLine("\nType your cybersecurity questions below, or type 'bye'when you want to end the chat.");

            while (true)
            {
                Console.Write("\n🗣️ You: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("⚠️ Please type something so I can respond.");
                    continue;
                }

                if (input.ToLower().Contains("bye") || input.ToLower().Contains("exit") || input.ToLower().Contains("quit"))
                {
                    ChatBot.RespondToInput("bye"); // Chat bot decides the exit 
                    break;
                }

                ChatBot.RespondToInput(input);
            }

            Console.WriteLine("\n👋 Press any key to exit...");
            Console.ReadKey();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                string path = Path.Combine("Assets", "greeting_new.wav");
                if (File.Exists(path))
                {
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    Console.WriteLine("🔊 Voice greeting not found. Continuing without audio...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to play greeting: {ex.Message}");
            }
        }

       
    }
}