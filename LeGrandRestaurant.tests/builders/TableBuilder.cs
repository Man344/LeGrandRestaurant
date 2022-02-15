using LeGrandRestaurant.etats.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.tests.builders
{
    public static class TableBuilder
    {
        public static Table BuildEnMemoire()
        {
            return new Table(new StockageEtatTableMemoire());
        }

        public static Table BuildAPlat()
        {
            return new Table(new StockageEtatTablePlat());
        }
    }
}
