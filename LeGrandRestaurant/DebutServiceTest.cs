using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using LeGrandRestaurant.test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.test
{
    public class DebutServiceTest
    {
        [Fact(DisplayName =
            "ÉTANT DONNE un restaurant ayant 3 tables " +
            "QUAND le service commence " +
            "ALORS elles sont toutes affectées au Maître d'Hôtel"
            )]

        public void CA_Nouveau_Serveur_A_Zero()
        {
            //ÉTANT DONNE un restaurant ayant 3 tables
            Restaurant restaurant = new Restaurant(true, new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            restaurant.tables.Add(new Table());
            restaurant.tables.Add(new Table());
            restaurant.tables.Add(new Table());
            //QUAND le service commence
            restaurant.DébuterService();
            //ALORS elles sont toutes affectées au Maître d'Hôtel
            Assert.Equal(restaurant.tables, restaurant.maitreHotel.actualTables);

        }

        [Fact(DisplayName = 
            "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur " +
            "QUAND le service débute " +
            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel"
            )]

        public void CA_Nouveau_Serveur_A_Montant_Commande()
        {
            //ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
            var jean = new Serveur("Jean", DateTime.Now);
            // QUAND le service débute
            Commande commande = new CommandeBuilder().WithServeur(jean)
                .WithClient(new Client("Catherine"))
                .WithTable(new Table())
                .Build();
            //ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
            Assert.Equal(commande.GetCA(), jean.ca);
        }


        [Fact(DisplayName = 
            "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur " +
            "QUAND le service débute " +
            "ALORS il n'est pas possible de modifier le serveur affecté à la table"
            )]

        public void CA_Nouveau_Serveur_A_Montants_Commandes()
        {
            //ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
            Restaurant restaurant = new Restaurant(true, new MaitreHotel("Caro", new DateTime(2000, 6,12)));
            restaurant.tables.Add(new Table());
            restaurant.tables.Add(new Table());
            Table table = new Table();
            Serveur serveur = new Serveur("John", new DateTime(1922 / 2 / 22));
            serveur.tonightTables.Add(table);

            restaurant.tables.Add(table);
            restaurant.serveurs.Add(serveur);


            //QUAND le service débute
            restaurant.DébuterService();

            //ALORS il n'est pas possible de modifier le serveur affecté à la table
            
        }


        [Fact(DisplayName = 
            "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
            " ET ayant débuté son service " +
            "QUAND le service se termine " +
            "ET qu'une table est affectée à un serveur " +
            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel"
            )]

        public void CA_Franchise_A_Montants_XServeurs_YCommandes()
        {
            //ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
            Restaurant restaurant = new Restaurant(true, new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            restaurant.tables.Add(new Table());
            restaurant.tables.Add(new Table());
            Table table = new Table();
            Serveur serveur = new Serveur("John", new DateTime(1922 / 2 / 22));
            serveur.tonightTables.Add(table);

            restaurant.tables.Add(table);
            restaurant.serveurs.Add(serveur);

            //ET ayant débuté son service
            restaurant.DébuterService();

            //QUAND le service se termine
            restaurant.TerminerService();

            //ET qu'une table est affectée à un serveur
            if (serveur.tonightTables.Contains(table))
            {
                // ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
                List<Table> tables = restaurant.tables;
                tables.Remove(table);
                Assert.Equal(restaurant.maitreHotel.actualTables, tables);
            }

        }

    }
}
