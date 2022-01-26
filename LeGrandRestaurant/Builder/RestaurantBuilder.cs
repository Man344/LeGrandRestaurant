
using System.Collections.Generic;
using LeGrandRestaurant.personnes.employes;

namespace LeGrandRestaurant.test.Builder
{
    public class RestaurantBuilder
    {

        private List<Table> _tables;
        private List<Serveur> _serveurs;
        private List<Commande> _commandes;
        private Menu _menu;
        private bool _EnService = false;
        private bool _IsFiliale;

        public RestaurantBuilder()
        {
            _tables = new List<Table>();
            _serveurs = new List<Serveur>();
            _commandes = new List<Commande>();
            _menu = new Menu();
            _EnService = false;
            _IsFiliale = false;

        }

        public RestaurantBuilder WithTables(List<Table> tables)
        {
            _tables = tables;
            return this;
        }

        public RestaurantBuilder WithServeurs(List<Serveur> serveurs)
        {
            _serveurs = serveurs;
            return this;
        }

        public RestaurantBuilder WithCommande(List<Commande> commandes)
        {
            _commandes = commandes;
            return this;
        }

        public RestaurantBuilder WithMenu(Menu menu)
        {
            _menu = menu;
            return this;
        }

        public RestaurantBuilder IsEnService()
        {
            _EnService = true;
            return this;
        }

        public RestaurantBuilder IsFiliale()
        {
            _IsFiliale = true;
            return this;
        }

        public Restaurant Build() => new Restaurant(_IsFiliale);
    }
}
