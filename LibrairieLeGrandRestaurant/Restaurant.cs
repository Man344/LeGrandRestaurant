using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private Menu _menu;
        private readonly Table[] _tables;
        private readonly Serveur[] _serveurs;
     

        public Restaurant(Table[] tables, Serveur[] serveurs)
        {
            _tables = tables;
            _menu = new Menu();
            _serveurs = serveurs;
        }
 

        public void DébuterService()
        {
        }

        public bool LaTableEstLibre(Table table)
            => table.EstLibre;

        public void TerminerService()
        {
            foreach (var table in _tables)
            {
                table.Libérer();
            }
        }

        internal void ImposerMenu(Menu menu)
        {
            _menu = new MenuFranchisé(menu);
        }

        public IEnumerable<Table> RechercherTablesLibres()
        {
            return _tables.Where(m => m.EstLibre);
        }

        public decimal ObtenirPrix(Plat plat) => _menu.ObtenirPrix(plat);

        public void FixerPrix(Plat plat, decimal prixRestaurant)
            => _menu.FixerPrix(plat, prixRestaurant);
    }
}
