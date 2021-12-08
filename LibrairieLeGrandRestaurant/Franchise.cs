using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        private readonly Menu _menu;

        public Franchise(Restaurant restaurant)
        {
            _menu = new Menu();
            restaurant.ImposerMenu(_menu);
        }

        public void FixerPrix(Plat plat, decimal nouveauPrix)
            => _menu.FixerPrix(plat, nouveauPrix);
    }
}
