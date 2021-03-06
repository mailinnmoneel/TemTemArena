using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemTemArena.Scripts.Abilities;

namespace TemTemArena
{
    public enum Ability
    {
        None,
        Basic,
        Nibble,
        HeavyBlow, 
        ChainLightning,
    }

    public class Techniques
    {
        static BasicAttack basicattack = new BasicAttack();
        static ChainLightning chainlightning = new ChainLightning();
        static Nibble nibble = new Nibble();
        static HeavyBlow heavyblow = new HeavyBlow();
        static TemTemTechniques[] techniques = { basicattack, chainlightning, nibble, heavyblow };

       //SKal liste opp tecniques
        protected internal static void TechniqueDictionary()
        {
            foreach (var technique in techniques)
            {
                technique.Run(); //Ikke ferdig
            }

        }

        public static Dictionary<Ability, string> abilityNames = new Dictionary<Ability, string>()
        {
            {Ability.Basic, "Basic Attack" },
            {Ability.Nibble, "Nibble" },
            {Ability.HeavyBlow, "Heavy Blow" },
            {Ability.ChainLightning, "Chain Lighting" },
        };

        public static float Use(Ability ability, float damage)
        {
            switch (ability)
            {
                case Ability.None  : return 0;
                case Ability.Basic : return Basic(damage);
                case Ability.Nibble: return Nibble(damage);
                case Ability.ChainLightning : return ChainLightning(damage);
                default: return Basic(damage);
            }
        }

        static float Basic(float damage)
        {
            return damage;
        }

        static float Nibble(float damage)
        {
            return damage * 1.5f;
        }

        static float ChainLightning(float damage)
        {
            return damage * damage;
        }
    }
}
