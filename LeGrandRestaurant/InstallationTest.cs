using System;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.test
{
    public class InstallationTests
    {
        [Fact(DisplayName = "ÉTANT DONNE une table dans un restaurant ayant débuté son service " +
                            "QUAND un client est affecté à une table " +
                            "ALORS cette table n'est plus libre")]
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var table = new Table();
            Table[] tables = new Table[] { table };
            
            var restaurant = new Restaurant(tables, null);
            restaurant.DébuterService();

            // QUAND un client est affecté à une table
            table.InstallerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.False(table.EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND la table est libérée " +
                            "ALORS cette table est libre")]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client

            var table = new Table();
            Table[] tables = new Table[] { table };
            var restaurant = new Restaurant(tables, null );

            restaurant.DébuterService();
            table.InstallerClient();

            // QUAND la table est libérée
            table.Libérer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.True(table.EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND on veut installer un client " +
                            "ALORS une exception est lancée")]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            table.InstallerClient();

            // QUAND on veut installer un client
            void Act() => table.InstallerClient();

            // ALORS une exception est lancée
            Assert.Throws<InvalidOperationException>(Act);
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant une table occupée par un client " +
                            "QUAND le service est terminé " +
                            "ALORS elle est libérée")]
        public void ServiceEnd()
        {
            // ÉTANT DONNE un restaurant ayant une table occupée par un client
            var table = new Table();
            Table[] tables = new Table[] { table };
            table.InstallerClient();

            var restaurant = new Restaurant(tables, null);

            // QUAND le service est terminé
            restaurant.TerminerService();

            // ALORS elle est libérée
            Assert.True(table.EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée " +
                            "QUAND on recherche une table " +
                            "ALORS la table encore libre est renvoyée")]
        public void NextFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée
            var tableOccupée = new Table();
            tableOccupée.InstallerClient();

            var tableLibre = new Table();

            Table[] tables = new Table[] { tableLibre, tableOccupée };

            var restaurant = new Restaurant(tables, null );

            // QUAND on recherche une table
            var tableChoisie = restaurant
                .RechercherTablesLibres()
                .Single();

            // ALORS la table encore libre est renvoyée
            Assert.Same(tableLibre, tableChoisie);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées " +
                            "QUAND on recherche une table libre" +
                            "ALORS une collection vide est renvoyée")]
        public void NoFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées
            var tableOccupées = new Table[] { new Table(), new Table() };
            foreach (var tableOccupée in tableOccupées)
                tableOccupée.InstallerClient();

            var restaurant = new Restaurant(tableOccupées, null);

            // QUAND on recherche une table libre
            var tablesLibres = restaurant.RechercherTablesLibres();

            // ALORS une collection vide est renvoyée
            Assert.Empty(tablesLibres);
        }

    }
}
