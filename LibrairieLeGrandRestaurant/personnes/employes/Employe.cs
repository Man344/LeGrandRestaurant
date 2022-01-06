using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.personnes.employes
{
    public abstract class Employe : Personne
    {
        public DateTime DateEmbauche { get; private set; }
        public bool IsNoLongerWorkingHere { get; set; } = false;
        public Employe(string nom, DateTime embauche) : base(nom)
        {
            this.DateEmbauche = embauche;
        }
    }
}
