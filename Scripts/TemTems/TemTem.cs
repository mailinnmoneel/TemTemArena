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
    public class TemTem
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }

        public bool IsFainted { get; set; } = false;

        private TemTemData.Technniques[] availableAbilities;
        
        public TemTem(TemTemData.TemtemNames temTemName)
        {
            availableAbilities = TemTemData.TemTemAbilities[temTemName];
            Name = TemTemData.TemTemNames[temTemName];
            Health = TemTemData.TemTemHealth[temTemName];
            Damage = TemTemData.TemTemDamage[temTemName];
        }

        public void ListAbilities()
        {
            foreach (var ability in availableAbilities)
            {
                GUI.WriteLine(EntryType.Header, $"{ability}");
            }
        }

        public void LooseHealth(float damage)
        {
            Health -= damage;
            var message = $"{Name} lost {damage} health";
            GUI.WriteLine(EntryType.Combat, message, true);
        }

        public object GetAbilities()
        {
            throw new NotImplementedException();
        }
    }
}
