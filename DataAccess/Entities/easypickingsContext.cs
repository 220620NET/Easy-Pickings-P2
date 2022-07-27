using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class easypickingsContext : DbContext
    {
        public easypickingsContext()
        {
        }

        public easypickingsContext(DbContextOptions<easypickingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<Test2> Test2s { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claims", "P2");

                entity.Property(e => e.ClaimId).HasColumnName("claimID");

                entity.Property(e => e.DoctorIdFk).HasColumnName("doctorID_fk");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.Property(e => e.ReasonForVisit).HasColumnName("reasonForVisit");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Pending')");

                entity.Property(e => e.UserIdFk).HasColumnName("userID_fk");

                entity.HasOne(d => d.DoctorIdFkNavigation)
                    .WithMany(p => p.ClaimDoctorIdFkNavigations)
                    .HasForeignKey(d => d.DoctorIdFk)
                    .HasConstraintName("FK__claims__doctorID__71D1E811");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.ProviderFk)
                    .HasConstraintName("FK__claims__provider__72C60C4A");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.ClaimUserIdFkNavigations)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__claims__userID_f__70DDC3D8");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "P2");

                entity.Property(e => e.ContactId).HasColumnName("contactID");

                entity.Property(e => e.CityState)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city_state");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.PoNumber).HasColumnName("PO_number");

                entity.Property(e => e.PoOrStreet).HasColumnName("PO_or_street");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policy", "P2");

                entity.Property(e => e.PolicyId).HasColumnName("policyID");

                entity.Property(e => e.Coverage).HasColumnName("coverage");

                entity.Property(e => e.Insurance).HasColumnName("insurance");

                entity.HasOne(d => d.InsuranceNavigation)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.Insurance)
                    .HasConstraintName("FK__policy__insuranc__6A30C649");

                entity.HasMany(d => d.Benefactors)
                    .WithMany(p => p.Providers)
                    .UsingEntity<Dictionary<string, object>>(
                        "Insurance",
                        l => l.HasOne<User>().WithMany().HasForeignKey("Benefactor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__insurance__benef__6E01572D"),
                        r => r.HasOne<Policy>().WithMany().HasForeignKey("Provider").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__insurance__provi__6D0D32F4"),
                        j =>
                        {
                            j.HasKey("Provider", "Benefactor").HasName("PK__insuranc__6B56CC7FEBF2F85F");

                            j.ToTable("insurance", "P2");

                            j.IndexerProperty<int>("Provider").HasColumnName("provider");

                            j.IndexerProperty<int>("Benefactor").HasColumnName("benefactor");
                        });
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test");

                entity.Property(e => e.Hello).HasColumnName("hello");
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test2");

                entity.Property(e => e.Hello).HasColumnName("hello");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "P2");

                entity.HasIndex(e => e.Username, "UQ__users__F3DBC572FFC8CC6C")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ContactFk).HasColumnName("contact_fk");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("middle_init")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ContactFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactFk)
                    .HasConstraintName("FK__users__contact_f__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
