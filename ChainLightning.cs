using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    class ChainLightning : Techniques, IElectric
    {
        static float ChainLightnings(float damage)
        {
            return damage * damage;
        }
    }
}
