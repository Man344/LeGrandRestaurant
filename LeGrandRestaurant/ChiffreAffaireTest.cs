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
            var serveur = new Serveur();
            //QUAND on récupére son chiffre d'affaires
            float ChiffreAffaire = serveur.CA;
            //ALORS celui -ci est à 0
            Assert.Equal(0, ChiffreAffaire);

        }

        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur" +
            "QUAND il prend une commande" +
            "ALORS son chiffre d'affaires est le montant de celle-ci")]

        public void CA_Nouveau_Serveur_A_Montant_Commande()
        {
            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur();
            serveur.prendUneCommande(25);
            // QUAND il prend une commande
            float ChiffreAffaire = serveur.CA;
            //ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(25, ChiffreAffaire);

        }


        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande" +
            "QUAND il prend une nouvelle commande" +
            "ALORS son chiffre d'affaires est la somme des deux commandes")]

        public void CA_Nouveau_Serveur_A_Montants_Commandes()
        {
            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur();
            serveur.prendUneCommande(25);
            serveur.prendUneCommande(30);
            //QUAND il prend une nouvelle commande
            float ChiffreAffaire = serveur.CA;
            //ALORS son chiffre d'affaires est la somme des deux commandes
            Assert.Equal(55, ChiffreAffaire);

        }


        [Theory(DisplayName = "ÉTANT DONNÉ un restaurant ayant X serveurs" +
            "QUAND tous les serveurs prennent une commande d'un montant Y" +
            "ALORS le chiffre d'affaires de la franchise est X * Y")]

        //CAS(X = 0; X = 1; X = 2; X = 100)
		//CAS(Y = 1.0)
        [InlineData(0,1.0)]
        [InlineData(1, 1.0)]
        [InlineData(2, 1.0)]
        [InlineData(100, 1.0)]
        public void CA_Franchise_A_Montants_XServeurs_YCommandes(int nbServeur, float montantCommande)
        {
            //ÉTANT DONNÉ un restaurant ayant X serveurs
            Serveur[] serveurs = new Serveur[nbServeur];
         
            for (int i = 0; i < nbServeur ; i++)
            {
                serveurs[i] = new Serveur();  
            }
            Restaurant restaurant = new Restaurant(null,serveurs);

            //QUAND tous les serveurs prennent une commande d'un montant Y
            float CATotal = 0;
            for (int i = 0; i < nbServeur; i++)
            {
                serveurs[i].prendUneCommande(montantCommande);
                CATotal += serveurs[i].CA;
            }

            //ALORS le chiffre d'affaires de la franchise est X * Y

            Assert.Equal(nbServeur * montantCommande, CATotal);

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
                    serveurs[j] = new Serveur();
                }
                restaurants[i] = new Restaurant(null, serveurs);
            }

            Franchise franchise = new Franchise(restaurants);

            //QUAND tous les serveurs prennent une commande d'un montant Z 
            float CATotal = 0;
            for(int i = 0; i < nbRestaurant; i++)
            {
                for (int j = 0; j < nbServeurs; j++)
                {
                    serveurs[j].InitCA();
                    serveurs[j].prendUneCommande(prixCommande);
                    CATotal += serveurs[j].CA;
                }
            }

            //ALORS le chiffre d'affaires de la franchise est X * Y * Z

            Assert.Equal(nbServeurs * prixCommande * nbRestaurant, CATotal);
        }




    }
}
