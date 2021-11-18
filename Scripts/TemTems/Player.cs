using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Abilities;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena.Scripts.TemTems
{
    public class Player : TemTem, IYourTemTem
    {
      public Player(string name, float health, float damage, float stamina, bool isFainted) : base(name, health, damage, isFainted)
        {

        }

      public float AttackNpc()
      {
          var ability = PickTechnique();

          var damage = Techniques.Use(ability, Damage);

          var message = $"{Name} used {ability}. It did {damage} damage!";
          GUI.GUI.WriteLine(EntryType.Combat, message, true);
          return damage;
      }
        private Ability PickTechnique()
        {
            //pickTarget
            //attackMomo.Run();
            //attackGanki.Run();
            var basicattack = new BasicAttack();
            var chainlightning = new ChainLightning();
            var nibble = new Nibble();
            TemTemTechniques[] techniques = { basicattack, chainlightning, nibble };
            foreach (var technique in techniques)
            {
                technique.Run();
            }

            return 0;
            //return Combat.ChooseAbility(AbilityList);
        }

 
    }
}
