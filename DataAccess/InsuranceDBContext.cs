using Microsoft.EntityFrameworkCore;
using Models;


namespace DataAccess
{
    public class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions options) : base(options) { }

        public InsuranceDBContext():base(){}
        public DbSet<Claim> Claims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
