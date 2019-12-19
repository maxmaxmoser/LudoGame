using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{

    /// <summary>
    /// Classe représentant une extension d'un jeu de société.
    /// Elle hérite de la classe abstraite ElementsJeu et dispose d'un Jeu de société auquel elle est associée.
    /// </summary>
    [Table("Extension")]
    class ExtensionJeu : ElementJeu
    {

        
        private int idExtension;
        [Key]
        public int IdExtension
        {
            get => idExtension;
            set
            {
                idExtension = value;
                NotifyPropertyChanged();
            }
        }

        // Jeu associé à l'extension
        private Jeu jeuAssocie;

        [ForeignKey("IdJeu")]
        public Jeu JeuAssocie
        {
            get => jeuAssocie;

            set
            {
                jeuAssocie = value;
                NotifyPropertyChanged();
            }
        }

        public ExtensionJeu() : base()
        {

        }

        /// <summary>
        /// Constructeur d'un jeu qui reprend les propriétés de la classe parente. A sa création, la liste d'extensions est initialisée.
        /// </summary>
        public ExtensionJeu(string nom = "", string editeur = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, int dureeMoyenne = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, editeur, nbJoueurmin, nbJoueursMax, ageMin, prix, dureeMoyenne, description, cheminImage)
        {
            this.JeuAssocie = jeuAssocie;
        }
        
    }
}
