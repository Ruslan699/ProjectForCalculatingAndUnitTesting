using AteshgahApp.Core.Models;
using System.Data.Entity;

namespace AteshgahApp.Core.DataContext
{
    public class MainDataContext : DbContext
    {
        public MainDataContext() : base("name = MainDataContext") { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Loans)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Loan>()
                .Property(e => e.Amount)
                .HasPrecision(17, 4);

            modelBuilder.Entity<Loan>()
                .Property(e => e.InterestRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Loan>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Loan)
                .WillCascadeOnDelete(false);
        }
    }
}
