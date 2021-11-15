using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;
using TemTemArena.Scripts.TemTems;

namespace TemTemArena
{
    public class Arena
    {
        public bool IsRunning { get; private set; }

        public Arena()
        {
            IsRunning = true;
        }
        public void TemTemBattle()
        {
            while (IsRunning)
            {
                ShowGameInfo();

                string command = GUI.ReadLine();
                if (command == "exit")
                {
                    Stop();
                    continue;
                }
                if (command == "target")
                {
                    var target = ChooseTarget(); //fikse denne før vi går videre

                }

                //else if (command == "attack")

                foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
                {
                    if (TemTem.Name == "Tateru")
                    {
                        var damage = TemTem.Attack();
                        CauseDamage(damage);

                    }
                    else if (TemTem.Name == "Nessla")
                    {
                        var damage = TemTem.Attack();
                        CauseDamage(damage);
                    }
                }
            }
        }

        private INPCTemTem ChooseTarget()
        {
            Combat.ChooseTarget(); //Printer ut navn på npc du kan velge mellom å attacker
            var target = GUI.ReadLine(); //Tar inn kommando 
            foreach (INPCTemTem npc in TemTemDex.TemTemListe.ActiveTemTems) //Looper igjennom npcène
            {
                if (npc.Name == target) return npc;
            }

            return null;
        }

        private void CauseDamage(float damage)
        {
            foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
            {
                if (TemTem.IsFainted) continue;
                TemTem.LooseHealth(damage);
            }
        }

        public void Stop() => IsRunning = false;

        public void ShowGameInfo()
        {
            GUI.WriteLine(EntryType.Command, Messages.AvailableCommands);
        }
    }
}