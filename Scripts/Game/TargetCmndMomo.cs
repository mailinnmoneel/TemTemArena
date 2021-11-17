using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Game
{
    class TargetCmndMomo : Command
    {
        public TargetCmndMomo() 
            : base("Target", "momo")
        {
        }

        public override void Run()
        {
            Console.WriteLine("Choose which technique to use on Momo");
            Techniques.TechniqueDictionary();
        }
    }
}
