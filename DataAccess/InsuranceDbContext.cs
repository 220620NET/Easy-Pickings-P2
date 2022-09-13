using NewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InsuranceDbContext:DbContext
    {
        public InsuranceDbContext() : base() { }
        public InsuranceDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Policy> Policies { get; set; } = null!;
        public DbSet<Claim> Claims { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Discussion> Discussions { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
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
            modelBuilder.Entity<Discussion>().HasOne<User>().WithMany().HasForeignKey(p => p.userID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>().HasOne<User>().WithMany().HasForeignKey(p => p.userID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>().HasOne<Discussion>().WithMany().HasForeignKey(p => p.messageID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasDefaultSchema("P2");
        }
    }
}
