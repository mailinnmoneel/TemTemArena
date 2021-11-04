using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    public static class Combat
    {
        public static Ability ChooseAbility(List<Ability> abilities)
        {
            #region Oppskrift
            //-- Lag en ny tom string availableAbilities


            //-- Loop gjennom alle Ability's i listen abilities
            //-- Og legg til hver ability på stringen availableAbilities


            /*   Skrive ut alle mulige abilities til brukeren med Console.WriteLine(availableAbilities);
                 1) Basic Attack
                 2) Nibble
                 3) ChainLightning
            */


            //-- Bruk Console.ReadLine for å la brukeren bestemme hvilken ability som skal velges


            //-- Les input. F.eks 1, 2 eller 3


            //-- Om input stemmer med en av de  mulige abilities. Returnere denne abilities.
            //-- return abilities[input - 1];
            #endregion


            string availableabilities = "";
            var i = 1;
            foreach (var normalattaks in abilities)
            {
                var ability = Techniques.abilityNames[normalattaks];
                availableabilities += $"{i}) {ability}\n";
                i++;
            }

            bool selectedAnAbility = false;

            while (!selectedAnAbility)
            {
                Console.WriteLine("Available attacks actions are:");
                Console.WriteLine(availableabilities);
                Console.WriteLine("Choose ability 1, 2 or 3");
                var selectedAbility = Console.ReadLine();

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
