using LeGrandRestaurant.personnes.employes;
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
        public void updateMenu(Menu menu)
        {
            this.menu = menu;
            Filliales.ForEach(x => x.menu = menu);
        }

        public Franchise(Menu menu)
        {
            this.menu = menu;
        }

        public Restaurant addFillialeRestaurant(MaitreHotel maitreHotel)
        {
            Restaurant filliale = new Restaurant(true, maitreHotel);
            filliale.menu = menu;
            Filliales.Add(filliale);
            return filliale;
        }

        public Restaurant addRestaurant(MaitreHotel maitreHotel)
        {
            Restaurant filliale = new Restaurant(false, maitreHotel);
            filliale.menu = menu;
            return filliale;
        }
    }
}
