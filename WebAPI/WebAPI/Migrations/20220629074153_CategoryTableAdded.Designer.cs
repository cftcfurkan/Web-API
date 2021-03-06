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
    [Migration("20220629074153_CategoryTableAdded")]
    partial class CategoryTableAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Elektronik"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Giyim"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

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

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 6, 28, 10, 41, 53, 188, DateTimeKind.Local).AddTicks(7253),
                            Name = "Bilgisayar",
                            Price = 1000m,
                            Stock = 500
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 6, 27, 10, 41, 53, 188, DateTimeKind.Local).AddTicks(7269),
                            Name = "Telefon",
                            Price = 1800m,
                            Stock = 700
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 6, 25, 10, 41, 53, 188, DateTimeKind.Local).AddTicks(7270),
                            Name = "Klavye",
                            Price = 200m,
                            Stock = 300
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Product", b =>
                {
                    b.HasOne("WebAPI.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebAPI.Data.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
