using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena.Scripts.TemTems
{
    public class Player : TemTem, IYourTemTem
    {
        public Player(string name, float health, float damage, float stamina, bool isFainted) : base(name, health, damage, stamina, isFainted)
        {

        }
        public override float Attack()
        {
            var chosenTechnique = PickTechnique();

            float damage = 0;
            Ability ability = Ability.None;

            //ability = Combat.ChooseAbility(AbilityNormal);
            //damage = Techniques.Use(ability, Damage);
            
            //damage = Techniques.Use(Ability.Basic, Damage);

            var message = $"{Name} used {ability}. It did {damage} damage!";
            Game.Manager.Renderer.AddMessage(Align.Left, message);
            return damage;
        }

        private Ability PickTechnique()
        {
            var input = Console.ReadLine();

            //--Do something here and return correct Technique;

            return Ability.None;
        }
    }
}
