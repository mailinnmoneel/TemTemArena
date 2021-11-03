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
                else if (command == "nibble")
                    foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
                    {
                        TemTem.Attack();
                        //TemTem.LooseHealt(float damage);
                    }

                foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
                {
                    if (TemTem.IsNPC)
                    {
                        Console.WriteLine(TemTem.Name + "s remaining Health is " + TemTem.Health);
                    }
                    else Console.WriteLine(TemTem.Name + "s remaining Health is " + TemTem.Health);
                }
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
            Console.WriteLine("Nibble");
            Console.WriteLine("************************");
            
        }
     
    }
}
