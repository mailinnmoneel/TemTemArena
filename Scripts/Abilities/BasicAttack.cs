using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Abilities;

namespace TemTemArena 
{
    public class BasicAttack : TemTemTechniques
    {
        public BasicAttack() : base("Basic Attack")
        {

        }

        public override void Run()
        {
            //Bruke Basic Attack
        }

        public override void Info()
        {
            Console.WriteLine("BAsic Attack + some info on this technique");
        }
    }
}
