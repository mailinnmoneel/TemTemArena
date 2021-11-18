using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Abilities;
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
        //public float Stamina { get; set; }
        public bool IsFainted { get; set; }

        //protected List<Ability> AbilityList = new List<Ability>();
    
    protected TemTem(string name, float health, float damage, bool isFainted)
        {
            Name = name;
            Health = health;
            Damage = damage;
            //Stamina = stamina;
            IsFainted = isFainted;
            //AbilityList.Add(Ability.Basic);
            //AbilityList.Add(Ability.Nibble);
            //AbilityList.Add(Ability.HeavyBlow);
        }

      

        public void LooseHealth(float damage)
        {
            Health -= damage;

            var message = $"{Name} lost {damage} health";
            GUI.WriteLine(EntryType.Combat, message, true);
        }
        /*
        public void Recharge()
        {
            Stamina += 50f;
            var message = $"{Name} used Recharge! Stamina is now {Stamina}";
            GUI.WriteLine(EntryType.Combat, message, true);

        }
        */
        //public abstract float Attack();
    }
}
