﻿// <auto-generated />
using LudoGame.Model.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LudoGame.Migrations
{
    [DbContext(typeof(JeuxDbContext))]
    [Migration("20191217103745_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("LudoGame.Model.ExtensionJeu", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("ExtensionJeu");
                });

            modelBuilder.Entity("LudoGame.Model.Jeu", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Jeu");
                });

            modelBuilder.Entity("LudoGame.Model.ExtensionJeu", b =>
                {
                    b.HasOne("LudoGame.Model.Jeu", "JeuAssocie")
                        .WithMany("LesExtensionsDuJeu")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
