﻿// <auto-generated />
using ApiNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiNet.Migrations
{
    [DbContext(typeof(TiendaDBContext))]
    [Migration("20200510205327_OctavaMigracion")]
    partial class OctavaMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiNet.Models.EstadoPedidoModel", b =>
                {
                    b.Property<long>("IdEstadoPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdEstadoPedido");

                    b.ToTable("estadosPedidos");
                });

            modelBuilder.Entity("ApiNet.Models.PedidoModel", b =>
                {
                    b.Property<long>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("AhorroTotal")
                        .HasColumnType("double");

                    b.Property<long>("IdEstadoPedido")
                        .HasColumnType("bigint");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdEstadoPedido");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("ApiNet.Models.PedidoModel", b =>
                {
                    b.HasOne("ApiNet.Models.EstadoPedidoModel", "EstadoPedido")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdEstadoPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
