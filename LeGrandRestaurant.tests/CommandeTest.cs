using LeGrandRestaurant.personnes;
using LeGrandRestaurant.personnes.employes;
using LeGrandRestaurant.tests.builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.tests
{
    public class CommandeTest
    {
        [Fact(DisplayName = 
            "ÉTANT DONNE un serveur dans un restaurant " +
            "QUAND il prend une commande de nourriture " +
            "ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant"
            )]
        public void AffectationClient()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            

            // QUAND il prend une commande de nourriture
            

            // ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant
            
        }


        [Fact(DisplayName = 
            "ÉTANT DONNE un serveur dans un restaurant " +
            "QUAND il prend une commande de boissons " +
            "ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant"
            )]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            

            // QUAND il prend une commande de boissons
            

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
            
        }

    }
}
