using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.TemTems
{
    interface INPCTemTem
    {
        public string Name { get; set; }
        public float Attack();
    }
}
