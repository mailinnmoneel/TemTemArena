using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using TemTemArena.Scripts.Abilities;
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

            #region Graphical User Interface
            //GUI.UseGUI();
            GUI.WriteLine(EntryType.Header, Messages.GameHeader);

            #endregion

            var arena = new Arena(); //-- Main, exit game, print info. 
            //var choose = new ChooseTargets(); //--Lar deg velge TemTem å slå på. 
            var combat = new Combat(); //--Velg Technique og gjør skade!
            var battle = new BattleCommands(); // --Attack
            //var attackGanki = new TargetCmndGanki(); // --Ganki
            //var attackMomo = new TargetCmndMomo(); //--Momo
            //Command[] commands = {battle, attackGanki, attackMomo,}; 
        
            TemTemBattle();

            #region CreateTemTems

            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Tateru", 79f, 78f, 85f, false)); //Neutral
            TemTemDex.TemTemListe.ActiveTemTems.Add(new Player("Nessla", 50f, 76f, 58f, false)); //Electric+ Water
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Momo", 75f, 46f, 64f, false)); //Normal
            TemTemDex.TemTemListe.ActiveTemTems.Add(new NPCTemTem("Ganki", 38f, 57f, 46f, false)); //Electric+Wind

            #endregion

            void TemTemBattle()
            { 
                arena.ShowGameInfo();
                while (arena.IsRunning)
                {
              
                    string command = GUI.ReadLine();
                    switch (command)
                    {
                        case "exit":
                            arena.Stop();
                            continue;
                        case "attack":
                            battle.Run();
                            LoopYourTemtem(combat); //bug
                            break;
                    }
                }

            }
        }

        private static void LoopYourTemtem(Combat combat)
        {
            foreach (var temTem in TemTemDex.TemTemListe.ActiveTemTems)
            {
                var temtem = (IYourTemTem) temTem;
                Console.WriteLine("You are in LoopYourTemtem");
                temtem.Name = Console.ReadLine();
                if (temtem.Name == "Tateru")
                {
                    Console.WriteLine("Choose a skill to use for Tateru");
                    var damage = temtem.AttackNpc();
                    combat.CauseDamage(damage);
                }
                else if (temtem.Name == "Nessla")
                {
                    Console.WriteLine("Choose a skill to use for Nessla");
                    var damage = temtem.AttackNpc();
                    combat.CauseDamage(damage);
                }
            }
        }
    }
}
