using NAudio.Wave;
using POE_ChatBot_ST10438817;

namespace ST10438817_POE_PART2_CHATBOT
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DataDictionary.OnFavoriteTopicMentioned += ChatBot_Dialogue.GetRandomResponseFavourtieTopic;


            ChatBot_Logo.DisplayIntroLogo();

            string filePath = @"JARVIS.wav";
            //the file path of the audio file


            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                ChatBot_Dialogue.ConfigureUser();//gets the user name and introduces itself to the user
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
                Console.WriteLine(ChatBot_Dialogue.DisplayChatBotTopics());//displays all the topics the user can ask the chatbot
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
                ChatBot_Dialogue.UserFavouriteTopic();//gets user favoutie topic
                DataDictionary.DisplayResponse(ChatBot_Dialogue.ud);//conversation begins and the user can ask relevant questions
                Console.ReadKey();

                Console.ReadLine(); // Keeps the app running while music plays
            }

        }
    }
}
