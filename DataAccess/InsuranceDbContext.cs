using NewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InsuranceDbContext:DbContext
    {
        public InsuranceDbContext() : base() { }
        public InsuranceDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; } 
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasOne<User>().WithMany().HasForeignKey(p => p.userID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ticket>().HasOne<Policy>().WithMany().HasForeignKey(p => p.policyID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ticket>().HasOne<Claim>().WithMany().HasForeignKey(p => p.claimID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Contact>().HasOne<User>().WithMany().HasForeignKey(p => p.userID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Claim>().HasOne<User>().WithMany().HasForeignKey(p => p.userID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Claim>().HasOne<User>().WithMany().HasForeignKey(p => p.doctorID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Claim>().HasOne<Policy>().WithMany().HasForeignKey(p => p.policyID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Policy>().HasOne<User>().WithMany().HasForeignKey(p => p.insurance).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasDefaultSchema("P2");
        }
    }
}
