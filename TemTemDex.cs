using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena
{
    class TemTemDex
    {
    
     //Singleton
     public static TemTemDex TemTemListe { get; } = new TemTemDex();
     private List<ITemTem> _temTems;
     public List<ITemTem> ActiveTemTems => _temTems ??= new List<ITemTem>();
        
    }
}
