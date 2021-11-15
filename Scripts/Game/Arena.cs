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

                string command = Console.ReadLine();
                if (command == "exit") Stop();
                else if (command == "attack")
                    foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
                    {
                        var damage = TemTem.Attack();
                        CauseDamage(damage);
                    }

                Console.Read();
                //-- Force Gameloop to pause before next pass. Otherwise screen gets cleared of all info. Need a better method to handle this
            }
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
            GUI.Refresh();
        }
    }
}
