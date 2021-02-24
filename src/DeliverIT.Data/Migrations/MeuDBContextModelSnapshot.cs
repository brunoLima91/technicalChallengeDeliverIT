﻿// <auto-generated />
using System;
using DeliverIT.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliverIT.Data.Migrations
{
    [DbContext(typeof(MeuDBContext))]
    partial class MeuDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliverIT.Business.Models.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("DeliverIT.Business.Models.MemoriaCalculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("JurosDiaPercentual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MultaPercentualAplicada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantidadeDiasEmAtraso")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCorrigido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("MemoriaCalculo");
                });

            modelBuilder.Entity("DeliverIT.Business.Models.MemoriaCalculo", b =>
                {
                    b.HasOne("DeliverIT.Business.Models.Conta", null)
                        .WithOne("MemoriaCalculo")
                        .HasForeignKey("DeliverIT.Business.Models.MemoriaCalculo", "ContaId")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliverIT.Business.Models.Conta", b =>
                {
                    b.Navigation("MemoriaCalculo");
                });
#pragma warning restore 612, 618
        }
    }
}