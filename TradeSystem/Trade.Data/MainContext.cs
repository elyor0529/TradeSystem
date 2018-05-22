using EntityFramework.DynamicFilters;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trade.Data.Migrations;
using Trade.Data.Models;
using Trade.Data.Models.Base;

namespace Trade.Data
{
    public class MainContext : DbContext
    {
        public static void Migrate()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainContext, Configuration>());
        }

        public MainContext()
            : base("MainContext")
        {
        }

        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Remainder> Remainder { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClientType> ProductClientTypes { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Filter("IsDeleted", (BaseEntity f) => f.IsDeleted, false);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => SaveChanges(), cancellationToken);
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

                foreach (var entry in modifiedEntries)
                {
                    var entity = (BaseEntity)entry.Entity;
                    var now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.ModefiedDate = now;
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

    }
}