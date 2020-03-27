using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Model;
using Microsoft.EntityFrameworkCore;

namespace LudoGame.Model.DAL
{
    /// <summary>
    /// Classe d'accès à la base des données SQLite.
    ///      
    /// Cette classe implémente l'interface DbContext qui provient du framework Entity.
    /// </summary>
    public class JeuxDbContext : DbContext 
    {

        // Déclaration du DBset qui représentera la table Jeu.
        public virtual DbSet<Jeu> Table_Jeu { get; set; }

        // Déclaration du DBset qui représentera la table Extension.
        public virtual DbSet<ExtensionJeu> Table_Extension { get; set; }

        public JeuxDbContext() {}

        /// <summary>
        /// Surcharge de la méthode dédiée à la configuration de la BDD (pour indiquer l'emplacement de la BDD à générer ainsi que son type).
        /// </summary>
        /// <param name="options">Variable contenant les options lors de la configuration du DbContext.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=.\\Database\\LudoGameDb.db");

        /// <summary>
        /// Surcharge de la méthode dédiée à la création des tables de la BDD (pour y indiquer  les relations entre les objets).
        /// </summary>
        /// <param name="builder">Variable contenant les paramêtres de création des tables.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Jeu>()
                .HasMany(b => b.LesExtensionsDuJeu)
                .WithOne(p => p.JeuAssocie)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
