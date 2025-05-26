using System;
using System.Collections.Generic;

namespace ChatBotCybersecurity
{
    public class ChatBot
    {
        // Stores the user's name between conversations
        private static string userName;

        // Remembers the last topic discussed (default is "general")
        private static string lastTopic = "general";

        // Keeps track of the bot's last response (for "repeat" command)
        private static string lastResponse = string.Empty;

        // Tracks which cybersecurity topics the user has learned about
        private static List<string> learnedTopics = new List<string>();

        // Database of cybersecurity topics and their responses
        private static Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>
        {
            //Phishing question responses
            { "phishing", new List<string>
                {
                    "Phishing is when scammers send fake emails to trick you into giving up sensitive info. 🛑",
                    "Always check for urgency, suspicious links, and fake sender names. 🔍",
                    "Phishing messages often pretend to be from banks or services. Don't click unknown attachments! 📧",
                    "Look out for spelling errors, generic greetings, and shady links. They're all red flags. 🚩"
                }
            },

            //Password question responses
            { "strong password", new List<string>
                {
                    "Create passwords with a mix of uppercase, lowercase, numbers, and symbols. 💪",
                    "Avoid using names, birthdays, or common words. They're easy to guess. ❌",
                    "Use at least 12 characters and try a passphrase like 'Pizza$Horse!River9'. 🍕🐎🌊",
                    "Consider using a password manager to keep your logins safe and unique. 🔐"
                }
            },

            //VPN question responses
            { "vpn", new List<string>
                {
                    "A VPN hides your IP and encrypts your data. It's like a secure tunnel. 🕵️‍♂️",
                    "Using a VPN on public Wi-Fi protects you from hackers. 🛡️",
                    "VPNs keep your online activity private — even from your ISP. 🔒",
                    "It’s smart to use a VPN when traveling or working remotely. 🌍"
                }
            },

            //Public wifi question responses
            { "public wifi", new List<string>
                {
                    "Public Wi-Fi is often unsecured. Hackers can eavesdrop on your data. 🚫",
                    "Avoid banking or shopping on public networks. Use mobile data or a VPN instead. 📱",
                    "If you must use it, avoid logging into sensitive accounts. 🔐",
                    "Treat public Wi-Fi like a shared space — stay cautious. 🧠"
                }
            },

            //Secure website responses
            { "secure website", new List<string>
                {
                    "Look for 'https://' and a padlock icon before entering any details. 🔒",
                    "Sites without HTTPS may not encrypt your data. Avoid them. ⚠️",
                    "A secure site = encrypted info = safer experience. ✅",
                    "Always check the URL. Misspellings could mean a phishing site. 👀"
                }
            }
        };

        //Method for getting user name for personalised greeting
        public static void GreetUser()
        {
            Console.WriteLine("Hey! What’s your name?");
            userName = Console.ReadLine();
            Console.WriteLine($" Hey, {userName} 👋! I’m ClickShield of course🛡️, your Cybersecurity Awareness Assistant.");
            Console.WriteLine("I’ll help you stay safe from phishing, weak passwords, and shady links.");
        }

        // Processes user input and generates appropriate responses
        public static void RespondToInput(string input)
        {
            // Convert input to lowercase for easier matching
            string lowerInput = input.ToLower();
            // First check if the user seems emotional (worried, frustrated, etc.)
            DetectSentiment(lowerInput);

            // Handle special conversation cases
            if (lowerInput.Contains("thank you") || lowerInput.Contains("thanks"))
            {
                lastResponse = "You're most welcome! I'm always here to help you stay safe. 😊";
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("how are you"))
            {
                lastResponse = "I'm doing great! I hope its the same for you. 😊";
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("who are you") || lowerInput.Contains("purpose"))
            {
                lastResponse = "I'm ClickShield, your friendly cybersecurity assistant! I teach you about scams, secure habits, and protective tools. 🛡️";
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("joke"))
            {
                lastResponse = "Why did the hacker break up with the internet? Too many connections! 😂";
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("fun fact"))
            {
                lastResponse = "🔍 Fun fact: The first computer virus was 'Creeper' in the 1970s. It said: 'I'm the creeper, catch me if you can!'";
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("repeat") || lowerInput.Contains("again"))
            {
                Console.WriteLine("🔁 Repeating my last response:");
                Console.WriteLine(lastResponse);
                return;
            }
            else if (lowerInput.Contains("tell me more") || lowerInput.Contains("more") || lowerInput.Contains("another tip"))
            {
                GiveMoreInfo(lastTopic);
                return;
            }

            // Check if input matches any cybersecurity topics
            foreach (var topic in topicResponses)
            {
                foreach (var keyword in topic.Key.Split(' '))
                {
                    if (lowerInput.Contains(keyword))
                    {
                        lastTopic = topic.Key; //To remember this topic
                        if (!learnedTopics.Contains(topic.Key))
                            learnedTopics.Add(topic.Key); // Add to learned topics
                        RespondWithRandomTip(topic.Key); //Then gives a random tip
                        Console.WriteLine("Would you like to hear another tip or look into something different? 🔁");
                        return;
                    }
                }
            }

            //To handle exit or leaving command
            if (lowerInput.Contains("bye") || lowerInput.Contains("exit") || lowerInput.Contains("quit"))
            {
                EndConversation();
                return;
            }


            //If nothing matched this is the response
            lastResponse = "I didn’t quite understand that 🤔. Try asking me about phishing, passwords, VPNs, or public Wi-Fi, maybe in a different way.";
            Console.WriteLine(lastResponse);
        }

        // Finds emotional words in the input and responds empathetically
        private static void DetectSentiment(string input)
        {
            if (input.Contains("scared") || input.Contains("worried") || input.Contains("anxious"))
            {
                lastResponse = "Don’t worry I know cybersecurity can feel scary, but you're not alone. I'm here to help you. 🤝";
                Console.WriteLine(lastResponse);
            }
            else if (input.Contains("frustrated") || input.Contains("stuck"))
            {
                lastResponse = "No stress — you're doing great. Let’s take it step by step together okay. ";
                Console.WriteLine(lastResponse);
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                lastResponse = "Awesome! Curiosity is the first step to staying cyber-smart you know. 🔍 Ask me anything.";
                Console.WriteLine(lastResponse);
            }
        }

        // Selects and delivers a random tip about the given topic
        private static void RespondWithRandomTip(string topic)
        {
            var tips = topicResponses[topic];
            Random rand = new Random();
            int index = rand.Next(tips.Count);
            lastResponse = tips[index];
            Console.WriteLine(lastResponse);
        }

        // Gives more information about the last discussed topic
        private static void GiveMoreInfo(string topic)
        {
            if (topicResponses.ContainsKey(topic))
            {
                Console.WriteLine("Okay here's another tip for you:");
                RespondWithRandomTip(topic);
            }
            else
            {
                Console.WriteLine("Hmm, I’m not sure what we were talking about before. Try asking me about cybersecurity topics again. 🔁");
            }
        }

        // Ends the conversation with a summary of topics spoken about
        private static void EndConversation()
        {
            Console.WriteLine($"👋 Byeee, {userName}! Oh, and here's a list of what you learned today:");
            foreach (string topic in learnedTopics)
            {
                Console.WriteLine($"- {topic}");
            }
            Console.WriteLine("Don't forget everything you learnt today, Stay safe out there!");
            Environment.Exit(0);
        }
    }
}