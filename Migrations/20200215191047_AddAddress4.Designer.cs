﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApiNew3.Models;

namespace webApiNew3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200215191047_AddAddress4")]
    partial class AddAddress4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webApiNew3.Models.Address", b =>
                {
                    b.Property<int>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("build")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("addressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("webApiNew3.Models.Customer", b =>
                {
                    b.Property<long>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("birthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
