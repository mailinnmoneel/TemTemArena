using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    public class TemTem : ITemTem
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Stamina { get; set; }
        public bool IsFainted { get; set; }
        public bool IsNPC { get; set; }

        public TemTem(string name, float health, float damage, float stamina, bool isFainted, bool isnpc)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Stamina = stamina;
            IsFainted = isFainted;
            IsNPC = isnpc;
        }
        
        public void LooseHealt(float damage)
        {
            Health = -damage;
            Console.WriteLine(Name + " lost " + damage);
        }

        public void Recharge()
        {
            Stamina += 50f;
            Console.WriteLine($"{Name} used Recharge! Stamina is now {Stamina}");
        }

        public void Attack()
        {
            Console.WriteLine(Name + " used Attack! It did " + Damage + " Damage!");
        }
    }
}
