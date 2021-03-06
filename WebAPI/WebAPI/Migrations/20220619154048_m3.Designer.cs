// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20220619154048_m3")]
    partial class m3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 6, 18, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9944),
                            Name = "Bilgisayar",
                            Price = 1000m,
                            Stock = 500
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 6, 17, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9957),
                            Name = "Telefon",
                            Price = 1800m,
                            Stock = 700
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 6, 15, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9958),
                            Name = "Klavye",
                            Price = 200m,
                            Stock = 300
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
