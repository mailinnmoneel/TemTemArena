using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    public interface ITemTem
    {
        public string Name { get; set; }
        float Health { get; set; }
        float Damage { get; set; }
        float Stamina { get; set; }
        bool IsFainted { get; set; }
        bool IsNPC { get; set; }
        void LooseHealt(float damage);
        void Recharge();
        void Attack();
    }
}
