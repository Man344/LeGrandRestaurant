using LeGrandRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.personnes.employes
{
    public class Serveur : Employe
    {
        public List<Commande> commandes { get; set; }
        public List<Table> TonightTables { get; set; }

        public Serveur(string nom, DateTime embauche) : base(nom, embauche)
        {
            TonightTables = new List<Table>();
            commandes = new List<Commande>();
        }

        public void prendUneCommande(Commande commande)
        {
            commandes.Add(commande);
        }

        public double getCA()
        {
            double ca = 0;
            commandes.ForEach(x => ca += x.GetTotal());
            return ca;
        }

        public void affecter(Table table)
        {
            try
            {
                table.associatedToServeur();
            }catch (Exception ex)
            {
                throw new Exception();
            }
            TonightTables.Add(table);
        }

        public void desaffecter(Table table)
        {
            if (TonightTables.Contains(table))
            {
                TonightTables.Remove(table);
            }
            else
            {
                throw new Exception("Cette table n'est pas affecté à ce serveur");
            }
        }

    }

}