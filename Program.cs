using System;
using System.Collections.Generic;

namespace TemTemArena
{
    class Program
    {
        public static bool GameOver { get; private set; }

        static void Main(string[] args)
        {

            Arena arena = new Arena();
            arena.StartGameInfo();

            //List<ITemTem> activeTemTems = new List<ITemTem>();
            //List<NPCTemTem> npctemtems = new List<NPCTemTem>();

            //activeTemTems.Add(new Tateru("Tateru", 78.5f, 20.5f, 85f));
            //activeTemTems.Add(new Ganki("Ganki", 78.5f, 50.5f, 98f));

            Tateru tateru = new Tateru("Tateru", 78.5f, 20.5f, 85f);
            Ganki ganki = new Ganki("Ganki", 78.5f, 50.5f, 98f);

            tateru.PrintInfo(" is your TemTem against " + ganki.Name);

            while (GameOver == false)
            {
                Console.WriteLine("Enter input:");
                string Line = Console.ReadLine();
                if (Line == "exit")
                {
                    break;
                }
                Console.WriteLine("You typed " + Line);
                if (Line == "nibble")
                {
                    tateru.Nibble();
                    ganki.Attack();
                }
            }
        }
    
    }
}
