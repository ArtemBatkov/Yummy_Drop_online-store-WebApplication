﻿// <auto-generated />
using System;
using DbContextSharLab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YummyDrop_online_store.Data;

#nullable disable

namespace YummyDrop_online_store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230413190924_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YummyDrop_online_store.Models.FruitBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FruitBoxTable");
                });

            modelBuilder.Entity("YummyDrop_online_store.Models.YummyItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("DropChance")
                        .HasColumnType("float");

                    b.Property<int?>("FruitBoxId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FruitBoxId");

                    b.ToTable("YummyItem");
                });

            modelBuilder.Entity("YummyDrop_online_store.Models.YummyItem", b =>
                {
                    b.HasOne("YummyDrop_online_store.Models.FruitBox", null)
                        .WithMany("BoxContent1")
                        .HasForeignKey("FruitBoxId");
                });

            modelBuilder.Entity("YummyDrop_online_store.Models.FruitBox", b =>
                {
                    b.Navigation("BoxContent1");
                });
#pragma warning restore 612, 618
        }
    }
}
