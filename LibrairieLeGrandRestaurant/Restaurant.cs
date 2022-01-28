using LeGrandRestaurant;
using LeGrandRestaurant.personnes.employes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        public List<Table> tables;
        public List<Serveur> serveurs;
        public List<Commande> commandes;
        public MaitreHotel maitreHotel;
        public Menu menu;

        public bool EnService { get; private set; } = false;
        public bool IsFiliale { get; private set; }


        public Restaurant(bool isFiliale, MaitreHotel maitreHotel)
        {
            this.IsFiliale = isFiliale;
            menu = new Menu();
            serveurs = new List<Serveur>();
            tables = new List<Table>();
            commandes = new List<Commande>();
            this.maitreHotel = maitreHotel;
        }

        public void DébuterService()
        {
            EnService = true;
            maitreHotel.actualTables = tables;
        }

        public void TerminerService()
        {
            foreach (var table in tables)
            {
                table.Libérer();
            }
            EnService = false;
        }

        public List<Table> GetTablesLibres()
        {
            return tables.Where(t => t.EstLibre).ToList();
        }

        public List<Commande> GetCommandesToSendToThePolice()
        {
            return commandes.Where(c => c.hasToGoToThePolice() == true).ToList();
        }

        public void sitCostumer(Table table)
        {
            if (EnService)
            {
                tables.Remove(table);
                table.InstallerClient();
                tables.Add(table);
            }
            else
            {
                throw new Exception("Impossible d'installer un client quand le restaurant n'est pas en service");
            }
        }

        public void unsitCostumer(Table table)
        {
            tables.Remove(table);
            table.Libérer();
            tables.Add(table);
        }

        public double getCA()
        {
            double ca = 0;
            commandes.ForEach(x => ca += x.GetCA());
            return ca;
        }

    }
}
