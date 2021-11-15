﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
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
            var ability = PickTechnique();

            var damage = Techniques.Use(ability, Damage);

            var message = $"{Name} used {ability}. It did {damage} damage!";
            GUI.GUI.WriteLine(EntryType.Combat, message, true);
            return damage;
        }

        private Ability PickTechnique()
        {
            return Combat.ChooseAbility(AbilityNormal);
        }
    }
}
