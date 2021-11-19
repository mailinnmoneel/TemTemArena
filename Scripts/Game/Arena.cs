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
    public class Arena
    {
        public bool IsRunning { get; private set; }

        private List<TemTem> _playerTemTems;
        private List<TemTem> _enemyTemTems;

        public IEnumerable<TemTem> PlayerTemTems => _playerTemTems;
        public IEnumerable<TemTem> EnemyTemTems => _enemyTemTems;



        public Arena()
        {
            TemTemDex.Instance.Arena = this;
            IsRunning = true;
            var Ganki = new TemTem(TemTemData.TemtemNames.Ganki);
            var Tateru = new TemTem(TemTemData.TemtemNames.Tateru);
        }
       
        
        public void Stop() => IsRunning = false;


        public void ShowGameInfo()
        {
            GUI.WriteLine(EntryType.Command, Messages.AvailableCommands);
        }

    
    }
}