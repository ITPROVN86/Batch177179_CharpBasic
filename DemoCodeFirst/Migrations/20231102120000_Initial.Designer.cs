﻿// <auto-generated />
using DemoCodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoCodeFirst.Migrations
{
    [DbContext(typeof(MyStockDBContext))]
    [Migration("20231102120000_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoCodeFirst.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Telephone"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Computer"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Print"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Scanner"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Screen"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
