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
        Dithering2,
    }

    public enum BorderStyle
    {
        None,
        Regular,
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
            {Border.Dithering2,  '▒'},

            {Border.None,        ' '},
            {Border.TopLeft,     '╔'},
            {Border.TopRight,    '╗'},
            {Border.BottomLeft,  '╚'},
            {Border.BottomRight, '╝'},
            {Border.Vertical,    '║'},
            {Border.Horizontal,  '═'},
        };

        public static int ScreenWidth  = 160;
        public static int ScreenHeight = 48;

        private const int HeaderPadding = 16;
        private const int OffsetX = 4;
        private const int OffsetY = 2;

        public static Vector2 BorderWidth = new Vector2(2, 1);
        public static Vector2 TextPadding = new Vector2(2, 1);

        public static Vector2 HeaderStart    = new Vector2(HeaderPadding, 0);
        public static Vector2 HeaderEnd      = new Vector2(ScreenWidth - HeaderPadding, 8);

        public static Vector2 GameAreaStart  = new Vector2(36  + OffsetX, 7  + OffsetY);
        public static Vector2 GameAreaEnd    = new Vector2(148 + OffsetX, 42 + OffsetY);
        public static Vector2 InfoAreaStart  = new Vector2(4   + OffsetX, 7  + OffsetY);
        public static Vector2 InfoAreaEnd    = new Vector2(36  + OffsetX, 42 + OffsetY);
        public static Vector2 InputAreaStart = new Vector2(36  + OffsetX, 42 + OffsetY);
        public static Vector2 InputAreaEnd   = new Vector2(64  + OffsetX, 46 + OffsetY);
        public static Vector2 InventoryStart = new Vector2(64  + OffsetX, 42 + OffsetY);
        public static Vector2 InventoryEnd   = new Vector2(148 + OffsetX, 46 + OffsetY);

        public static Vector2 CLogLeftStart  = new Vector2(36  + OffsetX, 7  + OffsetY);
        public static Vector2 CLogLeftEnd    = new Vector2(64  + OffsetX, 16 + OffsetY);
        public static Vector2 CLogRightStart = new Vector2(120 + OffsetX, 7  + OffsetY);
        public static Vector2 CLogRightEnd   = new Vector2(148 + OffsetX, 16 + OffsetY);

        public static Vector2 InputPosition  = new Vector2(InputAreaStart.X + BorderWidth.X + 1, InputAreaStart.Y + BorderWidth.Y + 1);

        public static char HeartSymbol = (char)3;
        public static string Dithering1 = "░";
        public static string Dithering2 = "▒";
        public static string Dithering3 = "▓";
            	
        public static string CellOccupiedSymbol = "~";

        public static Color        DefaultBackgroundColor        = Color.DarkGreen;
        public static Color        DefaultTextBackgroundColor    = Color.Wheat;
        public static ConsoleColor DefaultTextColor              = ConsoleColor.Black;

        public static Color        GameAreaBackground            = Color.Purple;
        public static Color        GameAreaBorder                = Color.Goldenrod;
        public static ConsoleColor GameAreaTextColor             = ConsoleColor.Black;

        public static Color        InfoBackground                = Color.LightSlateGray;
        public static Color        InfoBorder                    = Color.Goldenrod;
        public static ConsoleColor InfoTextColor                 = ConsoleColor.Black;

        public static Color        InputBackground               = Color.LightSlateGray;
        public static Color        InputBorder                   = Color.DarkSlateGray;
        public static ConsoleColor InputTextColor                = ConsoleColor.Black;

        public static Color        InventoryBackground           = Color.LightSlateGray;
        public static Color        InventoryBorder               = Color.DarkSlateGray;
        public static ConsoleColor InventoryTextColor            = ConsoleColor.Black;

        public static Color        CombatLogLeft                 = Color.LightSlateGray;
        public static Color        CombatLogLeftBorder           = Color.DarkSlateGray;
        public static ConsoleColor CombatLogLeftTextColor        = ConsoleColor.Black;

        public static Color        CombatLogRight                = Color.LightSlateGray;
        public static Color        CombatLogRightBorder          = Color.DarkSlateGray;
        public static ConsoleColor CombatLogRightTextColor       = ConsoleColor.Black;

        public static Color        HeaderBackground              = Color.Black;
        public static Color        HeaderBorder                  = Color.DarkSlateGray;
        public static ConsoleColor HeaderTextColor               = ConsoleColor.DarkYellow;
    }
}
