using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_ChatBot_ST10438817
{
    internal static class ChatBot_Characteristics
    {
        public static void UserChat_Colour()
        {
            //changes the colour of font for the user
            Console.ForegroundColor = ConsoleColor.Cyan;
        }//end of method


        public static void ChatBot_Colour()
        {
            //changes the colour of font for the chatbot
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static string DisplayUserDialog()
        {
            //this method displays USER: .......... in the interface of the chat
            UserChat_Colour();
            return ($"\nUSER: ");
        }//end of method

        public static string DisplayChatBotDialog()
        {
            //this method displays JARVIS: .......... in the interface of the chat
            ChatBot_Colour();
            return ($"\nJARVIS: ");
        }//end of method



    }//end of class
}
