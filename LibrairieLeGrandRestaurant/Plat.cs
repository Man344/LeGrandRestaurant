using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Plat
    {
        public List<Ingredient> ingredients;
        public string nom;
        public double prix;
        public bool estServit { get; set; } = false;
        public Plat(string nom, double prix)
        {
            this.nom = nom;
            this.prix = prix;
            ingredients = new List<Ingredient>();
        }

    }
}
