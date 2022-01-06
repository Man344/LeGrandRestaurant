using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.personnes
{
    public abstract class Personne
    {
        protected string nom { get; private set; }

        public Personne(string nom)
        {
            this.nom = nom;
        }

    }

}