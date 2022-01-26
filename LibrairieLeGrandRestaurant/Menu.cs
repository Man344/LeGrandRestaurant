using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    //carte de menus d'un restaurant
    public class Menu
    {
        public List<Plat> plats;
        public List<Boisson> boisson;

        public Menu()
        {
            plats = new List<Plat>();
            boisson = new List<Boisson>();
        }

        public double getPrix()
        {
            double total = 0;
            foreach (var item in plats)
            {
                total += item.prix;
            }
            foreach (var item in boisson)
            {
                total += item.prix;
            }
            return total;
        }
    }
}
