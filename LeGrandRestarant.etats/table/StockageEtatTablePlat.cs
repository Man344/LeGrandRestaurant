using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private String nom = "";
        private String PATH = "C:\\Users\\allen\\Documents\\GitHub\\LeGrandRestaurant\\";

        public StockageEtatTablePlat(String nom)
        {
            this.nom = nom;

            string jsonString = JsonConvert.SerializeObject(new { estLibre = true, estAssociee = false, nom = this.nom });
            File.WriteAllText(PATH + nom + ".json", jsonString);
        }


        public String Nom
        {
            get
            {
                return get("nom");
            }
            set
            {
                String oldPath = PATH + nom + ".json";
                String newPath = PATH + value + ".json";
                this.nom = value;

                //write in file
                string jsonString = JsonConvert.SerializeObject(new { estLibre = EstLibre, estAssociee = EstAssociee, nom = value });
                File.WriteAllText(oldPath, jsonString);

                //rename file
                File.Move(oldPath, newPath);
            }
        }
        public bool EstLibre { 
            get {
                String estLibre = get("estLibre");
                return bool.Parse(estLibre);
            } 
            set
            {
                string fileName = PATH + nom + ".json";
                string jsonString = JsonConvert.SerializeObject(new { estLibre = value, estAssociee = EstAssociee, nom = nom }) ;
                File.WriteAllText(fileName, jsonString);
            }
        }
        public bool EstAssociee {
            get
            {
                String estAssociee = get("estAssociee");
                return bool.Parse(estAssociee);
            }
            set
            {
                string fileName = PATH + nom + ".json";
                string jsonString = JsonConvert.SerializeObject(new { estLibre = EstLibre, estAssociee = value, nom = this.nom });
                File.WriteAllText(fileName, jsonString);
            }
        }



        private String get(String key)
        {
            StreamReader r = new StreamReader(PATH + nom + ".json");
            string jsonString = r.ReadToEnd();
            r.Close();

            JObject a = JsonConvert.DeserializeObject<JObject>(jsonString);
            JToken value;
            a.TryGetValue(key, out value);
            return (String)value;
        }

    }
}
