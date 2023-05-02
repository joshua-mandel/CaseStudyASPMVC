﻿// <auto-generated />
using System;
using CaseStudy.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseStudy.Migrations
{
    [DbContext(typeof(SportsProContext))]
    [Migration("20230421200058_Updatesss")]
    partial class Updatesss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaseStudy.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = "A",
                            Name = "United States"
                        },
                        new
                        {
                            CountryId = "B",
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryId = "C",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = "D",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            CountryId = "E",
                            Name = "Australia"
                        });
                });

            modelBuilder.Entity("CaseStudy.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Spooner Street",
                            City = "San Francisco",
                            CountryId = "A",
                            EmailAddress = "kanthoni@pge.com",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "123 Spooner Street",
                            City = "Washington",
                            CountryId = "A",
                            EmailAddress = "ania@mma.nidc.com",
                            FirstName = "Ania",
                            LastName = "Irvin",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "123 Spooner Street",
                            City = "Mission Viejo",
                            CountryId = "B",
                            FirstName = "Gonzalo",
                            LastName = "Keeton",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "123 Spooner Street",
                            City = "Sacramento",
                            CountryId = "A",
                            EmailAddress = "amauro@yahoo.org",
                            FirstName = "Anton",
                            LastName = "Mauro",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "123 Spooner Street",
                            City = "Fresno",
                            CountryId = "A",
                            EmailAddress = "kmayte@fresno.ca.gov",
                            FirstName = "Kendall",
                            LastName = "Mayte",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 6,
                            Address = "123 Spooner Street",
                            City = "Los Angeles",
                            CountryId = "A",
                            EmailAddress = "kenzie@mma.jobtrak.com",
                            FirstName = "Kenzie",
                            LastName = "Quinn",
                            Phone = "970-331-1691",
                            PostalCode = "63141",
                            State = "California"
                        },
                        new
                        {
                            CustomerId = 7,
                            Address = "123 Spooner Street",
                            City = "Fresno",
                            CountryId = "A",
                            EmailAddress = "marvin@expedata.com",
                            FirstName = "Marvin",
                            LastName = "Quintin",
                            PostalCode = "63141",
                            State = "California"
                        });
                });

            modelBuilder.Entity("CaseStudy.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<int?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 5,
                            DateOpened = new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7716),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 2,
                            TechnicianId = 4,
                            Title = "Error launching program"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 2,
                            DateOpened = new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7719),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 7,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 3,
                            DateOpened = new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7723),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 1,
                            TechnicianId = 3,
                            Title = "Error launching program"
                        },
                        new
                        {
                            IncidentId = 4,
                            CustomerId = 5,
                            DateOpened = new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7726),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 4,
                            TechnicianId = 2,
                            Title = "Program keeps crashing"
                        });
                });

            modelBuilder.Entity("CaseStudy.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<double?>("YearlyPrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductCode = "TRNY10",
                            ProductName = "Tournament Master 1.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 4.9900000000000002
                        },
                        new
                        {
                            ProductId = 2,
                            ProductCode = "LEAG10",
                            ProductName = "League Scheduler 1.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 4.9900000000000002
                        },
                        new
                        {
                            ProductId = 3,
                            ProductCode = "LEAGD10",
                            ProductName = "League Scheduler Deluxe 1.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 7.9900000000000002
                        },
                        new
                        {
                            ProductId = 4,
                            ProductCode = "DRAFT10",
                            ProductName = "Draft Manager 1.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 4.9900000000000002
                        },
                        new
                        {
                            ProductId = 5,
                            ProductCode = "TEAM10",
                            ProductName = "Team Manager 1.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 4.9900000000000002
                        },
                        new
                        {
                            ProductId = 6,
                            ProductCode = "TRNY20",
                            ProductName = "Tournament Master 2.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 5.9900000000000002
                        },
                        new
                        {
                            ProductId = 7,
                            ProductCode = "DRAFT20",
                            ProductName = "Draft Manager 2.0",
                            ReleaseDate = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            YearlyPrice = 5.9900000000000002
                        });
                });

            modelBuilder.Entity("CaseStudy.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("TechnicianEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicianPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            TechnicianEmail = "alison@sportsprosoftware.com",
                            TechnicianName = "Alison Diaz",
                            TechnicianPhone = "800-555-0443"
                        },
                        new
                        {
                            TechnicianId = 2,
                            TechnicianEmail = "awilson@sportsprosoftware.com",
                            TechnicianName = "Andrew Wilson",
                            TechnicianPhone = "800-555-0449"
                        },
                        new
                        {
                            TechnicianId = 3,
                            TechnicianEmail = "gfiori@sportsprosoftware.com",
                            TechnicianName = "Gina Fiori",
                            TechnicianPhone = "800-555-0459"
                        },
                        new
                        {
                            TechnicianId = 4,
                            TechnicianEmail = "gunter@sportsprosoftware.com",
                            TechnicianName = "Gunter Wendt",
                            TechnicianPhone = "800-555-0400"
                        },
                        new
                        {
                            TechnicianId = 5,
                            TechnicianEmail = "jason@sportsprosoftware.com",
                            TechnicianName = "Jason Lee",
                            TechnicianPhone = "800-555-0444"
                        },
                        new
                        {
                            TechnicianId = -1,
                            TechnicianEmail = "",
                            TechnicianName = "",
                            TechnicianPhone = ""
                        });
                });

            modelBuilder.Entity("CaseStudy.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.Property<int>("CustomersCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("CustomersCustomerId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("CustomerProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CaseStudy.Models.Customer", b =>
                {
                    b.HasOne("CaseStudy.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CaseStudy.Models.Incident", b =>
                {
                    b.HasOne("CaseStudy.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.HasOne("CaseStudy.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CaseStudy.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CaseStudy.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CaseStudy.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
