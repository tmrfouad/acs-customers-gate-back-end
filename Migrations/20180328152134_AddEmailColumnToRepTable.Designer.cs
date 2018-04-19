﻿// <auto-generated />
using PartnerManagement.Models;
using PartnerManagement.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace PartnerManagement.Migrations
{
    [DbContext(typeof(CustomersGateContext))]
    [Migration("20180328152134_AddEmailColumnToRepTable")]
    partial class AddEmailColumnToRepTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartnerManagement.Models.EmailSender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UniversalIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("EmailSenders");
                });

            modelBuilder.Entity("PartnerManagement.Models.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("HtmlTemplate")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UniversalIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("PartnerManagement.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArabicName")
                        .IsRequired();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("EnglishName")
                        .IsRequired();

                    b.Property<string>("UniversalIP")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EnglishName")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PartnerManagement.Models.ProductEdition", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArabicName")
                        .IsRequired();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("EnglishName")
                        .IsRequired();

                    b.Property<string>("UniversalIP")
                        .IsRequired();

                    b.HasKey("ProductId", "Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProductId", "EnglishName")
                        .IsUnique();

                    b.ToTable("ProductEdition");
                });

            modelBuilder.Entity("PartnerManagement.Models.Representative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("Continuous");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PersonalPhone");

                    b.Property<string>("Phone");

                    b.Property<string>("Position");

                    b.Property<string>("UniversalIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Representatives");
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQ", b =>
                {
                    b.Property<int>("RFQId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CompanyArabicName");

                    b.Property<string>("CompanyEnglishName")
                        .IsRequired();

                    b.Property<string>("ContactPersonArabicName");

                    b.Property<string>("ContactPersonEmail")
                        .IsRequired();

                    b.Property<string>("ContactPersonEnglishName")
                        .IsRequired();

                    b.Property<string>("ContactPersonMobile")
                        .IsRequired();

                    b.Property<string>("ContactPersonPosition");

                    b.Property<string>("Location");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("RFQCode")
                        .IsRequired();

                    b.Property<int>("SelectedEditionId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("datetime");

                    b.Property<int>("TargetedProductId");

                    b.Property<string>("UniversalIP")
                        .IsRequired();

                    b.Property<string>("Website");

                    b.HasKey("RFQId");

                    b.HasIndex("ContactPersonEmail")
                        .IsUnique();

                    b.HasIndex("RFQCode")
                        .IsUnique();

                    b.HasIndex("TargetedProductId", "SelectedEditionId");

                    b.ToTable("RFQs");
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionCode")
                        .IsRequired();

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("datetime");

                    b.Property<int>("ActionType");

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<int>("RFQId");

                    b.Property<int>("RepresentativeId");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UniversalIP")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActionCode")
                        .IsUnique();

                    b.HasIndex("RFQId");

                    b.HasIndex("RepresentativeId");

                    b.ToTable("RFQAction");
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQActionAtt", b =>
                {
                    b.Property<int>("RFQActionId");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<string>("FileUrl");

                    b.Property<string>("Value");

                    b.HasKey("RFQActionId", "FileName");

                    b.ToTable("RFQActionAtt");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PartnerManagement.Models.ProductEdition", b =>
                {
                    b.HasOne("PartnerManagement.Models.Product", "Product")
                        .WithMany("ProductEditions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQ", b =>
                {
                    b.HasOne("PartnerManagement.Models.Product", "TargetedProduct")
                        .WithMany("RFQs")
                        .HasForeignKey("TargetedProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PartnerManagement.Models.ProductEdition", "SelectedEdition")
                        .WithMany("RFQs")
                        .HasForeignKey("TargetedProductId", "SelectedEditionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQAction", b =>
                {
                    b.HasOne("PartnerManagement.Models.RFQ", "RFQ")
                        .WithMany("RFQActions")
                        .HasForeignKey("RFQId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PartnerManagement.Models.Representative", "Representative")
                        .WithMany("RFQActions")
                        .HasForeignKey("RepresentativeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PartnerManagement.Models.RFQActionAtt", b =>
                {
                    b.HasOne("PartnerManagement.Models.RFQAction", "RFQAction")
                        .WithMany("RFQActionAtts")
                        .HasForeignKey("RFQActionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
