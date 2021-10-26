using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    class Tateru : ITemTem
    {

        public float Health { get; set; }
        public float Damage { get; set; }
        public float Stamina { get; set; }
        public bool IsFainted { get; set; }

        public string Name;
    
        //Constructor
        public Tateru(string name, float health, float damage, float stamina)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Stamina = stamina;
        }
        public void PrintInfo(string extrainfo)//Denne var bare en øvelse på ovverride
        {
            Console.WriteLine(Name + extrainfo);
        }
        public float Nibble()
        {
            Console.WriteLine( Name + " used Nibble! It did " +  Damage + " Damage!");
            return Damage;
        }

        public void LooseHealt(float damage)
        {
            Console.WriteLine("Tateru lost healt");
        }
        public void Recharge()
        {
            //if(stamina < 20)
            //Stamina = 40
            Console.WriteLine("Tateru used Recharge! Stamina is now " + Stamina);
        }
    }
}
