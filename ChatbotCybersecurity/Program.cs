using ChatbotCybersecurity;
using System;
using System.IO;
using System.Media;

namespace ChatBotCybersecurity
{
    class Program
    {
        static void Main(string[] args)

        {   //Allows charcters and emojis
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Plays the voice greeting
            PlayVoiceGreeting();

            // Shows ASCII Art 
            ASCIIArt.DisplayShield();

            // Start the chatbot interaction
            ChatBot.GreetUser();

            // Simple Q&A loop
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nAsk me something about cybersecurity:");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "bye")
                {
                    running = false;
                    Console.WriteLine("Goodbye! It was great chatting to you, Stay safe online. 👋");
                }
                else
                {
                    ChatBot.RespondToBasicQuestions(userInput);
                }
            }
        }

        // Method to play greeting sound
        private static void PlayVoiceGreeting()
        {
           
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/greeting_new.wav");
                player.PlaySync(); // Play the greeting synchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting sound: " + ex.Message);
            }
        }
    }
}
