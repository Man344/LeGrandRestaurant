using System;
using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.personnes.employes
{
    public class MaitreHotel : Employe
    {
        public List<Table> actualTables = new List<Table>();
        public MaitreHotel(string nom, DateTime embauche) : base(nom, embauche)
        {
        }



    }

}