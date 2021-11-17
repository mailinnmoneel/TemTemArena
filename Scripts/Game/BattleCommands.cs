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
            Console.WriteLine("Choose TemTem to attack");
            ChooseTargets.Run();
        }
    }
}
