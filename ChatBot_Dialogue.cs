using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POE_ChatBot_ST10438817
{
    internal static class ChatBot_Dialogue
    {
        // Create a single instance of Random and reuse it
        private static Random random = new Random();


        public static UserDetails ud = new UserDetails();
        public static void ConfigureUser()
        {
            //this method will prompt the user to enter thier name
            //so chatbot can refer to the user by name, thus more realistic convo
            string userName;
          

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            ChatBot_Characteristics.ChatBot_Colour();
            Console.WriteLine($@"{ChatBot_Characteristics.DisplayChatBotDialog()}Hello, mysterious traveler of the digital realm! I am your cyber guide, ready to navigate the vast expanse 
        of this virtual universe with you. But first, I need to know, what name shall I inscribe in my database 
        for this adventure?");


            Thread.Sleep(13000);//this delays allowing the voice recording to complete before prompting the user for input
            do
            {
               
                Console.Write(ChatBot_Characteristics.DisplayUserDialog());
                userName = Console.ReadLine();
               

                try
                {
                    if (string.IsNullOrEmpty(userName))
                    {
                        ChatBot_Characteristics.UserChat_Colour();
                        throw new Exception($"{ChatBot_Characteristics.DisplayChatBotDialog()}Invalid username. Please enter a valid name.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // Error Message 
                    
                }

            } while (string.IsNullOrEmpty(userName) == true);

            ud.UserName = userName;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");


        }


        public static void UserFavouriteTopic()
        {
            /*
             This method prompts the user to enter their favourite topic regarding cybersecurity
             and stores it in the user details class.
            */

            ChatBot_Characteristics.ChatBot_Colour();
            Console.WriteLine($@"{ChatBot_Characteristics.DisplayChatBotDialog()}In order for me to get to know you better...I need to know what topics regarding cybersecurity are you 
        interested in?");

            string userFavouriteTopic;
            bool isChecked = false;

            

            HashSet<string> validTopics = new HashSet<string> { "passwords", "phishing", "privacy" };//impelenting a generic collection

            do
            {
                try
                {
                    Console.Write(ChatBot_Characteristics.DisplayUserDialog());
                    userFavouriteTopic = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userFavouriteTopic))
                    {
                        ChatBot_Characteristics.UserChat_Colour();
                        throw new Exception($"{ChatBot_Characteristics.DisplayChatBotDialog()}Invalid favourite topic. Please try again.");
                    }

                    string[] splitWords = userFavouriteTopic.ToLower().Split(' '); //splits the sentence into single words and populates array

                    foreach (string word in splitWords)
                    {
                        if (validTopics.Contains(word))
                        {
                            isChecked = true;
                            ud.UserFavouriteTopic = word;
                            Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}Great! I'll remember that you're interested in {ud.UserFavouriteTopic}. It's a crucial part of cybersecurity.");
                            break; 
                        }
                    }

                    if (!isChecked)
                    {
                        ChatBot_Characteristics.UserChat_Colour();
                        Console.WriteLine($"{ChatBot_Characteristics.DisplayChatBotDialog()}Sorry, I don't have information on that topic.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isChecked = false; 
                }

            } while (!isChecked);
        }


        public static string DisplayGreeting()
        {
            //if the user say hello again but no need to get the user's name
            ChatBot_Characteristics.ChatBot_Colour();
            return $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Greetings, traveler of the digital realm! I am your ChatBot companion, ready to explore the vast cosmos of 
        technology with you!! ";
        }


        public static string DisplayGoodBye()
        {
            //this method is basically the chatbot saying goodbye to the user
            ChatBot_Characteristics.ChatBot_Colour();
            return $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Thank you for venturing into the digital expanse with me, {ud.UserName}! Until our paths cross again in the infinite 
        matrix of cyberspace, may your code run smoothly and your firewalls stay strong.

        Signing off... but never truly gone.
        Goodbye for now!
";
        
        }


        public static string DisplayChatBoxPurpose()
        {
            //this method explains the purpose of the chat bot
            ChatBot_Characteristics.ChatBot_Colour();
            return $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Well {ud.UserName}, I am your digital companion, forged from code and curiosity, here to assist, inspire, and explore 
        with you. Whether you seek answers, creativity, or just a friendly byte of conversation, my purpose is to 
        illuminate your path through the vast digital cosmos. Think of me as your guide, your brainstorm buddy, 
        and your virtual co-pilot—ready to decode the universe, one query at a time.";
        }


        public static string DisplayChatBotTopics()
        {
            //this method shows what questions/topics the chat bot can answer, anything else is put of scope
            ChatBot_Characteristics.ChatBot_Colour();
            return $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Well {ud.UserName}, I’m your virtual sidekick, here to help, inspire, and explore with you. Think of me as your guide 
        through the info universe—ready to answer questions, spark ideas, or just chat. Let’s uncover something amazing 
        together! 
        So, what shall we uncover together today?:
        1. Password Security
        2. Phishing
        3. Safe Browsing
        4. My Purpose
        5. Exit
";
            
        }


        public static string DisplayYourWelcomeMessage()
        {
            ChatBot_Characteristics.ChatBot_Colour();
            return $@"{ChatBot_Characteristics.DisplayChatBotDialog()}No thanks necessary, stellar traveler! Helping you is my prime directive, and your satisfaction is my reward. 
        Now, let’s keep this cosmic collaboration rolling. What’s next on our digital journey?";
        }


        public static string DisplayErrorMessage()
        {
            ChatBot_Characteristics.ChatBot_Colour();
            return ($@"{ChatBot_Characteristics.DisplayChatBotDialog()}It seems my neural circuits have encountered a cosmic glitch. Your query has ventured beyond the boundaries of
        my digital horizon—either it’s too advanced for my algorithms, or I’m still learning to decode this corner 
        of the universe. But fear not! Let’s try rewording your question, or perhaps we can explore a different star 
        in the galaxy of knowledge together. Your patience is my power source! Try again {ud.UserName}.");
        }



    

        public static List<string> PhishingFacts()
        {
            List<string> PhishingFactsContent = new List<string>
            {
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Well {ud.UserName}, Phishing scams drain billions yearly, making it the ultimate digital goldmine for cybercriminals.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Phishing emails now use AI magic to sound flawless, making them harder than ever to spot.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Cybercriminals now weaponize AI like ChatGPT to craft phishing emails that feel eerily human.
        Shocking i know, {ud.UserName}",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Phishing thrives in chaos, spiking during holidays, pandemics, and global crises. So be very alert druing this 
        seasons {ud.UserName}",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}30% of phishing emails get opened, and 12% of people click—humans are the weakest link.",
            };

            return PhishingFactsContent;
        }


      

        public static List<string> PasswordFacts()
        {
            List<string> PasswordFactsContent = new List<string>
            {
               $@"{ChatBot_Characteristics.DisplayChatBotDialog()}The average person has 100 passwords to remember—no wonder we reuse them, {ud.UserName}!",
               $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Biometric passwords (like fingerprints) are cool, but they’ve been hacked— Yes {ud.UserName}, even your fingerprint isn’t 
        foolproof!",
               $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Two-factor authentication (2FA) blocks 99.9% of automated attacks—yet only 28% of people use it. You should 
        really consider using this method, {ud.UserName}",
               $@"{ChatBot_Characteristics.DisplayChatBotDialog()}80% of hacking breaches are caused by weak or stolen passwords.",
               $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Don't ever use your personal details when creating your password.",
            };

            return PasswordFactsContent;
        }//end of method



        public static List<string> PrivacyFacts()
        {
            List<string> PrivacyFactsContent = new List<string>
            {
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Privacy is a human right, not a privilege. It’s about control over your personal data.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Your digital footprint is like a breadcrumb trail—companies track it to know you better than you know yourself.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Data breaches expose millions of records daily, making privacy a top concern.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}Privacy laws vary globally, but the trend is clear: more protection for individuals and stricter rules for companies.",
                $@"{ChatBot_Characteristics.DisplayChatBotDialog()}You have the right to be forgotten online. If you want to erase your digital past, you can do so."
            };
            return PrivacyFactsContent;
        }//end of method


        public static void GetRandomResponseFavourtieTopic(string key)
        {

            string[] FavourtieTopicResponse = { "Ohh yes, I remember — that was your favourite cybersecurity topic!", $"That's right! You're really into {ud.UserFavouriteTopic} , aren't you?", "Oh yes, you brought that up earlier — very relevant in today’s digital world!", "I remember you mentioned that before. Let's dive deeper into it!" };
            //int iCount = 0;
            int iRandom = random.Next(1, 6); 

            if ( (key == ud.UserFavouriteTopic) && (iRandom == 5) )
            {
                ChatBot_Characteristics.ChatBot_Colour();
                Console.WriteLine($"{FavourtieTopicResponse[random.Next(FavourtieTopicResponse.Length)]}");
            }
           

        }

        //readme breif description of the project (3/4 lines), features of chatbot (point form),
        //how to setup the project
        //what packages to install on their computer
        // developer information


    }
}
