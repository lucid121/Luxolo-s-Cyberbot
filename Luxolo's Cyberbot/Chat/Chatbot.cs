using System;
using Luxolo_s_Cyberbot.Media;
using Luxolo_s_Cyberbot.UI;

namespace Luxolo_s_Cyberbot.Chat
{
    internal class ChatBot
    {
        private readonly ResponseEngine _engine = new ResponseEngine();
        private string _userName = "Friend";

        // ── Public entry point ────────────────────────────────────────────────

        public void Run()
        {
            ShowWelcomeScreen();
            CollectUserName();
            RunConversationLoop();
            ShowFarewell();
        }

        // ── Startup ───────────────────────────────────────────────────────────

        private static void ShowWelcomeScreen()
        {
            CyberbotUI.PrintLogo();

            string greetingPath = Path.Combine(
          AppContext.BaseDirectory, "Assets", "greeting.wav");

            // ✅ Now actually using the correct path
            AudioPlayer.PlayGreeting(greetingPath);

            CyberbotUI.BotSay("Welcome to the Cybersecurity Awareness Assistant!");
            CyberbotUI.BotSay("I'm here to help you stay safe in the digital world.");
            CyberbotUI.PrintBlankLine();
        }

        // ── Name collection with validation ──────────────────────────────────

        private void CollectUserName()
        {
            CyberbotUI.PrintSectionHeader("Getting to know you");

            while (true)
            {
                CyberbotUI.BotSay("Before we begin, what is your name?");
                CyberbotUI.PrintUserPrompt("You");

                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    CyberbotUI.BotSay("I need a name to personalise our chat. Please try again.",
                                      ConsoleColor.Yellow);
                    continue;
                }

                // Capitalise first letter only
                _userName = char.ToUpper(input[0]) + input.Substring(1).ToLower();
                break;
            }

            CyberbotUI.PrintBlankLine();
            CyberbotUI.BotSay($"Great to meet you, {_userName}!", ConsoleColor.Green);
            CyberbotUI.BotSay("Type a question or topic below. Type 'exit' to quit.");
            CyberbotUI.PrintBlankLine();
        }

        // ── Main conversation loop ────────────────────────────────────────────

        private void RunConversationLoop()
        {
            CyberbotUI.PrintSectionHeader("Cybersecurity Chat");

            while (true)
            {
                CyberbotUI.PrintUserPrompt(_userName);
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                // Exit check
                if (ResponseEngine.IsExitCommand(input))
                    break;

                // Get and display response
                string response = _engine.GetResponse(input);
                CyberbotUI.PrintBlankLine();
                CyberbotUI.BotSay(response, ConsoleColor.White);
                CyberbotUI.PrintBlankLine();
                CyberbotUI.PrintDivider();
            }
        }

        // ── Farewell ──────────────────────────────────────────────────────────

        private void ShowFarewell()
        {
            CyberbotUI.PrintBlankLine();
            CyberbotUI.BotSay($"Stay safe online, {_userName}! Remember:", ConsoleColor.Cyan);
            CyberbotUI.BotSay("  Use strong passwords   Enable 2FA   Browse safely",
                              ConsoleColor.Green);
            CyberbotUI.PrintBlankLine();
            CyberbotUI.PrintDivider('=');
            CyberbotUI.WriteLine("  Session ended. Goodbye!", ConsoleColor.DarkCyan);
            CyberbotUI.PrintDivider('=');
            CyberbotUI.PrintBlankLine();
        }
    }
}