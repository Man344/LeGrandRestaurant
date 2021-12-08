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
            var restaurant = new Restaurant();
            var franchise = new Franchise(restaurant);

            // QUAND la franchise modifie le prix du plat
            var nouveauPrix = new decimal(67.99);
            var plat = new Plat();

            franchise.FixerPrix(plat, nouveauPrix);

            // ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            var prixDuPlat = restaurant.ObtenirPrix(plat);

            Assert.Equal(nouveauPrix, prixDuPlat);
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat " +
                            "QUAND la franchise modifie le prix du plat " +
                            "ALORS le prix du plat dans le menu du restaurant reste inchangé")]
        public void ConflitRestaurantFranchise()
        {
            //ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var restaurant = new Restaurant();
            var franchise = new Franchise(restaurant);
            var plat = new Plat();

            var prixRestaurant = new decimal(12.99);
            restaurant.FixerPrix(plat, prixRestaurant);

            //QUAND la franchise modifie le prix du plat
            var prixFranchise = new decimal(67.99);
            franchise.FixerPrix(plat, prixFranchise);

            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            var prixDuPlat = restaurant.ObtenirPrix(plat);

            Assert.Equal(prixRestaurant, prixDuPlat);
        }
    }
}
