using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Game
{
    class BattleCommands : Command
    {
        public BattleCommands() 
            : base( "Battle", "Attack" )
        {
        }

        public override void Run()
        {
            var command = Console.ReadLine();
            if (command == "attack")
            {
                Console.WriteLine("You typed Attack");
                //Choose TemTem to hit 
            }
            else if(command != "attack")
            {
                Console.WriteLine("Error");
            }
        }
    }
}
