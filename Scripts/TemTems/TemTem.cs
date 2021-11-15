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
    //Hovedklassen som PLayer og NPC arver ifra
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
            AbilityNormal.Add(Ability.Basic); //Vi vil endre på dette, Burde ligge et annet sted
            AbilityNormal.Add(Ability.Nibble);
            AbilityNormal.Add(Ability.HeavyBlow);
            AbilityNormal.Add(Ability.ChainLightning);
        }

        public virtual float Attack()
        {
            return 0;
        }

        public void LooseHealth(float damage)
        {
            Health -= damage;

            var message = $"{Name} lost {damage} health";
            GUI.WriteLine(EntryType.Combat, message, true);
        }

        //Hvis stamina er 0 så mister de HP
        public void Recharge() //Ikke i bruk enda, kan brukes hvis TemTem står over en tur, autoregen stamina ved rest
        {
            Stamina += 10f;
            var message = $"{Name} took a rest this turn. Stamina is now {Stamina}";
            GUI.WriteLine(EntryType.Combat, message, true);

        }
    }
}
