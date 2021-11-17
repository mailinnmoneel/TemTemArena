using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Game
{
    class TargetCmndGanki : Command
    {
        public TargetCmndGanki() 
            : base("Target", "ganki")
        {
        }

        public override void Run()
        {
            var command = Console.ReadLine();
            if (command == "ganki")
            {
                Console.WriteLine("You typed Ganki");
                //Choose technique
            }
            else if (command != "ganki")
            {
                Console.WriteLine("Error");
            }
        }
    }
}
