using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.test.Builder
{
    public class TableBuilder
    {
        private bool _EstLibre;

        //public TableBuilder EstOccupée()
        //{
        //    _EstLibre = true;
        //    return this;
        //}

        public Table BuildEnMemoire()
        {
            return new Table(new StockageEtatTableMemoire());
        }

        public Table BuildAPlat()
        {
            return new Table(new StockageEtatTablePlat());
        }
    }
}
