using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    /// <summary>
    /// Classe représentant un jeu de société.
    /// Elle hérite de la classe abstraite ElementsJeu et dispose d'une liste d'extensions qui lui appartiennent.
    /// </summary>
    class Jeu : ElementJeu
    {
        // Collection d'extensions associées au jeu
        private ObservableCollection<ExtensionJeu> lesExtensionsDuJeu;
        public ObservableCollection<ExtensionJeu> LesExtensionsDuJeu
        {
            get => lesExtensionsDuJeu;

            set
            {
                lesExtensionsDuJeu = value;
                NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// Constructeur d'un jeu qui reprend les propriétés de la classe parente. A sa création, la liste d'extensions est initialisée.
        /// </summary>
        public Jeu(string nom = "", string editeur = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, int dureeMoyenne = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, editeur, nbJoueurmin, nbJoueursMax, ageMin, prix, dureeMoyenne, description, cheminImage) 
        {
            this.lesExtensionsDuJeu = new ObservableCollection<ExtensionJeu>();
        }

        /// <summary>
        /// Ajout d'une nouvelle extension associée au jeu.
        /// </summary>
        /// <param name="extension">L'instance d'extension à y ajouter.</param>
        public void addExtension(ExtensionJeu extension)
        {
            LesExtensionsDuJeu.Add(extension);
        }
    }
}
