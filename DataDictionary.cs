using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POE_ChatBot_ST10438817
{

    internal static class DataDictionary
    {

        //define my delegate
        public delegate void FavoriteTopicHandler(string topic);

        public static event FavoriteTopicHandler OnFavoriteTopicMentioned;

        // Create a single instance of Random and reuse it
        private static Random random = new Random();

        public static Dictionary<string, string> chatResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {



        };


        public static Dictionary<string, List<string>> cyberResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {



        };


        public static Dictionary<string, List<string>> sentimentResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {



        };



        public static string GetRandomCyberResponse(string key)
        {
            // this method will alow me to display random resposnes to the user for cyber content

            if (cyberResponses.TryGetValue(key, out List<string> randomResponses) && randomResponses.Count > 0)
            {
                return randomResponses[random.Next(randomResponses.Count)];
            }
            return "I don't have a response for that.";
        }

        public static string GetRandomSentimentResponse(string key)
        {
            // this method will alow me to display random resposnes to the user for sentiment content

            if (sentimentResponses.TryGetValue(key, out List<string> randomResponses) && randomResponses.Count > 0)
            {
                return randomResponses[random.Next(randomResponses.Count)];
            }
            return "I don't have a response for that.";
        }



        private static UserDetails CurrentUser { get; set; }


        public static void DisplayResponse(UserDetails userDetails)
        {

            HashSet<string> validTopics = new HashSet<string> { "passwords", "phishing", "privacy" };//impelenting a generic collection


            CurrentUser = userDetails;

            List<string> greetings = new List<string> { "hello", "hi", "hey", "greetings" };
            foreach (var greeting in greetings)
            {
                chatResponses.Add(greeting, ChatBot_Dialogue.DisplayGreeting());
            }

            List<string> goodbyes = new List<string> { "goodbye", "bye", "see you later", "exit" };
            foreach (var goodbye in goodbyes)
            {
                chatResponses.Add(goodbye, ChatBot_Dialogue.DisplayGoodBye());
            }

            List<string> thanks = new List<string> { "thanks", "thank", "thank you so much", "thank you" };
            foreach (var thank in thanks)
            {
                chatResponses.Add(thank, ChatBot_Dialogue.DisplayYourWelcomeMessage());
            }

            List<string> topics = new List<string> { "topic", "topics", "what can you do?" };
            foreach (var topic in topics)
            {
                chatResponses.Add(topic, ChatBot_Dialogue.DisplayChatBotTopics());
            }

            List<string> purposes = new List<string> { "purpose", "what is your purpose?", "what is your purpose" };
            foreach (var purpose in purposes)
            {
                chatResponses.Add(purpose, ChatBot_Dialogue.DisplayChatBoxPurpose());
            }

            List<string> phishings = new List<string> { "phishing", "facts about phishing", "talk about phishing", "discuss about phishing", "what is phishing?" };
            foreach (var phishing in phishings)
            {
                cyberResponses.Add(phishing, ChatBot_Dialogue.PhishingFacts());
            }

            List<string> passwords = new List<string> { "passwords", "facts about passwords", "talk about passwords", "discuss about passwords" };
            foreach (var password in passwords)
            {
                cyberResponses.Add(password, ChatBot_Dialogue.PasswordFacts());
            }

            List<string> privacies = new List<string> { "privacy", "facts about privacy", "talk about privacy", "discuss about privacy" };
            foreach (var privacy in privacies)
            {
                cyberResponses.Add(privacy, ChatBot_Dialogue.PrivacyFacts());
            }


            List<string> passwordSentiment = new List<string> { "I am concerned about password saftey", "I am worried about password saftey", "I am frustrated about password saftey", "I am concerned about passwords", "I am worried about passwords", "I am frustrated about passwords" };
            foreach (var passwordSentimentFact in passwordSentiment)
            {
                sentimentResponses.Add(passwordSentimentFact, ChatBot_Dialogue.PasswordSentiment());
            }

            List<string> phishingSentiment = new List<string> { "I am concerned about phishing", "I am worried about phishing", "I am frustrated about phishing" };
            foreach (var phishingSentimentFact in phishingSentiment)
            {
                sentimentResponses.Add(phishingSentimentFact, ChatBot_Dialogue.PhishingSentiment());
            }

            List<string> privacySentiment = new List<string> { "I am concerned about privacy", "I am worried about privacy", "I am frustrated about privacy" };
            foreach (var privacySentimentFact in privacySentiment)
            {
                sentimentResponses.Add(privacySentimentFact, ChatBot_Dialogue.PrivacySentiment());
            }


            string userInput = "";
            do
            {

                Console.Write(ChatBot_Characteristics.DisplayUserDialog());
                userInput = Console.ReadLine().Trim().ToLower();//trim removes all whitespaces


                string[] splitWords = userInput.ToLower().Split(' ');


                if (chatResponses.ContainsKey(userInput))
                {
                    ChatBot_Characteristics.ChatBot_Colour();
                    Console.WriteLine($"{chatResponses[userInput]}");

                }
                else if (cyberResponses.ContainsKey(userInput))
                {
                    ChatBot_Characteristics.ChatBot_Colour();
                    Console.WriteLine($"{GetRandomCyberResponse(userInput)}");

                    foreach (string word in splitWords)
                    {
                        if (validTopics.Contains(word))
                        {
                            Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}Would you like to know more about {word}? It's a crucial part of cybersecurity.");
                            Console.Write($"{ChatBot_Characteristics.DisplayUserDialog()}");
                            string response = Console.ReadLine().Trim().ToLower();

                            if (response == "yes" || response == "sure" || response == "absolutely")
                            {
                                Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}Great! Here's some more information about {word}:");
                                Console.WriteLine($"{GetRandomCyberResponse(word)}");
                            }
                            else if (response == "no" || response == "not really" || response == "no thanks")
                            {
                                Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}No problem! If you have any other questions, feel free to ask.");
                            }
                            else
                            {
                                Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}I didn't quite understand that. Please answer with 'yes' or 'no'.");
                            }
                        }
                    }


                }
                else if (sentimentResponses.ContainsKey(userInput))
                {
                    ChatBot_Characteristics.ChatBot_Colour();
                    Console.WriteLine($"{GetRandomSentimentResponse(userInput)}");
                }

                else
                {
                    ChatBot_Characteristics.ChatBot_Colour();
                    Console.WriteLine($"{ChatBot_Dialogue.DisplayErrorMessage()}");
                }
                // Check if the input matches the favorite topic and trigger event
                // Replace your current check with:
                if (CurrentUser != null &&
                    userInput.IndexOf(CurrentUser.UserFavouriteTopic, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    OnFavoriteTopicMentioned?.Invoke(CurrentUser.UserFavouriteTopic);
                }

            } while ((userInput != "exit") && (userInput != "goodbye") && (userInput != "bye") && (userInput != "see you later"));

            ChatBot_Logo.DisplayGoodbyeLogo();

        }//end of method



    }//end of class
}

