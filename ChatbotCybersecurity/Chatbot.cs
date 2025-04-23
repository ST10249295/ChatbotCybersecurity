using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotCybersecurity
{
    public class ChatBot
    {
        public static void GreetUser()
        {
            // Gets user's name for personalised greeting
            Console.WriteLine("Hey! What’s your name?");
            string userName = Console.ReadLine();
            Console.WriteLine($"👋 Hello, {userName}! I’m ClickShield🛡️, your Cybersecurity Awareness Assistant.");
            Console.WriteLine();
            Console.WriteLine("I’ll help you stay safe from phishing, weak passwords, and shady links. Let's protect you!");
        }

        // Method for interactive question and answers
        public static void RespondToBasicQuestions(string input)
        {
            input = input.ToLower();

            if (input.Contains("how are you"))
            {
                Console.WriteLine("I'm doing great! Always ready to protect you from cyber threats. 😊");
            }
            else if (input.Contains("what is your purpose"))
            {
                Console.WriteLine("My purpose is to educate and protect you from online threats like phishing, malware, and unsafe browsing.");
            }
            else if (input.Contains("what can i ask you about"))
            {
                Console.WriteLine("You can ask me about online security, avoiding phishing scams, creating strong passwords, secure browsing tips, and how to protect your privacy on the internet.");
            }
            else if (input.Contains("what is phishing"))
            {
                Console.WriteLine("Phishing is a deceptive tactic where scammers impersonate trustworthy entities to trick you into sharing personal info. Be cautious with unexpected emails or links! 🛑");
            }
            else if (input.Contains("how can i create a strong password") || input.Contains("strong password"))
            {
                Console.WriteLine("Use a mix of upper/lowercase letters, numbers, and special characters. Avoid personal info and make it at least 12 characters long. 💪 Consider using a password manager!");
            }
            else if (input.Contains("how do i know if a website is secure") || input.Contains("secure website"))
            {
                Console.WriteLine("Look for 'https://' and a padlock icon in the address bar. These signs show the site is encrypted. 🔒 Be cautious of sites without them!");
            }
            else if (input.Contains("how can i spot a phishing email") || input.Contains("phishing email"))
            {
                Console.WriteLine("Watch for urgency, spelling mistakes, strange senders, or suspicious links. Always verify the sender’s address and don’t click unknown attachments. 📧⚠️");
            }
            else if (input.Contains("what should i do if i’ve been hacked") || input.Contains("hacked"))
            {
                Console.WriteLine("Change your passwords right away, enable 2FA, and check for unauthorized activity. Contact your bank or service provider if needed. 🔐");
            }
            else if (input.Contains("why is public wi-fi risky") || input.Contains("public wifi"))
            {
                Console.WriteLine("Public Wi-Fi is often unsecured, so hackers can intercept your data. Avoid sensitive tasks on it, and use a VPN when possible. 📶🚫");
            }
            else if (input.Contains("what is a vpn") || input.Contains("why should i use a vpn"))
            {
                Console.WriteLine("A VPN encrypts your connection and hides your IP, keeping your browsing private and safe — especially on public Wi-Fi. 🕵️‍♂️🛡️");
            }
            else
            {
                Console.WriteLine("I didn’t quite understand that 🤔. Try asking me about phishing, passwords, secure browsing, or how to stay safe online!");
            }
        }
    }
}