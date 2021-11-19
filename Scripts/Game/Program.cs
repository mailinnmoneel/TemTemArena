using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

            var arena = new Arena(); //-- Main

        }
    }
}
