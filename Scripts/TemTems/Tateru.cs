using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    [Obsolete("TemTem.cs brukes i stedet")]
    class Tateru
    {

        public float Health { get; set; }
        public float Damage { get; set; }
        public float Stamina { get; set; }
        public bool IsFainted { get; set; }
        public bool IsNPC { get; set; }
        public string Name { get; set; }

        public Tateru(string name, float health, float damage, float stamina)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Stamina = stamina;
        }
        public void Attack()
        {
            Nibble();
        }
        public float Nibble()
        {
            Console.WriteLine( Name + " used Nibble! It did " +  Damage + " Damage!");
            return Damage;
        }

        public void LooseHealt(float damage)
        {
            Health =- damage;
            Console.WriteLine( Name + " lost " + damage);
        }
        public void Recharge()
        {
            Stamina += 50f;
            Console.WriteLine($"{Name} used Recharge! Stamina is now {Stamina}");
        }
    }
}
