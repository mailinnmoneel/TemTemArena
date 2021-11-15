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
        //-- ASCII SYMBOLS
        //-- https://www.alt-codes.net/
        static void Main(string[] args)
        {
            #region Instantiate Controller Classes
            Game.Manager.EventLog = new EventLog();
            Game.Manager.ScreenBuffer = new ScreenBuffer();
            Game.Manager.Renderer = new GUIRenderer();
            Game.Manager.Renderer.Preview();

            GUI.AddEntry(EntryType.Header, Messages.GameHeader);
            GUI.Refresh();
            #endregion

            Arena arena = new Arena(); //-- Main Game Controller

            #region CreateTemTems
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Tateru", 79f, 78f, 85f, false)); //Neutral
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Nessla", 50f, 76f, 58f, false)); //Electric+ Water
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Deendre", 75f, 48f, 42f, false)); //Neutral
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Momo", 75f, 46f, 64f, false)); //Normal
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Ganki", 38f, 57f, 46f, false)); //Electriv+Wind
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Oceara", 64f, 54f, 42f, false)); //Water
            #endregion

            arena.TemTemBattle();

        
        }
    }
}
