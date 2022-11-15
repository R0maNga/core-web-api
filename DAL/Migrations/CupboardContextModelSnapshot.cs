﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(CupboardContext))]
    partial class CupboardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.Clothes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClothesEntities");
                });

            modelBuilder.Entity("DAL.Entities.Cupboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("CupboardEntities");
                });

            modelBuilder.Entity("DAL.Entities.CupboardClothes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClothesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CupboardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.HasIndex("CupboardId");

                    b.ToTable("CupboardClothesEntities");
                });

            modelBuilder.Entity("DAL.Entities.CupboardModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CupboardModelEntities");
                });

            modelBuilder.Entity("DAL.Entities.Cupboard", b =>
                {
                    b.HasOne("DAL.Entities.CupboardModel", "CupboardModel")
                        .WithMany("Cupboards")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CupboardModel");
                });

            modelBuilder.Entity("DAL.Entities.CupboardClothes", b =>
                {
                    b.HasOne("DAL.Entities.Clothes", "Clothes")
                        .WithMany("CupboardClothes")
                        .HasForeignKey("ClothesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Cupboard", "Cupboard")
                        .WithMany("CupboardClothes")
                        .HasForeignKey("CupboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothes");

                    b.Navigation("Cupboard");
                });

            modelBuilder.Entity("DAL.Entities.Clothes", b =>
                {
                    b.Navigation("CupboardClothes");
                });

            modelBuilder.Entity("DAL.Entities.Cupboard", b =>
                {
                    b.Navigation("CupboardClothes");
                });

            modelBuilder.Entity("DAL.Entities.CupboardModel", b =>
                {
                    b.Navigation("Cupboards");
                });
#pragma warning restore 612, 618
        }
    }
}
