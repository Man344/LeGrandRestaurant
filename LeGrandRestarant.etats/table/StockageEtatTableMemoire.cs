using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.etats.table
{
    public class StockageEtatTableMemoire : IEtatTable
    {
        public bool EstLibre { get; set; } = true;
        public bool EstAssociee { get; set; }
    }
}
