using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Commande
    {
        public Client Client { get; private set; }
        public Serveur Serveur { get; private set; }
        public Table Table { get; private set; }
        public DateTime Creation { get; set; } = DateTime.Now;
        public bool IsServed { get; private set; }
        public bool IsEpingle { get; private set; }
        public bool IsSentToThePolice { get; set; }

        public List<Plat> Plats { get; private set; }
        public List<Boisson> Boissons { get; private set; }

        public Commande( Serveur serveur, Client client, Table table)
        {
            Boissons = new List<Boisson>();
            Plats = new List<Plat>();

            this.Client = client;
            this.Table = table;
            this.Serveur = serveur;
        }

        public double GetTotal()
        {
            double ca = 0;
            foreach(Boisson boisson in Boissons)
            {
                ca += boisson.prix;
            }
            foreach(Plat plat in Plats)
            {
                ca += plat.prix;
            }
            return ca;
        }

        public void termine(bool paid)
        {
            Table.Libérer();
            if (!paid)
            {
                IsEpingle = true;
            }
        }

        public bool hasToGoToThePolice()
        {
            DateTime days15Ago = DateTime.Now.AddDays(-15);
            if(IsEpingle && Creation < days15Ago && IsSentToThePolice==false)
            {
                return true;
            }
            return false;
        }

    }
}
