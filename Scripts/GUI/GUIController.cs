using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.GUI
{
    class GUIController
    {
        public static GUIController Instance { get; } = new GUIController();

        public bool Initialized { get; set; }
        public EventLog EventLog { get; set; }
        public ScreenBuffer ScreenBuffer { get; set; }
        public GUIRenderer Renderer { get; set; }
    }
}
