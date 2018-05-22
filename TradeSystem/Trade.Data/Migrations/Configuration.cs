using System.Data.Entity.Migrations;
using Trade.Data.Models;

namespace Trade.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MainContext context)
        {
            var folders = new[]
            {
                new Folder {Id = 1, Name = "Folder1"},
                new Folder {Id = 2, Name = "Folder2"},
                new Folder {Id = 3, Name = "Folder3"},
                new Folder {Id = 4, Name = "Folder4"}
            };
            context.Folders.AddOrUpdate(a => a.Id, folders);

            var categories = new[]
            {
                new Category {Id = 1, Name = "Category1", FolderId = 1},
                new Category {Id = 2, Name = "Category2", FolderId = 2},
                new Category {Id = 3, Name = "Category3", FolderId = 3},
                new Category {Id = 4, Name = "Category4", FolderId = 4}
            };
            context.Categories.AddOrUpdate(a => a.Id, categories);

            var products = new[]
            {
                new Product {Id = 1, Name = "Zaryadka", CategoryId = 1},
                new Product {Id = 2, Name = "Batareyka", CategoryId = 2},
                new Product {Id = 3, Name = "Naushnik", CategoryId = 3},
                new Product {Id = 4, Name = "Chexol", CategoryId = 4}
            };
            context.Products.AddOrUpdate(a => a.Id, products);

            var clientTypes = new[]
            {
                new ClientType {Id = 1, Name = "Gold"},
                new ClientType {Id = 2, Name = "General"}
            };
            context.ClientTypes.AddOrUpdate(a => a.Id, clientTypes);

            var managers = new[]
            {
                new Manager {Id = 1, FirstName = "Xurshidbek", LastName = "Rajabov", Login = "admin", Password = "1"},
                new Manager {Id = 2, FirstName = "Elyor", LastName = "Latipov", Login = "levdeo", Password = "web@1234"}
            };
            context.Managers.AddOrUpdate(a => a.Id, managers);

            var employees = new[]
            {
                new Employee {Id = 1, FirstName = "Xurshidbek", LastName = "Rajabov", Code = "1"},
                new Employee {Id = 2, FirstName = "Elyor", LastName = "Latipov", Code = "05291989"}
            };
            context.Employees.AddOrUpdate(a => a.Id, employees);

            var clients = new[]
            {
                new Client {Id = 1, FirstName = "Xurshidbek", LastName = "Rajabov"},
                new Client {Id = 2, FirstName = "Elyor", LastName = "Latipov"}
            };
            context.Clients.AddOrUpdate(a => a.Id, clients);
        }
    }
}