using System;
using System.Collections.Generic;
using System.Linq;
using LeGrandRestaurant.personnes.employes;
using LeGrandRestaurant.tests.builders;
using Xunit;

namespace LeGrandRestaurant.tests
{
    public class InstallationTests
    {
        [Fact(DisplayName = "ÉTANT DONNE une table dans un restaurant ayant débuté son service " +
                            "QUAND un client est affecté à une table " +
                            "ALORS cette table n'est plus libre")]
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table = TableBuilder.BuildEnMemoire("1");
            resto.tables.Add(table);

            // QUAND un client est affecté à une table
            resto.sitCostumer(table);

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            List<Table> tablesLibres = resto.GetTablesLibres();
            Assert.DoesNotContain(table, tablesLibres);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND la table est libérée " +
                            "ALORS cette table est libre")]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table = TableBuilder.BuildEnMemoire("1");
            resto.tables.Add(table);
            resto.sitCostumer(table);

            // QUAND la table est libérée
            resto.unsitCostumer(table);

            // ALORS cette table est sur la liste des tables libres du restaurant
            List<Table> tablesLibres = resto.GetTablesLibres();
            Assert.Contains(table, tablesLibres);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND on veut installer un client " +
                            "ALORS une exception est lancée")]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table = TableBuilder.BuildAPlat("1");
            resto.tables.Add(table);
            resto.sitCostumer(table);

            // QUAND on veut installer un client
            void Act() => resto.sitCostumer(table);

            // ALORS une exception est lancée
            Assert.Throws<Exception>(Act);
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant une table occupée par un client " +
                            "QUAND le service est terminé " +
                            "ALORS elle est libérée")]
        public void ServiceEnd()
        {
            // ÉTANT DONNE un restaurant ayant une table occupée par un client
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table = TableBuilder.BuildEnMemoire("1");
            resto.tables.Add(table);
            resto.sitCostumer(table);

            // QUAND le service est terminé
            resto.TerminerService();

            // ALORS elle est libérée
            Assert.True(table.EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée " +
                            "QUAND on recherche une table " +
                            "ALORS la table encore libre est renvoyée")]
        public void NextFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table = TableBuilder.BuildEnMemoire("1");
            resto.tables.Add(table);
            resto.sitCostumer(table);

            var tableLibre = TableBuilder.BuildEnMemoire("1");
            resto.tables.Add(tableLibre);

            // QUAND on recherche une table
            Table nextFreeTable = resto.GetTablesLibres().First();

            // ALORS la table encore libre est renvoyée
            Assert.Same(tableLibre, nextFreeTable);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées " +
                            "QUAND on recherche une table libre" +
                            "ALORS une collection vide est renvoyée")]
        public void NoFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées
            Restaurant resto = new RestaurantBuilder().Build(new MaitreHotel("Caro", new DateTime(2000, 6, 12)));
            resto.DébuterService();
            Table table1 = TableBuilder.BuildAPlat("1");
            resto.tables.Add(table1);
            resto.sitCostumer(table1);
            Table table2 = TableBuilder.BuildAPlat("2");
            resto.tables.Add(table2);
            resto.sitCostumer(table2);

            // QUAND on recherche une table libre
            List<Table> tablesLibres = resto.GetTablesLibres();

            // ALORS une collection vide est renvoyée
            Assert.Empty(tablesLibres);
        }

    }
}
