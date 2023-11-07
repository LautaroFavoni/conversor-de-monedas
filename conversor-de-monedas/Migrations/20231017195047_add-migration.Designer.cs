﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using conversor_de_monedas.Data;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    [DbContext(typeof(ConversorContext))]
    [Migration("20231017195047_add-migration")]
    partial class addmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMonedaDestino")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMonedaOrigen")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdMonedaDestino");

                    b.HasIndex("IdMonedaOrigen");

                    b.HasIndex("IdUser");

                    b.ToTable("Conversion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdMonedaDestino = 2,
                            IdMonedaOrigen = 1,
                            IdUser = 1,
                            fecha = new DateTime(2023, 10, 17, 16, 50, 47, 15, DateTimeKind.Local).AddTicks(9149)
                        });
                });

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("valor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Monedas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Peso Argentino",
                            Sigla = "ARS",
                            valor = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dolar EEUU",
                            Sigla = "USD",
                            valor = 1000
                        });
                });

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.Suscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TirosMax")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("suscripciones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Comun",
                            TirosMax = 5
                        },
                        new
                        {
                            Id = 2,
                            Name = "Premiun",
                            TirosMax = 9999
                        });
                });

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SuscripcionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tiros")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SuscripcionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "email2@gmail.com",
                            Password = "password",
                            SuscripcionId = 2,
                            Tiros = 0,
                            UserName = "Jose"
                        },
                        new
                        {
                            Id = 1,
                            Email = "email@gmail.com",
                            Password = "password",
                            SuscripcionId = 1,
                            Tiros = 0,
                            UserName = "Lautaro"
                        });
                });

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.Conversion", b =>
                {
                    b.HasOne("conversor_de_monedas.Data.Entities.Moneda", "MonedaDestino")
                        .WithMany()
                        .HasForeignKey("IdMonedaDestino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("conversor_de_monedas.Data.Entities.Moneda", "MonedaOrigen")
                        .WithMany()
                        .HasForeignKey("IdMonedaOrigen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("conversor_de_monedas.Data.Entities.User", "UserConversor")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonedaDestino");

                    b.Navigation("MonedaOrigen");

                    b.Navigation("UserConversor");
                });

            modelBuilder.Entity("conversor_de_monedas.Data.Entities.User", b =>
                {
                    b.HasOne("conversor_de_monedas.Data.Entities.Suscripcion", "Suscripcion")
                        .WithMany()
                        .HasForeignKey("SuscripcionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suscripcion");
                });
#pragma warning restore 612, 618
        }
    }
}
