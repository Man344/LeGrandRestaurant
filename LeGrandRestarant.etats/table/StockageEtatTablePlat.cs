using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeGrandRestaurant.etats.table
{
    public class StockageEtatTablePlat : IEtatTable
    {
        public bool EstLibre { 
            get {
                return true;
            } 
            set
            {
                string fileName = "EtatTable.json";
                string jsonString = JsonSerializer.Serialize(EstLibre);
                File.WriteAllText(fileName, jsonString);
            }
        }
        public bool EstAssociee { get; set; }

    }
}
