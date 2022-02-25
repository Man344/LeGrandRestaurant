using LeGrandRestaurant.etats.table;
using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using LeGrandRestaurant.tests.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.tests
{
    public class CommandeTest
    {
        [Fact(DisplayName = 
            "ÉTANT DONNE un serveur dans un restaurant " +
            "QUAND il prend une commande de nourriture " +
            "ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant"
            )]
        public void AffectationClient()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            Restaurant restaurant = new Restaurant(true, new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            Serveur serveur = new Serveur("Jeannine", new DateTime(1950, 6, 12));
            restaurant.serveurs.Add(serveur);

            // QUAND il prend une commande de nourriture
            Commande commande = new Commande(serveur, new Client("Fifi"), new Table(new StockageEtatTableMemoire()));
            commande.Plats.Add(new Plat("bolognaise", 15));
            serveur.prendUneCommande(commande);

            // ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant
            Assert.Contains(commande, restaurant.getNotServedCommands());
        }


        [Fact(DisplayName = 
            "ÉTANT DONNE un serveur dans un restaurant " +
            "QUAND il prend une commande de boissons " +
            "ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant"
            )]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            Restaurant restaurant = new Restaurant(true, new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            Serveur serveur = new Serveur("Jeannine", new DateTime(1950, 6, 12));
            restaurant.serveurs.Add(serveur);


            // QUAND il prend une commande de boissons
            Commande commande = new Commande(serveur, new Client("Fifi"), new Table(new StockageEtatTableMemoire()));
            Boisson boisson = new Boisson("mojito", 7);
            commande.Boissons.Add(boisson);
            serveur.prendUneCommande(commande);


            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
            Assert.DoesNotContain(boisson.ToString(), restaurant.cuisineTasks().ToString());

        }

    }
}
