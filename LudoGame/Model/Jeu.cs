using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    /// <summary>
    /// Classe représentant un jeu de société.
    /// Elle hérite de la classe abstraite ElementsJeu et dispose d'une liste d'extensions qui lui appartiennent.
    /// </summary>
    // Tag utilisé par le framework Entity
    [Table("Jeu")]
    public class Jeu : ElementJeu
    {
        private int idJeu;
        [Key]
        public int IdJeu
        {
            get => idJeu;
            set
            {
                idJeu = value;
                NotifyPropertyChanged();
            }
        }

        // Collection d'extensions associées au jeu
        private ObservableCollection<ExtensionJeu> lesExtensionsDuJeu = new ObservableCollection<ExtensionJeu>();
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
        /// Constructeur vierge.
        /// </summary>
        public Jeu() : base()
        {
        }

        /// <summary>
        /// Constructeur prenant uniquement le chemin de l'Image en paramètre.
        /// </summary>
        /// <param name="cheminImage"></param>
        public Jeu(string cheminImage = "/Pictures/Board_picture_dummy.png") : base(cheminImage)
        {

        }

        /// <summary>
        /// Constructeur d'un jeu qui reprend les propriétés de la classe parente. A sa création, la liste d'extensions est initialisée.
        /// </summary>
        public Jeu(string nom = "", string editeur = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, int dureeMoyenne = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, editeur, nbJoueurmin, nbJoueursMax, ageMin, prix, dureeMoyenne, description, cheminImage) 
        {
        }
        
        /// <summary>
        /// Ajout d'une nouvelle extension associée au jeu.
        /// </summary>
        /// <param name="extension">L'instance d'extension à y ajouter.</param>
        public void AddExtension(ExtensionJeu extension)
        {
            LesExtensionsDuJeu.Add(extension);
        }

        /// <summary>
        /// Obtention du nombre d'extensions ratachées au jeu.
        /// </summary>
        public int GetNumberOfExtensions()
        {
            return this.LesExtensionsDuJeu.Count;
        }


        /// <summary>
        /// Obtention du prix ajouté par les extensions du jeu.
        /// </summary>
        private double GetPriceAddedByExtensions()
        {
            double prixExtensions = 0;

            foreach(ExtensionJeu extensionJeu in LesExtensionsDuJeu)
            {
                prixExtensions += extensionJeu.Prix;
            }
            return prixExtensions;
        }

        /// <summary>
        /// Obtention du prix total d'un jeu et de ses extensions.
        /// </summary>
        public double GetPricewithAddons()
        {
            return this.Prix + GetPriceAddedByExtensions();
        }

        /// <summary>
        /// Obtention de la durée ajoutée par les extensions du jeu en minutes.
        /// </summary>
        private int GetDurationAddedByExtensions()
        {
            int dureeExtensions = 0;

            foreach (ExtensionJeu extensionJeu in LesExtensionsDuJeu)
            {
                dureeExtensions += extensionJeu.DureeMoyenne;
            }
            return dureeExtensions;
        }

        /// <summary>
        /// Obtention de la durée moyenne totale d'un jeu avec ses extensions en minutes.
        /// </summary>
        public int GetDurationwithAddons()
        {
            return this.DureeMoyenne + GetDurationAddedByExtensions();
        }
    }
}