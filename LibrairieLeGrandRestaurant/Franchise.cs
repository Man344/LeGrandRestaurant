using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        public List<Restaurant> Filliales { get; private set; } = new List<Restaurant>();

        public Menu menu { get; private set; }
        public void setMenu(Menu menu)
        {
            this.menu = menu;
            Filliales.ForEach(x => x.menu = menu);
        }

        public Franchise(Menu menu)
        {
            this.menu = menu;
        }

        public Restaurant addFillialeRestaurant()
        {
            Restaurant filliale = new Restaurant(true);
            filliale.menu = menu;
            Filliales.Add(filliale);
            return filliale;
        }

        public Restaurant addRestaurant()
        {
            Restaurant filliale = new Restaurant(false);
            filliale.menu = menu;
            return filliale;
        }
    }
}
