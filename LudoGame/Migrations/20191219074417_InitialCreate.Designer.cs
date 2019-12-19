﻿// <auto-generated />
using System;
using LudoGame.Model.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LudoGame.Migrations
{
    [DbContext(typeof(JeuxDbContext))]
    [Migration("20191219074417_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("LudoGame.Model.ExtensionJeu", b =>
                {
                    b.Property<int>("IdExtension")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgeMin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheminImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DureeMoyenne")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Editeur")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdJeu")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbJoueursMax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbJoueursMin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.HasKey("IdExtension");

                    b.HasIndex("IdJeu");

                    b.ToTable("Extension");
                });

            modelBuilder.Entity("LudoGame.Model.Jeu", b =>
                {
                    b.Property<int>("IdJeu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgeMin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheminImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DureeMoyenne")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Editeur")
                        .HasColumnType("TEXT");

                    b.Property<int>("NbJoueursMax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbJoueursMin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.HasKey("IdJeu");

                    b.ToTable("Jeu");
                });

            modelBuilder.Entity("LudoGame.Model.ExtensionJeu", b =>
                {
                    b.HasOne("LudoGame.Model.Jeu", "JeuAssocie")
                        .WithMany("LesExtensionsDuJeu")
                        .HasForeignKey("IdJeu");
                });
#pragma warning restore 612, 618
        }
    }
}
