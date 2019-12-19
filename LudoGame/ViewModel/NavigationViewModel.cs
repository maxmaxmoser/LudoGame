using LudoGame.Model;
using LudoGame.Model.DAL;
using LudoGame.View.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LudoGame.ViewModel
{
    /// <summary>
    /// ViewModel rataché à la fenêtre de l'application. 
    /// Permet la navigation entre les différentes pages et met à disposition des fonctions permettant d'échanger des données entre leur ViewModels.
    /// </summary>
    /// <remarks>
    /// - Il initialise les pages et les différents ViewModel tout en les reliants entre eux.
    /// - Chaque ViewModel dispose d'une propriété NavigationViewModel afin d'appeler ses fonctions.
    /// </remarks>
    class NavigationViewModel : BaseViewModel
    {
        #region Champs et propriétés

        // Le contexte de base de données
        public JeuxDbContext LudoGameDbContext = new JeuxDbContext();

        // Collection contenant les différentes pages de l'application
        private ObservableCollection<Page> lesPages;
        public ObservableCollection<Page> LesPages
        {
            get => lesPages;

            set
            {
                if (value != lesPages)
                {
                    lesPages = value;
                }
            }
        }

        // Collection contenant les différents ViewModels de l'application
        private List<BaseViewModel> lesViewModels;
        public List<BaseViewModel> LesViewModels { get; set; }

        // Variable permettant d'indiquer à la vue la page courante (qui doit donc être affichée dans la fenêtre de l'application
        private  Page pageCourante;
        public Page PageCourante
        {
            get => pageCourante;

            set
            {
                if (value != pageCourante)
                {
                    pageCourante = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialisation du ViewModel.
        /// Les différentes pages et ViewModels sont initialisés et reliés entre eux. La page d'accueil est ensuite désignée comme page courante.
        /// </summary>
        public NavigationViewModel()
        {
            LesViewModels = new List<BaseViewModel>();
            LesViewModels.Add(new ElementsJeuxViewModel(this));
            LesViewModels.Add(new DetailsViewModel(this));
            LesViewModels.Add(new StatistiquesViewModel(this));

            LesPages = new ObservableCollection<Page>();

            AddPageToNavigation(new HomePage(), LesViewModels[(int)EViewModels.JEU_VIEWMODEL]);
            AddPageToNavigation(new DetailsJeuPage(), LesViewModels[(int)EViewModels.DETAILS_VIEWMODEL]);
            AddPageToNavigation(new DetailsExtensionJeuPage(), LesViewModels[(int)EViewModels.DETAILS_VIEWMODEL]);
            AddPageToNavigation(new AddElementJeuPage(), LesViewModels[(int)EViewModels.DETAILS_VIEWMODEL]);
            AddPageToNavigation(new StatistiquesPage(), LesViewModels[(int)EViewModels.STATISTIQUES_VIEWMODEL]);

            PageCourante = LesPages[(int)ENomsPage.HOME_PAGE];
        }

        #endregion

        #region Fonctions et méthodes

        /// <summary>
        /// Fonction permettant de lier une page à la navigation (en lui indiquant son ViewModel qui fait office de datacontext).
        /// </summary>
        /// <param name="page"></param>
        /// <param name="dataContext"></param>
        private void AddPageToNavigation(Page page, BaseViewModel dataContext)
        {
            page.DataContext = dataContext;   
            lesPages.Add(page);
        }

        /// <summary>
        /// Affichage de la page d'acceuil.
        /// </summary>
        public void GoToMain()
        {
            PageCourante = LesPages[(int)ENomsPage.HOME_PAGE];
        }

        /// <summary>
        /// Affichage de la page de détails d'un élément de jeu de société.
        /// </summary>
        /// <param name="elementJeuSelectionne">L'élément de jeu dont on souhaite manipuler les détails</param>
        public  void GoToDetails(ElementJeu elementJeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.DETAILS_VIEWMODEL];
            detailsViewModel.ElementJeuSelectionne = elementJeuSelectionne;

            switch(elementJeuSelectionne.GetType().Name)
            {
                case "Jeu":
                {
                    PageCourante = LesPages[(int)ENomsPage.DETAILS_JEU_PAGE];
                    break;
                }

                case "ExtensionJeu":
                {
                    PageCourante = LesPages[(int)ENomsPage.DETAILS_EXTENSION_JEU_PAGE];
                    break;
                }
            }
            
        }

        /// <summary>
        /// Affichage de la page d'ajout d'un nouvel élément de jeu de société (jeu ou extension).
        /// </summary>
        /// <param name="elementJeuSelectionne">L'élément de jeu que l'on souhaite éditer avant un ajout (initialisé par les ViewModels des pages avant l'appel de cette fonction)</param>
        public void GoToAddGameElement(ElementJeu elementJeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.DETAILS_VIEWMODEL];
            detailsViewModel.ElementJeuSelectionne = elementJeuSelectionne;
            PageCourante = LesPages[(int)ENomsPage.ADD_GAME_PAGE];
        }


        /// <summary>
        /// Affichage de la page de statistiques.
        /// </summary>
        /// <param name="lesJeux"> La liste des éléments de jeux sur laquelle se basent les statistiques</param>
        public void GoToStatistics(List<Jeu> lesJeux)
        {
            StatistiquesViewModel statistiquesViewModel = (StatistiquesViewModel)LesViewModels[(int)EViewModels.STATISTIQUES_VIEWMODEL];
            statistiquesViewModel.LesJeux = lesJeux;
            statistiquesViewModel.loadStatistics();
            PageCourante = LesPages[(int)ENomsPage.STATISTIQUES_PAGES];
        }

        /// <summary>
        /// Ajout de l'élément de jeu à la liste affichée dans la page d'acceuil (collection utilisée par le ViewModel de la page d'accueil).
        /// </summary>
        /// <param name="elementJeuSelectionne">Jeu à ajouter dans la page d'acceuil</param>
        public void AddGameToViewModel(Jeu elementJeuSelectionne)
        {
            ((ElementsJeuxViewModel)LesViewModels[(int)EViewModels.JEU_VIEWMODEL]).AddGame(elementJeuSelectionne);
        }

        public void saveDbChanges()
        {
            this.LudoGameDbContext.SaveChanges();
        }
        #endregion
    }

    /// <summary>
    /// Enumération permettant de distinguer les différentes pages de l'application.
    /// </summary>
    enum ENomsPage
    {
        HOME_PAGE = 0,
        DETAILS_JEU_PAGE = 1,
        DETAILS_EXTENSION_JEU_PAGE = 2,
        ADD_GAME_PAGE = 3,    
        STATISTIQUES_PAGES = 4
    };

    /// <summary>
    /// Enumération permettant de distinguer les différents ViewModels de l'application.
    /// </summary>
    enum EViewModels
    {
        JEU_VIEWMODEL = 0,
        DETAILS_VIEWMODEL = 1,
        STATISTIQUES_VIEWMODEL = 2
    };
}
