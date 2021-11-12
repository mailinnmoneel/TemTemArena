using System;
using System.Collections.Generic;
using System.Numerics;
using TemTemArena.Scripts.GUI;

namespace TemTemArena.Scripts.Data
{
    public enum Align
    {
        Center,
        Left,
        Right,
        Top,
        Bottom,
    }
    public static class ScreenData
    {
        public static int ScreenWidth = 128;
        public static int ScreenHeight = 32;

        public static Vector2 BorderWidth = new Vector2(2, 1);
        public static Vector2 GameAreaStart = new Vector2(34, 5);
        public static Vector2 GameAreaEnd = new Vector2(120, 30);
        public static Vector2 InfoAreaStart = new Vector2(2, 5);
        public static Vector2 InfoAreaEnd = new Vector2(32, 30);

        public static readonly Dictionary<Align, Vector2> Anchor = new Dictionary<Align, Vector2>
        {
            {Align.Center, new Vector2(ScreenWidth * 0.5f, ScreenHeight * 0.5f)},
            {Align.Left, new Vector2(0, 0)},
            {Align.Right, new Vector2(ScreenWidth, 0)},
            {Align.Top, new Vector2(0, 0)},
            {Align.Bottom, new Vector2(0, ScreenHeight)},
        };

        public static char BorderSymbol = (char)3;
        public static ConsoleColor GameAreaBorderColor = ConsoleColor.Black;
        public static ConsoleColor InfoBorderColor = ConsoleColor.DarkMagenta;
    }
}
