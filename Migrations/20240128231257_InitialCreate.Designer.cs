﻿// <auto-generated />
using System;
using EfDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfDemo.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20240128231257_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("EfDemo.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EfDemo.Share", b =>
                {
                    b.Property<int>("ShareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ShareAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("ShareId");

                    b.HasIndex("AccountId");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("EfDemo.Share", b =>
                {
                    b.HasOne("EfDemo.Account", null)
                        .WithMany("Shares")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("EfDemo.Account", b =>
                {
                    b.Navigation("Shares");
                });
#pragma warning restore 612, 618
        }
    }
}
