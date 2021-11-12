using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;

namespace TemTemArena
{
    public class Combat
    {
        public static Ability ChooseAbility(List<Ability> abilities)
        {
            string availableabilities = "";
            var i = 1;
            foreach (var normalattaks in abilities)
            {
                var ability = Techniques.abilityNames[normalattaks];
                availableabilities += $"{i}) {ability}\n";
                i++;
            }

            bool ChooseAbility = false;
            while (!ChooseAbility)
            {
                var messages = new string[3];
                messages[0] = "Available attacks actions are:";
                messages[1] = availableabilities;
                messages[2] = "Choose ability 1, 2 or 3";
                Game.Manager.Renderer.AddMessage(Align.Left, messages);

                //Console.WriteLine("Available attacks actions are:");
                //Console.WriteLine(availableabilities);
                //Console.WriteLine("Choose ability 1, 2 or 3");


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
