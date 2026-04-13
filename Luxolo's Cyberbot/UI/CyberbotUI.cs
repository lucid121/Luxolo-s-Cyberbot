using System;
using System.Threading;//For delay

namespace Luxolo_s_Cyberbot.UI
{
    internal class CyberbotUI

    {
        // Write() and WriteLine are for colour text
        public static void Write(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLine(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ResetColor();
        }

       

        ///For Typing animation
        public static void TypeAnimator(string text, ConsoleColor colour = ConsoleColor.White, int delayMs = 18)
        {
            Console.ForegroundColor = colour;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Layout 

        public static void PrintDivider(char symbol = '-', int width = 60)
        {
            WriteLine(new string(symbol, width), ConsoleColor.DarkCyan);
        }

        public static void PrintBlankLine() => Console.WriteLine();

        //  Bot / user labels 

        public static void PrintBotLabel()
        {
            Write("  CyberBot  ", ConsoleColor.Green);
            Write("| ", ConsoleColor.DarkGray);
        }

        public static void PrintUserPrompt(string name)
        {
            PrintBlankLine();
            Write($"  {name,-12}", ConsoleColor.Yellow);
            Write("| ", ConsoleColor.DarkGray);
        }

        // Bot speaks 

          public static void BotSay(string message, ConsoleColor colour = ConsoleColor.White)
        {
            PrintBotLabel();
            TypeAnimator(message, colour);
        }

        // Section header  

        public static void PrintSectionHeader(string title)
        {
            PrintBlankLine();
            PrintDivider('-');
            WriteLine($"  >> {title}", ConsoleColor.Magenta);
            PrintDivider('-');
        }

        // ── ASCII art logo ────────────────────────────────────────────────────

        // Clears the console and prints the CyberBot ASCII logo 
        public static void PrintLogo()
        {
            Console.Clear();
            PrintBlankLine();

            string[] logo =
            {
                @"  ██████╗██╗   ██╗██████╗ ███████╗██████╗  ",
                @" ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗ ",
                @" ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝ ",
                @" ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗ ",
                @" ╚██████╗   ██║   ██████╔╝███████╗██║  ██║ ",
                @"  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝ ",
                @"                                             ",
                @"  Your Cybersecurity Awareness Assistant      ",
            };

            foreach (string line in logo)
                WriteLine(line, ConsoleColor.Cyan);

            PrintBlankLine();
            PrintDivider('=');
            WriteLine("  Protecting South African citizens — one conversation at a time.",
                      ConsoleColor.DarkCyan);
            PrintDivider('=');
            PrintBlankLine();
        }
    }
}