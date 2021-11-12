using System;
using System.Collections.Generic;
using System.Drawing;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Manager.Renderer = new GUIRenderer();
            Game.Manager.Renderer.PrintAllSymbols();
            Game.Manager.Renderer.AddMessage(Align.Left, Messages.Welcome);

            Arena arena = new Arena();

            #region CreateTemTems
            TemTemDex.TemTemListe.ActiveTemTems.Add(new TemTem("Tateru", 78.5f, 20.5f, 85f, false, false));
            TemTemDex.TemTemListe.ActiveTemTems.Add(new TemTem("Ganki", 78.5f, 50.5f, 98f, false, true));
            #endregion
      
            arena.TemTemBattle();
        }
    }
}
