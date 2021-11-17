using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Game;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;
using TemTemArena.Scripts.TemTems;

namespace TemTemArena
{
    public class Arena : Command
    {
        public bool IsRunning { get; private set; }

        public Arena() : base("Exit Game", "exit")
        {
            IsRunning = true;
        }
        public override void Run()
        {
            IsRunning = false;
        }

        //public void Stop() => IsRunning = false;

        public void ShowGameInfo()
        {
            GUI.WriteLine(EntryType.Command, Messages.AvailableCommands);
        }

    
    }
}