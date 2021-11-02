using System;
using System.Collections.Generic;

namespace TemTemArena
{
    class Program
    {
        //public static bool GameOver { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TemTem Arena!");
            Arena arena = new Arena();

            List<ITemTem> activeTemTems = new List<ITemTem>(); 
            activeTemTems.Add(new Tateru("Tateru", 78.5f, 20.5f, 85f)); 
            activeTemTems.Add(new Ganki("Ganki", 78.5f, 50.5f, 98f));

            ITemTem myTemTem = activeTemTems[0];
            ITemTem npcTemTem = activeTemTems[1];
            Console.WriteLine(myTemTem.Name + " Is your TemTem against " + npcTemTem.Name);

            TemTemBattle(arena, activeTemTems, myTemTem, npcTemTem);
        }

        private static void TemTemBattle(Arena arena, List<ITemTem> activeTemTems, ITemTem myTemTem, ITemTem npcTemTem)
        {
            while (arena.IsRunning)
            {
                arena.ShowGameInfo();
                string command = Console.ReadLine();
                if (command == "exit") arena.Stop();
                else if (command == "nibble")
                    foreach (var TemTem in activeTemTems)
                    {
                        TemTem.Attack();
                    }

                Console.WriteLine("Tateru`s remaining Health is " + myTemTem.Health);
                Console.WriteLine("Ganki`s remaining Health is " + npcTemTem.Health);
            }
        }
    }
}
