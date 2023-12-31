﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopCardService.Infrastructure.Contexts;

#nullable disable

namespace ShopCardService.Infrastructure.Migrations
{
    [DbContext(typeof(CartContext))]
    partial class CartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopCartService.Domain.Entities.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ShopCartService.Domain.Entities.CartItem", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductId"));

                    b.Property<long?>("CartId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ShopCartService.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("ShopCartService.Domain.Entities.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("ShopCartService.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
