using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Game
{
    public abstract class Command
    {
        public string Description { get; }
        public string Input { get; }
        public abstract void Run();
        protected Command(string description, string input)
        {
            Description = description;
            Input = input;
        }
    }
}
