namespace LeGrandRestaurant
{
    public class Boisson
    {
        public string nom;
        public double prix;
        public bool estServit { get; set; }

        public Boisson(string nom, double prix)
        {
            this.nom = nom;
            this.prix = prix;
        }
    }
}
