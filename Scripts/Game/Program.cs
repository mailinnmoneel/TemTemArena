using System;
using System.Collections.Generic;
using System.Drawing;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;
using TemTemArena.Scripts.TemTems;

namespace TemTemArena
{
    class Program
    {
        static void Main(string[] args)
        {
            var useGUI = true;
            Game.Manager.Renderer = new GUIRenderer(useGUI);
            Game.Manager.Renderer.PrintAllSymbols();
            Game.Manager.Renderer.AddMessage(Align.Left, Messages.Welcome);

            Arena arena = new Arena();

            #region CreateTemTems
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Tateru", 78.5f, 20.5f, 85f, false));
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Ganki", 78.5f, 50.5f, 98f, false));
            #endregion
      
            arena.TemTemBattle();

            //1. Stelle ITemtem
            //2. Lage to nye temtemklasser som arver fra TemTem
            //3. Lage to nye interface, 1 for dine TemTems og en for NPCTemTem
        }
    }
}
