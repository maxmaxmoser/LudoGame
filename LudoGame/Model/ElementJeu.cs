using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace LudoGame.Model
{
    /// <summary>
    /// Classe abstraite contenant les propriété communes entre les Jeu et les extensions.
    ///      
    /// Implémentente l'interface INotifyPropertyChanged, afin d'informer la vue des changements de valeurs(par le biais des ViewModel).
    /// </summary>
    abstract class ElementJeu : INotifyPropertyChanged
    {
        #region Champs et propriétés 

        private string nom;
        private string description;
        private int nbJoueursMin;
        private int nbJoueursMax;
        private int ageMin;
        private double prix;
        private string cheminImage;   

        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public int NbJoueursMin
        {
            get => nbJoueursMin;
            set
            {
                nbJoueursMin = value;
                NotifyPropertyChanged();
            }
        }

        public int NbJoueursMax
        {
            get => nbJoueursMax;
            set
            {
                nbJoueursMax = value;
                NotifyPropertyChanged();
            }
        }

        public int AgeMin
        {
            get => ageMin;
            set
            {
                ageMin = value;
                NotifyPropertyChanged();
            }
        }

        public double Prix
        {
            get => prix;
            set
            {
                prix = value;
                NotifyPropertyChanged();
            }
        }

        public string CheminImage
        {
            get => cheminImage;
            set
            {
                cheminImage = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        // Evenement permettant de remonter la modification d'une propriété
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructeur

        /// <summary>
        /// Constructeur initial des propriétés communes des jeux et des extensions.
        /// 
        /// Chaque variable à une valeur par défaut qui est définie dans les classes filles
        /// </summary>
        /// <param name="nom">Nom de l'élément</param>
        /// <param name="nbJoueurmin">Nombre minimal de joueurs</param>
        /// <param name="nbJoueursMax">Nombre maximal de joueurs</param>
        /// <param name="ageMin">Age minimal requis pour jouer</param>
        /// <param name="prix">Prix d'acquisition du jeu</param>
        /// <param name="description">Description ou résumé du jeu</param>
        /// <param name="cheminImage">Emplacement de l'image associée au jeu</param>
        public ElementJeu(string nom, int nbJoueurmin, int nbJoueursMax, int ageMin, double prix, string description, string cheminImage)
        {
            this.Nom = nom;
            this.NbJoueursMin = nbJoueurmin;
            this.nbJoueursMax = nbJoueursMax;
            this.AgeMin = ageMin;
            this.Prix = prix;
            this.Description = description;
            this.CheminImage = cheminImage;
        }

        #endregion

        /// <summary>
        /// Fonction appellée dans les différents mutateurs (set) des propriétés pour informer la vue de la modification 
        /// </summary>
        /// <param name="propertyname">Nom de la propriété modifiée, elle est automatiquement sélectionnée lors de l'appel de la fonction dans le setter.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
