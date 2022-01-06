using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.test
{
    public class EpinglageTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant pris une commande " +
            "QUAND il la déclare comme non - payée " +
            "ALORS cette commande est marquée comme épinglée")]
        public void AffectationClient()
        {
            // ÉTANT DONNE un serveur ayant pris une commande
            Serveur jean = new Serveur("Jean", DateTime.Now);
            Table table = new Table();
            Client client = new Client("Catherine");
            Commande commande = new Commande(jean, client, table);

            // QUAND il la déclare comme non - payée
            commande.termine(false);

            // ALORS cette commande est marquée comme épinglée
            Assert.True(commande.IsEpingle);
        }


        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant épinglé une commande " +
            "QUAND elle date d'il y a au moins 15 jours " +
            "ALORS cette commande est marquée comme à transmettre gendarmerie")]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE un serveur ayant épinglé une commande
            var jean = new Serveur("Jean", DateTime.Now);
            Table table = new Table();
            Client client = new Client("Catherine");
            Commande commande = new Commande(jean, client, table);
            commande.termine(false);

            // QUAND elle date d'il y a au moins 15 jours
            commande.Creation = DateTime.Now.AddDays(-16);

            // ALORS cette commande est marquée comme à transmettre gendarmerie
            Assert.True(commande.hasToGoToThePolice());
        }

        [Fact(DisplayName = "ÉTANT DONNE une commande à transmettre gendarmerie " +
            "QUAND on consulte la liste des commandes à transmettre du restaurant " +
            "ALORS elle y figure")]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une commande à transmettre gendarmerie
            var jean = new Serveur("Jean", DateTime.Now);
            Table table = new Table();
            Client client = new Client("Catherine");
            Commande commande = new Commande(jean, client, table);
            commande.termine(false);
            commande.Creation = DateTime.Now.AddDays(-16);

            Restaurant restaurant = new Restaurant(false);
            restaurant.commandes.Add(commande);

            // QUAND on consulte la liste des commandes à transmettre du restaurant
            List<Commande> commandesToSendToThePloice = restaurant.GetCommandesToSendToThePolice();

            // ALORS elle y figure
            Assert.Contains(commande, commandesToSendToThePloice);
        }

        [Fact(DisplayName = "ÉTANT DONNE une commande à transmettre gendarmerie" +
            " QUAND elle est marquée comme transmise à la gendarmerie " +
            " ALORS elle ne figure plus dans la liste des commandes à transmettre")]
        public void ServiceEnd()
        {
            // ÉTANT DONNE une commande à transmettre gendarmerie
            var jean = new Serveur("Jean", DateTime.Now);
            Table table = new Table();
            Client client = new Client("Catherine");
            Commande commande = new Commande(jean, client, table);
            commande.termine(false);
            commande.Creation = DateTime.Now.AddDays(-16);

            Restaurant restaurant = new Restaurant(false);
            restaurant.commandes.Add(commande);

            // QUAND elle est marquée comme transmise à la gendarmerie
            commande.IsSentToThePolice = true;

            // ALORS elle ne figure plus dans la liste des commandes à transmettre
            List<Commande> commandesToSendToThePloice = restaurant.GetCommandesToSendToThePolice();
            Assert.DoesNotContain(commande, commandesToSendToThePloice);
        }

    }
}
