using LeGrandRestaurant.personnes.employes;
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
            Restaurant filiale = franchise.addFillialeRestaurant(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));

            // QUAND la franchise modifie le prix du plat
            double prix = 9;
            Menu menuWithNewPLat = new Menu();
            menuWithNewPLat.plats.Add(new Plat("ratatouille", prix));
            franchise.updateMenu(menuWithNewPLat);


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
            Restaurant filiale = franchise.addRestaurant(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));


            //QUAND la franchise modifie le prix du plat
            double prix = 9;
            Menu menuWithNewPLat = new Menu();
            menuWithNewPLat.plats.Add(new Plat("ratatouille", prix));
            franchise.updateMenu(menuWithNewPLat);

            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            Assert.NotEqual(prix, filiale.menu.plats.First().prix);
        }

        
        [Fact(DisplayName = "ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat " +
            "QUAND la franchise ajoute un nouveau plat " +
            "ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise")]
        public void giveMeAName()
        {
            //ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            Franchise franchise = new Franchise(new Menu());
            Restaurant restaurant = franchise.addFillialeRestaurant(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));

            //QUAND la franchise ajoute un nouveau plat
            Menu menu = franchise.menu;
            Plat plat = new Plat("Beuf bourgignon", 15);
            menu.plats.Add(plat);
            franchise.updateMenu(menu);

            //ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise
            restaurant.setNewPrix(plat, 17);
            Plat lePlatDeMonRestaurant = restaurant.menu.plats.First(x => x.nom == plat.nom);
            Assert.Equal(17, lePlatDeMonRestaurant.prix); //le second prix est dans franchise.menu.plats

        }
    }
}
