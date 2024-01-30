﻿// <auto-generated />
using System;
using FoodDeliveryAPI.DataAcces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodDeliveryAPI.DataAcces.Migrations
{
    [DbContext(typeof(FoodDeliveryAPIContext))]
<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
    [Migration("20240130081635_InitialCreate")]
========
    [Migration("20240129074503_InitialCreate")]
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Admin", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
                    b.ToTable("Admins");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

========
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.DeliveryPerson", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("DeliveryPersons");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isOutOfStock")
                        .HasColumnType("bit");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ValidStatuses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryPersonId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Restaurant", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Item", b =>
                {
                    b.HasOne("FoodDeliveryAPI.Domain.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("FoodDeliveryAPI.Domain.Models.Restaurant", "Restaurant")
                        .WithMany("Items")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Order", b =>
                {
<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
                    b.HasOne("FoodDeliveryAPI.Domain.Models.Customer", "Customer")
========
                    b.HasOne("FoodDeliveryAPI.Models.Customer", "Customer")
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
                    b.HasOne("FoodDeliveryAPI.Domain.Models.DeliveryPerson", "DeliveryPerson")
========
                    b.HasOne("FoodDeliveryAPI.Models.DeliveryPerson", "DeliveryPerson")
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                        .WithMany("AllOrders")
                        .HasForeignKey("DeliveryPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
                    b.HasOne("FoodDeliveryAPI.Domain.Models.Restaurant", "Restaurant")
========
                    b.HasOne("FoodDeliveryAPI.Models.Restaurant", "Restaurant")
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DeliveryPerson");

                    b.Navigation("Restaurant");
                });

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Customer", b =>
========
            modelBuilder.Entity("FoodDeliveryAPI.Models.Customer", b =>
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                {
                    b.Navigation("Orders");
                });

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.DeliveryPerson", b =>
========
            modelBuilder.Entity("FoodDeliveryAPI.Models.DeliveryPerson", b =>
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                {
                    b.Navigation("AllOrders");
                });

<<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Migrations/20240130081635_InitialCreate.Designer.cs
            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Order", b =>
========
            modelBuilder.Entity("FoodDeliveryAPI.Models.Order", b =>
>>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI.DataAcces/Migrations/20240129074503_InitialCreate.Designer.cs
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FoodDeliveryAPI.Domain.Models.Restaurant", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
