using System;
using System.Threading;

namespace fractalsmaybe
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] letters = { "■", "@", "%", "#", "$", "!",  "-"};
            string[] emptyLetters = { " ", " ", " ", " ", " ", " ", " " };
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            /*
            INDEX (maxLength changes the animation shape)
            PrintPattern(string[] letters, int windowSize, int lines, int sleepMilis, int maxLength)
            PrintPattern(letters, 90, 80, 60, 66); static wave
            PrintPattern(letters, 90, 80, 60, 67); curvy
            PrintPattern(letters, 90, 80, 60, 68); \\diag
            PrintPattern(letters, 90, 80, 60, 69); \\slow diag
            PrintPattern(letters, 90, 80, 60, 70); vert
            PrintPattern(letters, 90, 80, 60, 71); //slow diag
            PrintPattern(letters, 90, 80, 60, 72); \\med diag
            PrintPattern(emptyLetters, 90, 80, 10, 71; moves the cursor around
            */



            //Your animation goes below. this is a test animation.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            PrintPattern(letters, 90, 10, 5, 68);
            PrintPattern(letters, 90, 10, 5, 69);
            PrintPattern(letters, 90, 10, 5, 70);
            PrintPattern(letters, 90, 10, 5, 71);
            PrintPattern(letters, 90, 10, 5, 72);



        }


        static void PrintPattern(string[] letters, int windowSize, int lines, int sleepMilis, int maxLength)
        {
            //function currently unused
            Console.SetWindowSize(windowSize, 30);
            //amount of lines
            for (int i = 0; i < lines; i++)
            {
                //line content
                for (int j = 0; j < letters.Length - 1; j++)
                {
                     PrintLightToDark(letters, maxLength);
                     PrintDarkToLight(letters, maxLength);
                }
                Thread.Sleep(sleepMilis);
            }
        }


        static void PrintSpecificCharLengthTimes (char letterInput, string[] letters, int maxLength)
        {
            for (int i = 0; i < letters.Length - 1; i++)
            {
                if (0 == maxLength) { 
                    Console.WriteLine();
                    //charC = 0;
                }
                Console.Write(letterInput);
            }
        }


        static void PrintLightToDark(string[] letters, int maxLength)
        {

            int i = letters.Length - 1;
            foreach (string letter in letters)
            {
                ValueTuple<Int32, Int32> cursorPosition = Console.GetCursorPosition();
                if (cursorPosition.Item1 >= maxLength)
                {
                    Console.SetCursorPosition(0, cursorPosition.Item2);
                    Console.WriteLine("");
                }
                Console.Write(letters[i]);
                i--;

            }
        }

        static void PrintDarkToLight(string[] letters, int maxLength)
        {
            foreach (string letter in letters)
            {
                ValueTuple<Int32, Int32> cursorPosition = Console.GetCursorPosition();
                if (cursorPosition.Item1 >= maxLength)
                {
                    Console.SetCursorPosition(0, cursorPosition.Item2);
                    Console.WriteLine("");
                }
                Console.Write(letter);
            }
        }

    }
}
