**BRIEF DESCRIPTION**
JARVIS is a console-based chatbot built in C#. JARVIS is a friendly, interactive, conversational chatbot, designed to educate users on cybersecurity topics like password safety, phishing, and privacy settings.
To make this bot feel user-friendly to interact with, I have added personalization, console styling, and even voice interaction.


**FEATURES**
•Conversational interface with stylized bot and user dialogues.
•Personalizes interaction using user’s name.
•Voice greeting using .wav audio playback (via NAudio).
•Sentiment detection, chatbot can adjust its responses based on the user’s sentiment to create an empathetic interaction.
•Chatbot can recognise keywords and generate random responses for each keyword.
•Chatbot is equipped with memory recall abilities.
•Code is modular consisting of 6 classes.
•Answers questions about:
      o	Password Security
      o	Phishing
      o	Privacy Settings
      o	Chatbot's Purpose
•	Console colour formatting for user/bot responses.
•	ASCII art logo on startup and exit.


**HOW TO SETUP PROJECT**
1. Clone or download the project folder.
2. Open the project in Visual Studio 2022.
3. Ensure that your solution contains:
     o	Program.cs
     o	UserDetails.cs
     o	ChatBot_Dialogue.cs
     o	DataDictionary.cs
     o	ChatBot_Characteristics.cs
     o	ChatBot_Logo.cs
     o	JARVIS.wav file
     o	As well as all the necessary files and folders
4. Build and run the project.


**REQUIRED PACKAGES**
Install the NuGet Package, from the Package Manager Console – “Install-Package NAudio”. NAudio is used to play audio file within the chatbot. This is how voice integration is incorporated into the project.


**DEVELOPER INFORMATION**
**Developer Name:** Elishua Emmanuel Naidoo
**Developer Student Number:** ST10438817
**Institution:** The IIE Varsity College Westville
**Course:** PROG6221
**Language:** C# (.NET Framework)
**IDE:** Visual Studio 2022
