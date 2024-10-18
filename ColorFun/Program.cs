using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ColorFun
{
    internal class Program
    {
        static Type consoleColorType = typeof(ConsoleColor);
        static int selectedColorIndex = 0;
        static string[] colorList = Enum.GetNames(consoleColorType);

        static void Main(string[] args)
        {
            while (true)
            {
                printColorList();
                handleKeyPress(Console.ReadKey().Key);
            }
        }

        static void handleKeyPress(ConsoleKey keyPress)
        {
            switch (keyPress)
            {
                case ConsoleKey.DownArrow:
                    if (selectedColorIndex < colorList.Length)
                        selectedColorIndex++;
                    break;

                case ConsoleKey.UpArrow:
                    if (selectedColorIndex > 0)
                        selectedColorIndex--;
                    break;

                case ConsoleKey.Tab: //DISCOTEK!!!!!😎
                    discoTek();
                    Console.ReadLine(); //idk why this is needed to stop program terminating?

                    break;
            }
        }

        static void printColorList()
        {
            int colorIndex = 0;

            Console.Clear();
            Console.WriteLine("Navigate the list using the Arrow Keys (Do not press TAB): ");

            foreach (var name in colorList)
            {
                Console.ForegroundColor = getConsoleColor(name);

                if (name == "Black")
                    Console.BackgroundColor = getConsoleColor("Gray");
                else
                    Console.BackgroundColor = getConsoleColor("Black");

                Console.WriteLine($" {((selectedColorIndex == colorIndex) ? ">" : " ")} {name} ");
                colorIndex++;
            }
        }

        static ConsoleColor getConsoleColor(string color)
        {
            return (ConsoleColor)Enum.Parse(consoleColorType, color);
        }

        static async void discoTek()
        {
            bool isBlue = false;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i <= 800; i++)
                {
                    if (isBlue)
                        Console.BackgroundColor = getConsoleColor("Blue");
                    else
                        Console.BackgroundColor = getConsoleColor("Green");

                    Console.Write("DISCOTEK");
                    isBlue = !isBlue;
                }

                Console.BackgroundColor = getConsoleColor("Black");

                await Task.Delay(250);
            }
        }
    }
}
