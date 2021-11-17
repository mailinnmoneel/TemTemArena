using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Abilities
{
    public abstract class TemTemTechniques
    {
       
        public string Technique { get; }
        public abstract void Run();
        public abstract void Info();
        protected TemTemTechniques(string technique)
        {
            Technique = technique;
        }
    }
}
