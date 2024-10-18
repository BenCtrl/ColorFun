using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace ColorFun
{
    internal class Program
    {
        static Type consoleColorType = typeof(ConsoleColor);
        static int selectedColorIndex = 0;
        static string[] colorList = Enum.GetNames(consoleColorType);

        static string colorOne = "";
        static string colorTwo = "";

        static bool readyToMix = false;
        static bool menuHeartBeat = true;

        static void Main(string[] args)
        {
            while (menuHeartBeat)
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
                case ConsoleKey.Enter:
                    string chosenColor = colorList[selectedColorIndex];

                    if (!String.IsNullOrEmpty(colorOne) && !String.IsNullOrEmpty(colorTwo))
                    {
                        mixColors();
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(colorOne))
                            colorOne = chosenColor;
                        else if (String.IsNullOrEmpty(colorTwo))
                            colorTwo = chosenColor;
                    }
                    break;
            }
        }

        static void printColorList()
        {
            int colorIndex = 0;

            Console.Clear();
            Console.WriteLine(" > Navigate the list using the Arrow Keys\n > Enter to select a color (Do not press TAB)\n > Backspace to undo selection\n");

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

            Console.WriteLine("");

            if (!String.IsNullOrEmpty(colorOne) || !String.IsNullOrEmpty(colorTwo))
            {
                Console.WriteLine($"Color One: {colorOne}\nColor Two: {colorTwo}");
            }

            if (!String.IsNullOrEmpty(colorOne) && !String.IsNullOrEmpty(colorTwo))
            {
                Console.WriteLine("Press Enter to confirm color selection...");
            }
        }

        static void printColorMix()
        {
            menuHeartBeat = false;

            Console.Clear();
            Console.WriteLine("These colors cannot be mixed! D:");
        }

        static void printColorMix(string finalColorName)
        {
            menuHeartBeat = false;

            Console.Clear();

            Console.Write("The final color is");
            Console.ForegroundColor = getConsoleColor(finalColorName);
            Console.WriteLine($" {finalColorName}!");

            Console.ForegroundColor = getConsoleColor("White");
        }

        static void mixColors()
        {
            if (colorOne == "Blue" || colorTwo == "Blue")
            {
                if (colorOne == "Green" || colorTwo == "Green")
                    printColorMix("Cyan");
                else if (colorOne == "Red" || colorTwo == "Red")
                    printColorMix("Magenta");
                else if (colorOne == "Yellow" || colorTwo == "Yellow")
                    printColorMix("Green");
                else
                    printColorMix();
            }
            else if (colorOne == "Red" || colorTwo == "Red")
            {
                if (colorOne == "Green" || colorTwo == "Green")
                    printColorMix("Yellow");
                else
                    printColorMix();
            } else
            {
                printColorMix();
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
