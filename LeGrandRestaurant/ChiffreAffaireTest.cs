﻿using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using LeGrandRestaurant.test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.test
{
    public class ChiffreAffaireTest
    {
        [Fact(DisplayName= "ÉTANT DONNÉ un nouveau serveur" +
            " QUAND on récupére son chiffre d'affaires" +
            "ALORS celui - ci est à 0")]

        public void CA_Nouveau_Serveur_A_Zero()
        {
            //ÉTANT DONNÉ un nouveau serveur
            Serveur serveur = new Serveur("Patrick", new DateTime(year: 2012, month: 12, day: 12));
            //QUAND on récupére son chiffre d'affaires
            double ChiffreAffaire = serveur.ca;
            //ALORS celui -ci est à 0
            Assert.Equal(0, ChiffreAffaire);

        }

        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur" +
            "QUAND il prend une commande" +
            "ALORS son chiffre d'affaires est le montant de celle-ci")]

        public void CA_Nouveau_Serveur_A_Montant_Commande()
        {
            //ÉTANT DONNÉ un nouveau serveur
            var jean = new Serveur("Jean", DateTime.Now);
            // QUAND il prend une commande
            Commande commande = new CommandeBuilder().WithServeur(jean)
                .WithClient(new Client("Catherine"))
                .WithTable(new Table())
                .Build();
            //ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(commande.GetCA(), jean.ca);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande " +
            "QUAND il prend une nouvelle commande " +
            "ALORS son chiffre d'affaires est la somme des deux commandes ")]

        public void CA_Nouveau_Serveur_A_Montants_Commandes()
        {
            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur("Caro", DateTime.Now);
            Commande commande = new CommandeBuilder().WithServeur(serveur)
                .WithClient(new Client("Catherine"))
                .WithTable(new Table())
                .Build();
            commande.addBoisson(new Boisson("coktail", 10));
            //QUAND il prend une nouvelle commande
            Commande commande2 = new CommandeBuilder().WithServeur(serveur)
                .WithClient(new Client("Catherine"))
                .WithTable(new Table())
                .Build();
            commande.addBoisson(new Boisson("coca", 4));
            //ALORS son chiffre d'affaires est la somme des deux commandes
            double somme = commande.GetCA() + commande2.GetCA();
            Assert.Equal(somme, serveur.ca);
        }


        [Theory(DisplayName = "ÉTANT DONNÉ un restaurant ayant X serveurs" +
            "QUAND tous les serveurs prennent une commande d'un montant Y" +
            "ALORS le chiffre d'affaires de la franchise est X * Y")]

        //CAS(X = 0; X = 1; X = 2; X = 100)
		//CAS(Y = 1.0)
        [InlineData(0,1.0)]
        [InlineData(1, 2)]
        [InlineData(2, 1.0)]
        [InlineData(100, 3)]
        public void CA_Franchise_A_Montants_XServeurs_YCommandes(int nbServeur, double montantCommande)
        {
            //ÉTANT DONNÉ un restaurant ayant X serveurs
            Restaurant resto = new RestaurantBuilder().Build();
         
            for (int i = 0; i < nbServeur ; i++)
            {
                resto.serveurs.Add(new Serveur(i.ToString(), DateTime.Now));
            }

            //QUAND tous les serveurs prennent une commande d'un montant Y
            resto.serveurs.ForEach(x =>
            {
                Commande commande = new CommandeBuilder().WithServeur(x)
                .WithClient(new Client("jeanno"))
                .WithTable(new Table())
                .Build();
                commande.addBoisson(new Boisson("oneDollarDrink", montantCommande));
                resto.commandes.Add(commande);
            });

            //ALORS le chiffre d'affaires de la franchise est X * Y
            Assert.Equal(resto.getCA(), nbServeur*montantCommande);

        }


        [Theory(DisplayName = "ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns" +
            "QUAND tous les serveurs prennent une commande d'un montant Z " +
            "ALORS le chiffre d'affaires de la franchise est X * Y * Z")]

        //CAS(X = 0; X = 1; X = 2; X = 1000)
		//CAS(Y = 0; Y = 1; Y = 2; Y = 1000)
		//CAS(Z = 1.0)

        [InlineData(0,0,1.0)]
        [InlineData(1,1,1.0)]
        [InlineData(2,2,1.0)]
        [InlineData(1000, 1000, 1.0)]

        public void CA_Franchise_pour_X_Restaurant_avec_Y_Serveurs_prennant_Commande_Z_euros(int nbRestaurant, int nbServeurs, float prixCommande)
        {

            //ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns

            Restaurant[] restaurants = new Restaurant[nbRestaurant];
            Serveur[] serveurs = new Serveur[nbServeurs];

            
            for(int i = 0; i < nbRestaurant; i++)
            {
                for (int j = 0; j < nbServeurs; j++)
                {
                    serveurs[j] = new Serveur("test", DateTime.Now);
                }
                restaurants[i] = new RestaurantBuilder().WithServeurs(serveurs.ToList()).Build();
            }

            Franchise franchise = new Franchise(null);

            //QUAND tous les serveurs prennent une commande d'un montant Z 
            double CATotal = 0;
            for(int i = 0; i < nbRestaurant; i++)
            {
                for (int j = 0; j < nbServeurs; j++)
                {
                    serveurs[j].InitCA();
                    serveurs[j].prendUneCommande(prixCommande);
                    CATotal += serveurs[j].ca;
                }
            }

            //ALORS le chiffre d'affaires de la franchise est X * Y * Z

            Assert.Equal(nbServeurs * prixCommande * nbRestaurant, CATotal);
        }




    }
}
