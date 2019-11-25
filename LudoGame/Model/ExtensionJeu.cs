using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    /// <summary>
    /// Classe représentant une extension d'un jeu de société.
    /// Elle hérite de la classe abstraite ElementsJeu et dispose d'un Jeu de société auquel elle est associée.
    /// </summary>
    class ExtensionJeu : ElementJeu
    {
        // Jeu associé à l'extension
        private Jeu jeuAssocie;
        public Jeu JeuAssocie
        {
            get => jeuAssocie;

            set
            {
                jeuAssocie = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Constructeur d'un jeu qui reprend les propriétés de la classe parente. A sa création, la liste d'extensions est initialisée.
        /// </summary>
        public ExtensionJeu(Jeu jeuAssocie, string nom = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, nbJoueurmin, nbJoueursMax, ageMin, prix, description, cheminImage)
        {
            this.JeuAssocie = jeuAssocie;
        }
    }
}
