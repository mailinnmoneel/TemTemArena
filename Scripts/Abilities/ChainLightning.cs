using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Abilities;

namespace TemTemArena
{
    class ChainLightning : TemTemTechniques
    {
        public ChainLightning() : base("Chain Lightning")
        {

        }

        public override void Run()
        {
            //Bruke Chain Lightning
        }

        public override void Info()
        {
            Console.WriteLine("Chain Lightning + some info on this skill");
        }
    }
}
