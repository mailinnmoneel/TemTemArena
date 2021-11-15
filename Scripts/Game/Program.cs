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
            //GUI.CreateGUI();

            GUI.WriteLine(EntryType.Header, Messages.GameHeader);
            #endregion

            Arena arena = new Arena(); //-- Main Game Controller

            #region CreateTemTems
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Tateru", 79f, 78f, 85f, false)); //Neutral
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Nessla", 50f, 76f, 58f, false)); //Electric+ Water
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Momo", 75f, 46f, 64f, false)); //Normal
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Ganki", 38f, 57f, 46f, false)); //Electric+Wind
            #endregion

            arena.TemTemBattle();

        
        }
    }
}
