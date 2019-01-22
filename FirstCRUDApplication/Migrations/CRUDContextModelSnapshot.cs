﻿// <auto-generated />
using FirstCRUDApplication.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FirstCRUDApplication.Migrations
{
    [DbContext(typeof(CoffeeContext))]
    partial class CRUDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coffee.DbEntities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("PostId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Coffee.DbEntities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<bool>("IsAproved");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Coffee.DbEntities.Mapping.UserCompany", b =>
                {
                    b.Property<long>("CompanyId");

                    b.Property<long>("UserId");

                    b.Property<double>("Points");

                    b.HasKey("CompanyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompany");
                });

            modelBuilder.Entity("Coffee.DbEntities.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyId");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<int>("Likes");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Coffee.DbEntities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Coffee.DbEntities.Seller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<long>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsSeller");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Photo");

                    b.Property<string>("RefreshToken");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Coffee.DbEntities.SellerRole", b =>
                {
                    b.Property<long>("RoleId");

                    b.Property<long>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("SellerRole");
                });

            modelBuilder.Entity("Coffee.DbEntities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsConfirm");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("RefreshToken")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Coffee.DbEntities.Comment", b =>
                {
                    b.HasOne("Coffee.DbEntities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coffee.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffee.DbEntities.Mapping.UserCompany", b =>
                {
                    b.HasOne("Coffee.DbEntities.Company", "Company")
                        .WithMany("UserCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coffee.DbEntities.User", "User")
                        .WithMany("UserCompany")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffee.DbEntities.Post", b =>
                {
                    b.HasOne("Coffee.DbEntities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffee.DbEntities.Seller", b =>
                {
                    b.HasOne("Coffee.DbEntities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffee.DbEntities.SellerRole", b =>
                {
                    b.HasOne("Coffee.DbEntities.Role", "Role")
                        .WithMany("SellerRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coffee.DbEntities.Seller", "Seller")
                        .WithMany("SellerRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
