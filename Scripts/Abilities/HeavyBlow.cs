using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Abilities
{
    class HeavyBlow : TemTemTechniques
    {
        public HeavyBlow() : base("Heavy Blow")
        {
        }

        public override void Run()
        {
            
        }

        public override void Info()
        {
            Console.WriteLine("Heavy Blow + litt info om denne technique");
        }
    }
}
