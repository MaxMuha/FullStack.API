﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WiloPump.Db;

#nullable disable

namespace WiloPump.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WiloPump.Db.Models.Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amperage")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("RatedSpeed")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"),
                            Amperage = 16.899999999999999,
                            Description = "Электродвигатель",
                            Name = "Трехфазный",
                            Power = 3,
                            Price = 1590m,
                            RatedSpeed = 2900
                        });
                });

            modelBuilder.Entity("WiloPump.Db.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"),
                            Description = "Материал корпуса",
                            Name = "Материал корпуса"
                        },
                        new
                        {
                            Id = new Guid("b6962658-3f60-4456-8df0-190e3b214204"),
                            Description = "Материал колеса",
                            Name = "Материал колеса"
                        });
                });

            modelBuilder.Entity("WiloPump.Db.Models.Pump", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("EngineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EngineId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HousingMaterialId")
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("LiquidTemperature")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LmpellerMaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MaterialId1")
                        .HasColumnType("uuid");

                    b.Property<int>("MaxPressure")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.HasIndex("EngineId1");

                    b.HasIndex("HousingMaterialId");

                    b.HasIndex("LmpellerMaterialId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("MaterialId1");

                    b.ToTable("Pumps");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f9631b1-76cf-42f7-bd64-aee4386c9cad"),
                            Description = "Трехскоростной циркуляционный насос",
                            EngineId = new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"),
                            HousingMaterialId = new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"),
                            Image = "Изображение",
                            LiquidTemperature = "-10,+110",
                            LmpellerMaterialId = new Guid("b6962658-3f60-4456-8df0-190e3b214204"),
                            MaxPressure = 10,
                            Name = "NOC 25/8 EM",
                            Price = 13500m,
                            Weight = 3.7999999999999998
                        });
                });

            modelBuilder.Entity("WiloPump.Db.Models.Pump", b =>
                {
                    b.HasOne("WiloPump.Db.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WiloPump.Db.Models.Engine", null)
                        .WithMany("Pumps")
                        .HasForeignKey("EngineId1");

                    b.HasOne("WiloPump.Db.Models.Material", "HousingMaterial")
                        .WithMany()
                        .HasForeignKey("HousingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WiloPump.Db.Models.Material", "LmpellerMaterial")
                        .WithMany()
                        .HasForeignKey("LmpellerMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WiloPump.Db.Models.Material", null)
                        .WithMany("HousingMaterialPumps")
                        .HasForeignKey("MaterialId");

                    b.HasOne("WiloPump.Db.Models.Material", null)
                        .WithMany("LmpellerMaterialPumps")
                        .HasForeignKey("MaterialId1");

                    b.Navigation("Engine");

                    b.Navigation("HousingMaterial");

                    b.Navigation("LmpellerMaterial");
                });

            modelBuilder.Entity("WiloPump.Db.Models.Engine", b =>
                {
                    b.Navigation("Pumps");
                });

            modelBuilder.Entity("WiloPump.Db.Models.Material", b =>
                {
                    b.Navigation("HousingMaterialPumps");

                    b.Navigation("LmpellerMaterialPumps");
                });
#pragma warning restore 612, 618
        }
    }
}
