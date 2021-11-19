using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.Data
{
    public static class TemTemData
    {
        public enum Technniques
        {
            Nibble, 
            ChainLightning,
            Bubbles, 
            HeavyBlow,
            Scratch,
        }

        public enum TemtemNames
        {
            Ganki, 
            Tateru, 
            Nessla,
            Momo,
        }

        public static readonly Dictionary<TemtemNames, float> TemTemDamage = new Dictionary<TemtemNames, float>()
        {
            {TemtemNames.Ganki, 10f},
            {TemtemNames.Tateru, 15f},
            {TemtemNames.Nessla, 15f},
            {TemtemNames.Momo, 15f},
        };

        public static readonly Dictionary<TemtemNames, float> TemTemHealth = new Dictionary<TemtemNames, float>()
        {
            {TemtemNames.Ganki, 50f},
            {TemtemNames.Tateru, 65f},
            {TemtemNames.Nessla, 65f},
            {TemtemNames.Momo, 65f},
        };

        public static readonly Dictionary<TemtemNames, string> TemTemNames = new Dictionary<TemtemNames, string>()
        {
            {TemtemNames.Ganki, "Ganki"},
            {TemtemNames.Tateru, "Tateru"},
            {TemtemNames.Nessla, "Nessla"},
            {TemtemNames.Momo, "Momo"},
        };


        public static readonly Dictionary<TemtemNames, Technniques[]> TemTemAbilities = new Dictionary<TemtemNames, Technniques[]>()
        {
            {
                TemtemNames.Ganki, new Technniques[]
                {
                    Technniques.Nibble,
                    Technniques.ChainLightning,
                }
            },
            {
                TemtemNames.Tateru, new Technniques[]
                {
                    Technniques.Nibble,
                    Technniques.HeavyBlow,
                }
            },
            {
                TemtemNames.Nessla, new Technniques[]
                {
                    Technniques.Bubbles,
                    Technniques.ChainLightning,
                }
            },
            {
                TemtemNames.Momo, new Technniques[]
                {
                    Technniques.Scratch,
                    Technniques.HeavyBlow,
                }
            },
        };
    }
}
