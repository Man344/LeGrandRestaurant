using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Table
    {

        private readonly IEtatTable etatTable;

        public Table(IEtatTable etatTable)
        {
            this.etatTable = etatTable;
            this.etatTable.EstLibre = true;
        }
        public bool EstLibre {
            get => etatTable.EstLibre;
            private set => etatTable.EstLibre = value;
        }

        public void InstallerClient()
        {
            if (!EstLibre) throw new Exception();
            EstLibre = false;
        }

        public void Libérer()
        {
            EstLibre = true;
        }
    }
}
