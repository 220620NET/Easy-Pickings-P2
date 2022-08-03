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
    [Migration("20220803130848_contactChange")]
    partial class contactChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
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

                    b.ToTable("claims");
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

                    b.ToTable("contact");
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

                    b.ToTable("policies");
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

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("NewModels.User", b =>
                {
                    b.Property<int?>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("userID"), 1L, 1);

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

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

                    b.ToTable("users");
                });

            modelBuilder.Entity("NewModels.Claim", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("doctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewModels.Policy", null)
                        .WithMany()
                        .HasForeignKey("policyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Contact", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Policy", b =>
                {
                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("insurance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewModels.Ticket", b =>
                {
                    b.HasOne("NewModels.Claim", null)
                        .WithMany()
                        .HasForeignKey("claimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewModels.Policy", null)
                        .WithMany()
                        .HasForeignKey("policyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewModels.User", null)
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
