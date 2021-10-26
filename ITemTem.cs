using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    public interface ITemTem
    {
        float Health { get; set; }
        float Damage { get; set; }
        float Stamina { get; set; }
        bool IsFainted { get; set; }
        void LooseHealt(float damage);
        void Recharge();
       
    }
}
