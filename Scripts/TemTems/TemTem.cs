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
    public class TemTem : ITemTem
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Stamina { get; set; }
        public bool IsFainted { get; set; }
        public bool IsNPC { get; set; }

        private List<Ability> AbilityNormal = new List<Ability>();

        public TemTem(string name, float health, float damage, float stamina, bool isFainted, bool isnpc)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Stamina = stamina;
            IsFainted = isFainted;
            IsNPC = isnpc;
            AbilityNormal.Add(Ability.Basic); //
            AbilityNormal.Add(Ability.Nibble); //
            AbilityNormal.Add(Ability.HeavyBlow); //
        }

        public float Attack()
        {
            float damage = 0;
            Ability ability = Ability.None;

            if (!IsNPC)
            {
                ability = Combat.ChooseAbility(AbilityNormal);
                damage = Techniques.Use(ability, Damage);
            }
            else
            {
                damage = Techniques.Use(Ability.Basic, Damage);
            }

            var message = $"{Name} used {ability}. It did {damage} damage!";
            Game.Manager.Renderer.AddMessage(Align.Left, message);
            return damage;
        }
        public void LooseHealth(float damage)
        {
            Health = -damage;

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
