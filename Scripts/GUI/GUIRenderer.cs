using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;
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
            Console.ForegroundColor = DefaultTextColor;
            Console.CursorVisible = false;
            Console.SetBufferSize(ScreenWidth +20, ScreenHeight +20);
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
        }
        public void PushAndDrawText()
        {
            GUI.PushText();
            DrawText();
        }
        void DrawText()
        {
            var text = GUI.Text;
            Console.ForegroundColor = HeaderTextColor;
            int y = 0, x = 0;

            foreach (var cell in text)
            {
                if (cell != null)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(cell);
                }

                x = x < ScreenWidth - 1 ? x + 1 : 0;
                y = x == 0 ? y + 1 : y;
            }
        }

        public void DrawScreenBuffer()
        {
            Console.ForegroundColor = DefaultTextColor;
            GUI.MergeBuffer();

            var buffer = GUI.Buffer;
            Console.ForegroundColor = ConsoleColor.Black;
            int y = 0, x = 0;
            foreach (var cell in buffer)
            {
                if (cell != null)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(cell);
                }

                x = x < ScreenWidth - 1 ? x + 1 : 0;
                y = x == 0 ? y + 1 : y;
            }
        }

        #region Preview
        public void Preview()
        {
            PreviewColors();
            PreviewSymbols();
            Console.Read();
        }

        public void PreviewSymbols()
        {
            Vector2 position = new Vector2(0, 0);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
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
        }

        public void PreviewColors()
        {
            Console.SetCursorPosition(0, ScreenHeight-2);
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out var mode);
            SetConsoleMode(handle, mode | 0x4);

            const char symbol = ' ';
            for (var i = 0; i < 255; i++)
                Console.Write("\x1b[48;5;" + i + $"m{symbol}");
        }
        #endregion
    }
}