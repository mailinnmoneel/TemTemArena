using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena
{
    public abstract class TemTem
    {
        public string Name { get; set; } 
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Stamina { get; set; }
        public bool IsFainted { get; set; }

        protected List<Ability> AbilityNormal = new List<Ability>();

        public TemTem(string name, float health, float damage, float stamina, bool isFainted)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Stamina = stamina;
            IsFainted = isFainted;
            AbilityNormal.Add(Ability.Basic); 
            AbilityNormal.Add(Ability.Nibble); 
            AbilityNormal.Add(Ability.HeavyBlow); 
        }

        public virtual float Attack()
        {
            return 0;
        }
        
        public void LooseHealth(float damage)
        {
            Health -= damage;

            var message = $"{Name} lost {damage} health";
            Game.Manager.Renderer.AddMessage(Align.Left, message);
        }
        public void Recharge()
        {
            Stamina += 50f;
            var message = $"{Name} used Recharge! Stamina is now {Stamina}";
            Game.Manager.Renderer.AddMessage(Align.Left, message);
        }

    }
}
