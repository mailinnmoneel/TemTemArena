using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.GUI;
using TemTemArena.Scripts.Singletons;
using TemTemArena.Scripts.TemTems;

namespace TemTemArena
{
    public class Combat
    {
        public void CauseDamage(float damage)
        {
            foreach (var TemTem in TemTemDex.TemTemListe.ActiveTemTems)
            {
                if (TemTem.IsFainted) continue;
                TemTem.LooseHealth(damage);
            }
        }

        //nb
        public static Ability ChooseAbility(List<Ability> abilities)
        {
            string[] availableabilities = new string[abilities.Count];
            var i = 1;
            foreach (var normalattaks in abilities)
            {
                var ability = Techniques.abilityNames[normalattaks];
                availableabilities[i - 1] += $"{i}) {ability}";
                i++;
            }

            bool ChooseAbility = false;
            while (!ChooseAbility)
            {
               string[] message = GUI.CreateMessage(availableabilities);
               GUI.WriteLine(EntryType.Command, message, true);

               var selectedAbility = GUI.ReadLine();
               var success = Int32.TryParse(selectedAbility, out int index);

               if (success)
               {
                   if (index > 0 && index <= abilities.Count)
                   {
                       return abilities[index - 1];
                   }
               }
            }
            return Ability.None;
        }
    }
}

