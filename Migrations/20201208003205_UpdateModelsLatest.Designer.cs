﻿// <auto-generated />
using System;
using ElectronicCars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicCars.Migrations
{
    [DbContext(typeof(ElectronicCarsDbContext))]
    [Migration("20201208003205_UpdateModelsLatest")]
    partial class UpdateModelsLatest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ElectronicCars.Core.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("SalesLocationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SalesLocationId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("ElectronicCars.Core.Models.SalesLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SalesLocations");
                });

            modelBuilder.Entity("ElectronicCars.Core.Models.Sale", b =>
                {
                    b.HasOne("ElectronicCars.Core.Models.SalesLocation", "SalesLocation")
                        .WithMany()
                        .HasForeignKey("SalesLocationId");

                    b.Navigation("SalesLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
