using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena.Scripts.TemTems
{
    public class NPCTemTem : TemTem, INPCTemTem
    {
        public NPCTemTem(string name, float health, float damage, float stamina, bool isFainted) : base(name, health, damage, isFainted)
        {

        }
        public float Attack()
        {
            Ability ability = ChooseAITechnique();

            var damage = Techniques.Use(ability, Damage);

            var message = $"{Name} used {ability}. It did {damage} damage!";
            GUI.GUI.WriteLine(EntryType.Combat, message, true);
            return damage;
        }
    
        private Ability ChooseAITechnique()
        {
            List<Ability> abilities = new List<Ability>();
            abilities.Add(Ability.Basic);
            abilities.Add(Ability.Nibble);
            abilities.Add(Ability.HeavyBlow);
            abilities.Add(Ability.ChainLightning);

            var numberOfAbilities = abilities.Count;
            Random random = new Random();
            var index = random.Next(0, numberOfAbilities);

            return abilities[index];
        }
    }
}