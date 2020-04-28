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
    [Migration("20200428195518_TokenUpdate2")]
    partial class TokenUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webApiNew3.Models.Account", b =>
                {
                    b.Property<int>("accountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<string>("login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accountId");

                    b.HasIndex("customerId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("webApiNew3.Models.Address", b =>
                {
                    b.Property<int>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("build")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("customerId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("addressId");

                    b.HasIndex("customerId");

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

            modelBuilder.Entity("webApiNew3.Models.Token", b =>
                {
                    b.Property<long>("tokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("accountId")
                        .HasColumnType("int");

                    b.Property<int>("expiredIn")
                        .HasColumnType("int");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tokenId");

                    b.HasIndex("accountId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("webApiNew3.Models.Account", b =>
                {
                    b.HasOne("webApiNew3.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webApiNew3.Models.Address", b =>
                {
                    b.HasOne("webApiNew3.Models.Customer", null)
                        .WithMany("Address")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webApiNew3.Models.Token", b =>
                {
                    b.HasOne("webApiNew3.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("accountId");
                });
#pragma warning restore 612, 618
        }
    }
}
