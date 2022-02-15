using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.etats.table
{
    public interface IEtatTable
    {
        public bool EstLibre { get; set; }
        public bool EstAssociee { get; set; }
    }
}
