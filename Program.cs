using System;
using System.Collections.Generic;

namespace TemTemArena
{
    class Program
    {
   
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TemTem Arena!");
            Arena arena = new Arena();

            #region CreateTemTems
            TemTemDex.TemTemListe.ActiveTemTems.Add(new TemTem("Tateru", 78.5f, 20.5f, 85f, false, false));
            TemTemDex.TemTemListe.ActiveTemTems.Add(new TemTem("Ganki", 78.5f, 50.5f, 98f, false, true));
            #endregion
      
            arena.TemTemBattle();
        }
    }
}
