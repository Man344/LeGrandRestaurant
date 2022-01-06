using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.test
{
    public class MenusTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise " +
                            "QUAND la franchise modifie le prix du plat au menu " +
                            "ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise")]
        public void CarteFranchise()
        {
            // ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
            var plat = new Plat("ratatouille", 8.5);
            Menu menu = new Menu();
            menu.plats.Add(plat);

            Franchise franchise = new Franchise(menu);
            Restaurant filiale = franchise.addFillialeRestaurant();

            // QUAND la franchise modifie le prix du plat
            double prix = 9;
            Menu menuWithNewPLat = new Menu();
            menuWithNewPLat.plats.Add(new Plat("ratatouille", prix));
            franchise.setMenu(menuWithNewPLat);


            // ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            Assert.Equal(prix, filiale.menu.plats.First().prix);
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat " +
                            "QUAND la franchise modifie le prix du plat " +
                            "ALORS le prix du plat dans le menu du restaurant reste inchangé")]
        public void ConflitRestaurantFranchise()
        {
            //ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var plat = new Plat("ratatouille", 8.5);
            Menu menu = new Menu();
            menu.plats.Add(plat);

            Franchise franchise = new Franchise(menu);
            Restaurant filiale = franchise.addRestaurant();


            //QUAND la franchise modifie le prix du plat
            double prix = 9;
            Menu menuWithNewPLat = new Menu();
            menuWithNewPLat.plats.Add(new Plat("ratatouille", prix));
            franchise.setMenu(menuWithNewPLat);

            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            Assert.NotEqual(prix, filiale.menu.plats.First().prix);
        }
    }
}
