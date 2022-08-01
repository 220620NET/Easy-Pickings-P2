using NewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InsuranceDbContext:DbContext
    {
        public InsuranceDbContext() : base() { }
        public InsuranceDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Policy> policies { get; set; }
        public DbSet<Claim> claims { get; set; } 
        public DbSet<Contact> contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasOne<User>().WithMany().HasForeignKey(p => p.userID);
            modelBuilder.Entity<Ticket>().HasOne<Policy>().WithMany().HasForeignKey(p => p.policyID);
            modelBuilder.Entity<Ticket>().HasOne<Claim>().WithMany().HasForeignKey(p => p.claimID);
            modelBuilder.Entity<Contact>().HasOne<User>().WithMany().HasForeignKey(p => p.userID);
            modelBuilder.Entity<Claim>().HasOne<User>().WithMany().HasForeignKey(p => p.userID);
            modelBuilder.Entity<Claim>().HasOne<User>().WithMany().HasForeignKey(p => p.doctorID);
            modelBuilder.Entity<Claim>().HasOne<Policy>().WithMany().HasForeignKey(p => p.policyID);

            modelBuilder.Entity<Policy>().HasOne<User>().WithMany().HasForeignKey(p => p.insurance);
        }
    }
}
