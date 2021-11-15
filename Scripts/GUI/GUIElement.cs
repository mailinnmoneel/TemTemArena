using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;

namespace TemTemArena.Scripts.GUI
{
    class GUIElement
    {
        public Vector2 Position;
        public Vector2 Size;
        public ConsoleColor TextColor;
        public Color BackgroundColor;
        public Color BorderColor;
        public BorderStyle BorderStyle;
        public string[] Text;
    }
}
