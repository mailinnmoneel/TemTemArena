using System;
using System.Collections.Generic;
using System.Drawing;
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
    public enum Border
    {
        None,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Vertical,
        Horizontal,
    }
    public static class ScreenData
    {
        public static readonly Dictionary<Align, Vector2> Anchor = new Dictionary<Align, Vector2>
        {
            {Align.Center, new Vector2(ScreenWidth * 0.5f, ScreenHeight * 0.5f)},
            {Align.Left,   new Vector2(0, 0)},
            {Align.Right,  new Vector2(ScreenWidth, 0)},
            {Align.Top,    new Vector2(0, 0)},
            {Align.Bottom, new Vector2(0, ScreenHeight)},
        };

        public static readonly Dictionary<Border, char> BorderTypes = new Dictionary<Border, char>
        {
            {Border.None, ' '},
            {Border.TopLeft, '╔'},
            {Border.TopRight, '╗'},
            {Border.BottomLeft, '╚'},
            {Border.BottomRight, '╝'},
            {Border.Vertical, '║'},
            {Border.Horizontal, '═'},
        };

        public static int ScreenWidth = 128;
        public static int ScreenHeight = 32;

        public static Vector2 HeaderStart = new Vector2(0, 0);
        public static Vector2 HeaderEnd = new Vector2(ScreenWidth, 6);
        public static Vector2 BorderWidth = new Vector2(2, 1);
        public static Vector2 GameAreaStart = new Vector2(36, 6);
        public static Vector2 GameAreaEnd = new Vector2(122, 31);
        public static Vector2 InfoAreaStart = new Vector2(4, 6);
        public static Vector2 InfoAreaEnd = new Vector2(36, 26);
        public static Vector2 TextPadding = new Vector2(2, 1);
        public static Vector2 InputAreaStart = new Vector2(4, 26);
        public static Vector2 InputAreaEnd = new Vector2(36, 31);
        public static Vector2 InputPosition = new Vector2(InputAreaStart.X + BorderWidth.X + 1, InputAreaStart.Y + BorderWidth.Y + 1);

        public static char HeartSymbol = (char)3;

        public static Color DefaultBackgroundColor = Color.CornflowerBlue;
        public static Color DefaultTextBackgroundColor = Color.Wheat;

        public static Color GameAreaBackground = Color.Purple;
        public static Color GameAreaBorder = Color.ForestGreen;
        public static ConsoleColor GameAreaTextColor = ConsoleColor.Black;

        public static Color InfoBackground = Color.LightSlateGray;
        public static Color InfoBorder = Color.DarkRed;
        public static ConsoleColor InfoTextColor = ConsoleColor.Black;

        public static Color InputBackground = Color.IndianRed;
        public static Color InputBorder = Color.DarkOrange;
        public static ConsoleColor InputTextColor = ConsoleColor.Black;

        public static Color HeaderBackground = Color.White;
        public static Color HeaderBorder = Color.Black;
        public static ConsoleColor HeaderTextColor = ConsoleColor.Black;

    }
}
