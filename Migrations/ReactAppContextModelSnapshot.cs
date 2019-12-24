﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactApi.Repository;

namespace ReactApi.Migrations
{
    [DbContext(typeof(ReactAppContext))]
    partial class ReactAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactApi.Models.Grocery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Caloreis");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Name");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Grocery");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Caloreis = 144m,
                            Cost = 89m,
                            Name = "Grocery 1",
                            Weight = 66m
                        },
                        new
                        {
                            Id = 2,
                            Caloreis = 1244m,
                            Cost = 849m,
                            Name = "Grocery 2",
                            Weight = 776m
                        },
                        new
                        {
                            Id = 3,
                            Caloreis = 164m,
                            Cost = 84m,
                            Name = "Grocery 3",
                            Weight = 56m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
