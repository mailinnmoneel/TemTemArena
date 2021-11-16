using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.TemTems;

namespace TemTemArena.Scripts.Game
{
    class ChooseTargets
    {
      
        public INPCTemTem Run()
        {
            FindTarget(); 
            var target = GUI.ReadLine();  
            foreach (INPCTemTem npc in TemTemDex.TemTemListe.ActiveTemTems) 
            {
                if (npc.Name == target) return npc;
            }

            return null;
        }
        public static void FindTarget()
        {
            var index = 0;
            string[] AvailableTargets = new string[20];
            foreach (INPCTemTem npc in TemTemDex.TemTemListe.ActiveTemTems) //Loop NPC og print navnene til konsollen
            {
                AvailableTargets[index] = npc.Name;
                index++;
            }
            GUI.WriteLine(EntryType.Command, AvailableTargets);
        }
    }
}
