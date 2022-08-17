﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(InsuranceDbContext))]
    [Migration("20220815212016_DobUpdate")]
    partial class DobUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("P2")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NewModels.Claim", b =>
                {
                    b.Property<int>("claimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("claimID"), 1L, 1);

                    b.Property<int>("doctorID")
                        .HasColumnType("int");

                    b.Property<int>("policyID")
                        .HasColumnType("int");

                    b.Property<string>("reasonForVisit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("claimID");

                    b.HasIndex("doctorID");

                    b.HasIndex("policyID");

                    b.HasIndex("userID");

                    b.ToTable("Claims", "P2");
                });

            modelBuilder.Entity("NewModels.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentID"), 1L, 1);

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("messageID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("commentID");

                    b.HasIndex("messageID");

                    b.HasIndex("userID");

                    b.ToTable("Comments", "P2");
                });

            modelBuilder.Entity("NewModels.Contact", b =>
                {
                    b.Property<int>("contactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contactID"), 1L, 1);

                    b.Property<int>("PO_number")
                        .HasColumnType("int");

                    b.Property<bool>("PO_or_street")
                        .HasColumnType("bit");

                    b.Property<string>("city_state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("phone")
                        .HasColumnType("bigint");

                    b.Property<string>("street_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("street_number")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.Property<int>("zipcode")
                        .HasColumnType("int");

                    b.HasKey("contactID");

                    b.HasIndex("userID");

                    b.ToTable("Contacts", "P2");
                });

            modelBuilder.Entity("NewModels.Discussion", b =>
                {
                    b.Property<int>("discussionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("discussionID"), 1L, 1);

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("discussionID");

                    b.HasIndex("userID");

                    b.ToTable("Discussions", "P2");
                });

            modelBuilder.Entity("NewModels.Policy", b =>
                {
                    b.Property<int>("policyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("policyID"), 1L, 1);

                    b.Property<string>("coverage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("insurance")
                        .HasColumnType("int");

                    b.HasKey("policyID");

                    b.HasIndex("insurance");

                    b.ToTable("Policies", "P2");
                });

            modelBuilder.Entity("NewModels.Ticket", b =>
                {
                    b.Property<int>("ticketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketID"), 1L, 1);

                    b.Property<int>("claimID")
                        .HasColumnType("int");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("policyID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ticketID");

                    b.HasIndex("claimID");

                    b.HasIndex("policyID");

                    b.HasIndex("userID");

                    b.ToTable("Tickets", "P2");
                });

            modelBuilder.Entity("NewModels.User", b =>
                {
                    b.Property<int?>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("userID"), 1L, 1);

                    b.Property<string>("DoB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middle_init")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users", "P2");
                });

            modelBuilder.Entity("NewModels.Claim", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("doctorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewModels.Policy", null)
                        .WithMany()
                        .HasForeignKey("policyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Comment", b =>
                {
                    b.HasOne("NewModels.Discussion", null)
                        .WithMany()
                        .HasForeignKey("messageID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Contact", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Discussion", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Policy", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("insurance")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Ticket", b =>
                {
                    b.HasOne("NewModels.Claim", null)
                        .WithMany()
                        .HasForeignKey("claimID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewModels.Policy", null)
                        .WithMany()
                        .HasForeignKey("policyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
