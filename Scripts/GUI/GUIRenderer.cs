using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using TemTemArena.Scripts.Data;
using static TemTemArena.Scripts.Data.ScreenData;


namespace TemTemArena.Scripts.GUI
{
    class GUIRenderer
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public GUIRenderer()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetBufferSize(ScreenWidth +20, ScreenHeight +20);
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
        }

        void FillScreen(Color backgroundColor)
        {
            for (var y = 0; y < ScreenHeight; y++)
            for (var x = 0; x < ScreenWidth; x++)
                Draw(x, y);

            void Draw(int x, int y)
            {
                var color = Colors.GetColor(backgroundColor);
                Console.SetCursorPosition(x, y);
                Console.Write("\x1b[48;5;" + color + "m ");
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void PrintAllColors()
        {
            Console.SetCursorPosition(0, 0);
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out var mode);
            SetConsoleMode(handle, mode | 0x4);

            const char symbol = ' ';
            for (var i = 0; i < 255; i++)
                Console.Write("\x1b[48;5;" + i + $"m{symbol}");
        }

        void ResetConsole()
        {
            ClearScreen();
            FillScreen(Color.Blue);
            DrawGUIAreas();

            PrintAllColors();
            Console.SetCursorPosition(0, 5);
        }

        void DrawGUIAreas()
        {
            DrawGameArea();
            DrawInfoArea();

            void DrawGameArea()
            {
                Console.ForegroundColor = GameAreaBorderColor;

                for (var y = GameAreaStart.Y; y < GameAreaEnd.Y; y++)
                for (var x = GameAreaStart.X; x < GameAreaEnd.X; x++)
                {
                    if ( (x == GameAreaStart.X || x == GameAreaStart.X+1 || x == GameAreaEnd.X-2 || x == GameAreaEnd.X-1) ||
                         (y == GameAreaStart.Y || y == GameAreaEnd.Y-1))
                         Draw(Color.DarkRed, x, y, true);
                    else Draw(Color.IndianRed, x, y, false);
                }
            }

            void DrawInfoArea()
            {
                Console.ForegroundColor = InfoBorderColor;

                for (var y = InfoAreaStart.Y; y < InfoAreaEnd.Y; y++)
                for (var x = InfoAreaStart.X; x < InfoAreaEnd.X; x++)
                {
                    if ((x == InfoAreaStart.X || x == InfoAreaStart.X + 1 || x == InfoAreaEnd.X - 2 || x == InfoAreaEnd.X - 1) ||
                        (y == InfoAreaStart.Y || y == InfoAreaEnd.Y - 1))
                        Draw(Color.ForestGreen, x, y, true);
                    else Draw(Color.Green, (int) x, (int) y, false);
                }
            }

            void Draw(Color col, float x, float y, bool border)
            {
                var symbol = border ? BorderSymbol : ' ';
                var color = Colors.GetColor(col);
                Console.SetCursorPosition((int)x, (int)y);
                Console.Write("\x1b[48;5;" + color + $"m{symbol}");
            }
        }

        public void AddMessage(Align alignment, string[] messages)
        {
            ResetConsole();
            var col = Colors.GetColor(Color.Green);
            DrawMessage(alignment, messages, col);
        }
        public void AddMessage(Align alignment, string message)
        {
            ResetConsole();
            var col = Colors.GetColor(Color.Green);
            var messages = new string[]
            {
                message,
            };
            DrawMessage(alignment, messages, col);
        }
        public void AddMessage(Align alignment, string[] messages, Color color)
        {
            ResetConsole();
            var col = Colors.GetColor(color);
            DrawMessage(alignment, messages, col);
        }
        static void DrawMessage(Align alignment, string[] messages, int col)
        {
            Vector2 position = ScreenData.InfoAreaStart + Anchor[alignment] + BorderWidth;

            foreach (var message in messages)
            {
                Console.SetCursorPosition((int)position.X, (int)position.Y);

                string newLine = null;
                var length = message.Length;

                for (var i = 0; i < length; i++)
                    newLine += "\x1b[48;5;" + col + $"m{message[i]}";

                Console.Write($"{newLine}\n");

                position.Y++;
            }
        }

        [Obsolete("Used to offset the messages with the Align parameter. Should instead add messages to a message class that the GUI reads from to decide position")]
        private static double MessageWidth(IEnumerable<string> messages)
        {
            var length = 0;
            foreach (var message in messages)
                length = message.Length > length ? message.Length : length;

            return length;
        }

        public void PrintAllSymbols()
        {
            Vector2 position = new Vector2(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (var i = 0; i < 256; i++)
            {
                if (i % (ScreenHeight-2) == 0) { position.X += 10; position.Y = 0; }

                Console.SetCursorPosition((int)position.X, (int)position.Y + i % (ScreenHeight-2));
                Console.WriteLine($"{i}: {(char)i}");
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((int)(position.X), ScreenHeight-3);
            var message = "Press any key to begin...";
            Console.WriteLine(message);
            Console.SetCursorPosition((int)(position.X + message.Length), ScreenHeight - 3);
            Console.Read();
        }
    }
}