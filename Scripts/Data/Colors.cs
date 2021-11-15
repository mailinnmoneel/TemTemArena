using System.Collections.Generic;
using System.Drawing;

namespace TemTemArena.Scripts.Data
{
    public static class Colors
    {
        public static int GetColor(Color col)
        {
            var hasKey = ColorId.TryGetValue(col, out int value);
            return hasKey ? value : ColorId[Color.Black];
        }

        //-- ALL COLOR VALUES
        //-- https://i.stack.imgur.com/q0rog.jpg

        public static readonly Dictionary<Color, int> ColorId = new Dictionary<Color, int>()
        {
            {Color.Black, 16},
            {Color.Red, 1},
            {Color.Green, 2},
            {Color.Yellow, 3},
            {Color.Blue, 4},
            {Color.Purple, 5},
            {Color.CornflowerBlue, 6},
            {Color.Wheat, 7},
            {Color.Gray, 8},
            {Color.IndianRed, 9},
            {Color.ForestGreen, 10},
            {Color.DarkOrange, 202},
            {Color.DarkRed, 124},
            {Color.LightSlateGray, 251},
            {Color.White, 255},
        };
    }
}
