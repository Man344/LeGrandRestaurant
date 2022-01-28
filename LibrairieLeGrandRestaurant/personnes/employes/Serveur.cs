using LeGrandRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.personnes.employes
{
    public class Serveur : Employe
    {
        public double ca { get; set; } = 0;
        public List<Table> tonightTables { get; set; }
        public Serveur(string nom, DateTime embauche) : base(nom, embauche)
        {
            tonightTables = new List<Table>();
        }

        public void prendUneCommande(float montantCommande)
        {
            this.ca += montantCommande;
        }

        public void InitCA()
        {
            this.ca = 0;
        }

    }

}