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

        public void affecter(Table table)
        {
            if (table.isAffected)
            {
                throw new Exception("Cette table est déjà affectée");
            }
            tonightTables.Add(table);
        }

        public void desaffecter(Table table)
        {
            if (tonightTables.Contains(table))
            {
                tonightTables.Remove(table);
            }
            else
            {
                throw new Exception("Cette table n'est pas affecté à ce serveur");
            }
        }

    }

}