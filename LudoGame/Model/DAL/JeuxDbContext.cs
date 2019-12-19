using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Model;
using Microsoft.EntityFrameworkCore;

namespace LudoGame.Model.DAL
{
    class JeuxDbContext : DbContext 
    {
        public virtual DbSet<Jeu> Table_Jeu { get; set; }
        public virtual DbSet<ExtensionJeu> Table_Extension { get; set; }

        public JeuxDbContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=.\\Database\\LudoGameDb.db");
    }
}
