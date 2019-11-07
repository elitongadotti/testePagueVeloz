﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagueVeloz.Teste.Infra.Data;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    [DbContext(typeof(PagueVelozContext))]
    [Migration("20191107010209_correcao_mapeanto_hasmaxlength")]
    partial class correcao_mapeanto_hasmaxlength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NomeFantasia")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnName("Uf")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("VarChar")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Empresa", b =>
                {
                    b.OwnsOne("PagueVeloz.Teste.Domain.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Cnpj")
                                .HasColumnType("varchar(14)")
                                .HasMaxLength(14);

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Fornecedor", b =>
                {
                    b.HasOne("PagueVeloz.Teste.Domain.Empresa", "Empresa")
                        .WithMany("Fornecedores")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PagueVeloz.Teste.Domain.DataNascimento", "DataNascimento", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnName("DataNascimento")
                                .HasColumnType("DateTime");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsOne("PagueVeloz.Teste.Domain.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Documento")
                                .HasColumnType("VarChar")
                                .HasMaxLength(15);

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsOne("PagueVeloz.Teste.Domain.Rg", "Rg", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnName("Rg")
                                .HasColumnType("VarChar")
                                .HasMaxLength(10);

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsMany("PagueVeloz.Teste.Domain.Telefone", "Telefones", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Telefone")
                                .HasColumnType("VarChar")
                                .HasMaxLength(15);

                            b1.HasKey("FornecedorId", "Id");

                            b1.ToTable("Telefone");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
