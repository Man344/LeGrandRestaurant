using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Menu
    {
        protected readonly IDictionary<Plat, decimal> Prix;

        public Menu()
        {
            Prix = new Dictionary<Plat, decimal>();
        }

        public void FixerPrix(Plat plat, decimal nouveauPrix)
        {
            Prix.Add(plat, nouveauPrix);
        }

        internal virtual decimal ObtenirPrix(Plat plat)
            => Prix[plat];
    }

    internal class MenuFranchisé : Menu
    {
        private readonly Menu _parent;

        public MenuFranchisé(Menu parent)
        {
            _parent = parent;
        }

        internal override decimal ObtenirPrix(Plat plat)
            => Prix.ContainsKey(plat) ? base.ObtenirPrix(plat) : _parent.ObtenirPrix(plat);
    }
}
