using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using LudoGame.Model;
using LudoGame.View;
using System.Windows.Input;

namespace LudoGame.ViewModel
{
    /// <summary>
    /// ViewModel relié à la page d'acceuil.
    /// Permet d'afficher les jeux de société référencés, d'accéder à leurs détails, d'en ajouter et d'en supprimer.
    /// </summary>
    class ElementsJeuxViewModel : BaseViewModel
    {
        #region Champs et propriétés

        // Référence vers le ViewModel de navigation dans l'application.
        private NavigationViewModel navigationViewModel;
        public NavigationViewModel NavigationViewModel 
        { 
            get => navigationViewModel;
            set
            {
                if(value != navigationViewModel)
                {
                    navigationViewModel = value;
                    NotifyPropertyChanged();
                }
            }  
        }

        // Liste des éléments de jeux à afficher. Pour l'heure, seuls les jeux de société y figurent (sans les extensions).
        private ObservableCollection<ElementJeu> lesElementsDeJeux;
        public ObservableCollection<ElementJeu> LesElementsDeJeux
        {
            get => lesElementsDeJeux;

            set
            {
                if (value != lesElementsDeJeux)
                {
                    lesElementsDeJeux = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialisation du viewModel, pour l'heure, un jeu de données constitué de trois jeux alimente la liste des Jeux.
        /// La finalité sera que cette viewModel soit initialisée à partir d'une base de données.
        /// </summary>
        /// <remarks>
        /// Ce ViewModel est initialisé à partir du NavigationViewModel.
        /// </remarks>
        /// <param name="navigationViewModel">La référence vers le lien du ViewModel de navigation.</param>
        public ElementsJeuxViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            LesElementsDeJeux = new ObservableCollection<ElementJeu>();

            AddGame(new Jeu("Unlock", "Space Coboys",  1, 6, 10, 32.25, dureeMoyenne:60, cheminImage:"/Pictures/Board_picture_dummy.png"));
            Jeu carcassone = new Jeu("Carcassone", "Zman Games", 2, 6, 7, 70, dureeMoyenne:35, cheminImage: "/Pictures/Board_picture_dummy.png");
            AddExtensionTogame(carcassone, new ExtensionJeu(carcassone, "Carcassone : Auberges & Cathédrales", carcassone.Editeur, 2, 6, 7, 13.50, cheminImage: "/Pictures/Board_picture_dummy.png"));

            AddGame(carcassone);
            AddGame(new Jeu("Smallworld", "Days of wonder", 1, 5, 10, 80, 90,"Un jeu de conquêtes dans un univer fantastique", "/Pictures/Board_picture_dummy.png"));
        }

        #endregion

        #region Fonction et méthodes

        /// <summary>
        /// Ajout d'un jeu à la liste.
        /// </summary>
        /// <param name="jeu">Le jeu à ajouter.</param>
        public void AddGame(Jeu jeu)
        {
            LesElementsDeJeux.Add(jeu);
        }

        /// <summary>
        /// Suppression d'un jeu à la liste.
        /// </summary>
        /// <param name="jeu">Le jeu à ajouter.</param>
        public void RemoveGame(Jeu jeu)
        {
            LesElementsDeJeux.Remove(jeu);
        }

        /// <summary>
        /// Ajout d'une extension à un jeu.
        /// </summary>
        /// <param name="jeu">Le jeu auquel appartient l'extension.</param>
        /// <param name="extensionJeu">L'extension à ajouter.</param>
        public void AddExtensionTogame(Jeu jeu, ExtensionJeu extensionJeu)
        {
            jeu.addExtension(extensionJeu);
        }

        #endregion

        #region Commandes

        /// <summary>
        /// Suppression de la liste du jeu passé en paramètre de la commande (jeu sélectionné depuis l'interface).
        /// </summary>
        private ICommand removeGameCommand;
        public ICommand RemoveGameCommand
        {
            get
            {
                if (removeGameCommand == null)
                {
                    removeGameCommand = new RelayCommand<Jeu>((jeu) => RemoveGame(jeu));
                }
                return removeGameCommand;
            }
        }

        /// <summary>
        /// Commande pour accéder aux détails du jeu passé en paramètre de la commande (jeu sélectionné depuis l'interface).
        /// </summary>
        private ICommand goToDetailsCommand;
        public ICommand GoToDetailsCommand
        {
            get
            {
                if(goToDetailsCommand == null)
                {
                    goToDetailsCommand = new RelayCommand<ElementJeu>((elementJeu) => 
                    {
                        if(elementJeu != null)
                        { 
                            NavigationViewModel.GoToDetails(elementJeu);
                        }
                    });
                }
                return goToDetailsCommand;
            }
        }

        /// <summary>
        /// Commande pour accéder à la page de création d'un nouveau jeu.
        /// </summary>
        private ICommand goToAddGameCommand;
        public ICommand GoToAddGameCommand
        {
            get
            {
                if (goToAddGameCommand == null)
                {
                    goToAddGameCommand = new RelayCommand<Object>((obj) =>
                    {
                        NavigationViewModel.GoToAddGame(new Jeu());
                    });
                }
                return goToAddGameCommand;
            }
        }
        #endregion
    }
}
