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


        public Franchise(Restaurant[] restaurants)
        {
            _menu = new Menu();
            for(int i = 0; i < restaurants.Length; i++)
            {
                restaurants[i].ImposerMenu(_menu);
            }
            
        }

        public void FixerPrix(Plat plat, decimal nouveauPrix)
            => _menu.FixerPrix(plat, nouveauPrix);
    }
}
