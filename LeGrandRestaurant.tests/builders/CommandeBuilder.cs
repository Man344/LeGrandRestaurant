using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;

namespace LeGrandRestaurant.tests.builders
{
    public class CommandeBuilder
    {
        private Serveur _serveur;
        private Client _client;
        private Table _table;
        public CommandeBuilder()
        {
            _serveur = null;
            _client = null;
            _table = null;
        }
        public CommandeBuilder WithServeur(Serveur serveur)
        {
            _serveur = serveur;
            return this;
        }

        public CommandeBuilder WithClient(Client client)
        {
            _client = client;
            return this;
        }

        public CommandeBuilder WithTable(Table table)
        {
            _table = table;
            return this;
        }

        public Commande Build()
        {
            return new Commande(_serveur, _client, _table);
        }
    }
}
