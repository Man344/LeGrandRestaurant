using System;

namespace LeGrandRestaurant
{
    public class Serveur
    {
        public float CA { get; private set; }

        public void prendUneCommande(float montantCommande)
        {
            this.CA += montantCommande;
        }
    }
}
