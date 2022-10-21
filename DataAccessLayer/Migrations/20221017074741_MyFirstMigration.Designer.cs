﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221017074741_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AboutDetails1")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDetails2")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage2")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutMapLocation")
                        .HasColumnType("longtext");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Advert", b =>
                {
                    b.Property<int>("AdvertID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AdvertCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AdvertDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertImage2")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertImage3")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertImage4")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertImage5")
                        .HasColumnType("longtext");

                    b.Property<string>("AdvertName")
                        .HasColumnType("longtext");

                    b.Property<decimal>("AdvertPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("AdvertSaleType")
                        .HasColumnType("longtext");

                    b.Property<bool>("AdvertStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("AdvertThumbnail")
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("HousingAge")
                        .HasColumnType("int");

                    b.Property<int>("HousingHallQuantity")
                        .HasColumnType("int");

                    b.Property<int>("HousingRoomQuantity")
                        .HasColumnType("int");

                    b.Property<int>("HousingSquareMeters")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AdvertID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ContactMail")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("longtext");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("longtext");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<bool>("UserStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Advert", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Adverts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany("Adverts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Adverts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("Adverts");
                });
#pragma warning restore 612, 618
        }
    }
}
