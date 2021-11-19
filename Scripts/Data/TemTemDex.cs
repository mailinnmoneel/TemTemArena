using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    class TemTemDex
    {
        //Singleton
        public static TemTemDex Instance { get; } = new TemTemDex();
        private List<TemTem> _temTems;
        public List<TemTem> ActiveTemTems => _temTems ??= new List<TemTem>();

        public Arena Arena { get; set; }
    }
}
