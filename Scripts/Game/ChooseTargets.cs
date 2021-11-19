using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena.Scripts.Game
{
    class ChooseTargets
    {
      /*
        public static INPCTemTem Run()
        {
            FindTarget(); //Loop NPC og print navnene til konsollen
            Console.WriteLine("You are in ChooseTargets.Run();");//bug
            var target = GUI.GUI.ReadLine(); 
            foreach (INPCTemTem npc in TemTemDex.TemTemListe.ActiveTemTems) 
            {
                if (npc.Name == target) return npc;
            }

            return null;
        }
        public static void FindTarget()
        {
            var index = 0;
            string[] AvailableTargets = new string[5];
            foreach (INPCTemTem npc in TemTemDex.TemTemListe.ActiveTemTems) 
            {
                AvailableTargets[index] = npc.Name;
                index++;
            }
            GUI.GUI.WriteLine(EntryType.Command, AvailableTargets);
        }
      */
    }
}
