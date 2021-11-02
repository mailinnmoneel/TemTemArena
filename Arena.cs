using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    public class Arena
    {
        public bool IsRunning { get; private set; }
        public Arena()
        {
            IsRunning = true;
        }
        public void Stop()
        {
            IsRunning = false;
        }
        public void ShowGameInfo()
        {
            Console.WriteLine("************************");
            Console.WriteLine("Available commands are;");
            Console.WriteLine("Exit");
            Console.WriteLine("Nibble");
            Console.WriteLine("************************");
            
        }
     
    }
}
