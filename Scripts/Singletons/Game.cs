using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.GUI;

namespace TemTemArena.Scripts.Singletons
{
    class Game
    {
        public static Game Manager { get; } = new Game();
        public GUIRenderer Renderer { get; set; }
    }
}