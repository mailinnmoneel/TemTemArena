using System;
using System.Collections.Generic;
using System.Drawing;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Game;
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

            Arena arena = new Arena(); //-- Main, start, stopp spill, print info. 
            ChooseTargets choose = new ChooseTargets(); //--Lar deg velge TemTem å slå på. 
            Combat combat = new Combat(); //--Velg Technique og gjør skade!
            TemTemBattle();

            #region CreateTemTems

            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Tateru", 79f, 78f, 85f, false)); //Neutral
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Nessla", 50f, 76f, 58f, false)); //Electric+ Water
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Momo", 75f, 46f, 64f, false)); //Normal
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Ganki", 38f, 57f, 46f, false)); //Electric+Wind

            #endregion

            void TemTemBattle()
            {
                while (arena.IsRunning)
                {
                    arena.ShowGameInfo();

                    string command = GUI.ReadLine();
                    if (command == "exit")
                    {
                        arena.Stop();
                        continue;
                    }

                    if (command == "target")
                    {
                        //bug
                        var target = choose.Run();

                    }

                    //else if (command == "attack")
                    //Du sloss med 2 TemTem, programmet vil kjøre igjennom begge to og be deg velge handling per TemTem
                    foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems) 
                    {
                        if (TemTem.Name == "Tateru")
                        {
                            var damage = TemTem.Attack();
                            combat.CauseDamage(damage);

                        }
                        else if (TemTem.Name == "Nessla")
                        {
                            var damage = TemTem.Attack();
                            combat.CauseDamage(damage);
                        }
                    }
                }

            }
        }
    }
}
