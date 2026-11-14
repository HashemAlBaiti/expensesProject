using expensesProject.Model;
using Microsoft.EntityFrameworkCore;

namespace expensesProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        DbSet<User> Users { get; set; }
        DbSet<Catigory> Catigories { get; set; }
        DbSet<Expenses> Expensess { get; set; }
        DbSet<PaymentMethod> PaymentMethods { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCards>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Expenses>().HasOne(e => e.User)
                .WithMany(q=> q.Expenses).HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Expenses>().HasOne(e => e.Catigory)
             .WithMany(q => q.Expenses).HasForeignKey(e => e.CatigoryId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Expenses>().HasOne(e => e.PaymentMethod)
      .WithMany(q => q.Expenses).HasForeignKey(e => e.PaymentMethodId)
      .OnDelete(DeleteBehavior.NoAction);

          







            base.OnModelCreating(modelBuilder);
        }

    }
}
