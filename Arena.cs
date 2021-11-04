using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        CauseDamage(damage, TemTem.IsNPC);
                    }
            }
        }

        private void CauseDamage(float damage, bool IsNPC)
        {
            foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
            {
                if (TemTem.IsFainted) continue;
                if (TemTem.IsNPC == IsNPC) continue;
                TemTem.LooseHealt(damage);
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }
        public void ShowGameInfo()
        {
            Console.WriteLine("************************");
            Console.WriteLine("Available commands are;");
            Console.WriteLine("Exit");
            Console.WriteLine("Attack");
            Console.WriteLine("************************");
            
        }
     
    }
}
