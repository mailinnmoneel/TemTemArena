using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena.Scripts.TemTems
{
    public class NPCTemTem : TemTem, INPCTemTem
    {
        public NPCTemTem(string name, float health, float damage, float stamina, bool isFainted) : base(name, health, damage, stamina, isFainted)
        {

        }
        public override float Attack()
        {
            var chosenTechnique = ChooseAITechnique();

            float damage = 0;
            Ability ability = Ability.None;

            //ability = Combat.ChooseAbility(AbilityNormal);
            //damage = Techniques.Use(ability, Damage);

            //damage = Techniques.Use(Ability.Basic, Damage);

            var message = $"{Name} used {ability}. It did {damage} damage!";
            Game.Manager.Renderer.AddMessage(Align.Left, message);
            return damage;
        }
    
        private Ability ChooseAITechnique()
        {
            List<Ability> abilities = new List<Ability>();
            abilities.Add(Ability.Basic);
            abilities.Add(Ability.Nibble);
            abilities.Add(Ability.HeavyBlow);

            var numberOfAbilities = abilities.Count;
            Random random = new Random();
            var index = random.Next(0, numberOfAbilities);

            return abilities[index];
        }
    }
}