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
            var command = Console.ReadLine();
            if (command == "momo")
            {
                Console.WriteLine("You typed Momo");
                //Choose technique
            }
            else if (command != "momo")
            {
                Console.WriteLine("Error");
            }
        }
    }
}
