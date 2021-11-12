using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena 
{
    class BasicAttack : Techniques, IBasic
    {
        public float BasicAttacks(float damage)
        {
            return damage;
            
        }
    }
}
