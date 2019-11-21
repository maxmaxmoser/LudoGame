using LudoGame.Model;
using LudoGame.View.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LudoGame.ViewModel
{
    class NavigationViewModel : BaseViewModel
    {
        private ObservableCollection<Page> lesPages;
        public ObservableCollection<Page> LesPages
        {
            get => lesPages;

            set
            {
                if (value != lesPages)
                {
                    lesPages = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<BaseViewModel> lesViewModels;
        public List<BaseViewModel> LesViewModels { get; set; }

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

        public NavigationViewModel()
        {
            LesViewModels = new List<BaseViewModel>();
            LesViewModels.Add(new ElementsJeuxViewModel(this));
            LesViewModels.Add(new DetailsViewModel(this));

            LesPages = new ObservableCollection<Page>();

            AddPageToNavigation(new MainPage(), LesViewModels[(int)EViewModels.JEU_VIEWMODEL]);
            AddPageToNavigation(new DetailsJeuPage(), LesViewModels[(int)EViewModels.EDITION_VIEWMODEL]);
            AddPageToNavigation(new AddGamePage(), LesViewModels[(int)EViewModels.EDITION_VIEWMODEL]);

            PageCourante = LesPages[(int)ENomsPage.MAIN_PAGE];
        }

        private void AddPageToNavigation(Page page, BaseViewModel dataContext)
        {
            page.DataContext = dataContext;   
            lesPages.Add(page);
        }

        public void GoToMain()
        {
            PageCourante = LesPages[(int)ENomsPage.MAIN_PAGE];
        }

        public  void GoToDetails(ElementJeu elementJeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.EDITION_VIEWMODEL];
            detailsViewModel.JeuSelectionne = elementJeuSelectionne;
            PageCourante = LesPages[(int)ENomsPage.DETAILS_JEU_PAGE];
        }

        public void GoToAddGame(ElementJeu elementJeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.EDITION_VIEWMODEL];
            detailsViewModel.JeuSelectionne = elementJeuSelectionne;
            PageCourante = LesPages[(int)ENomsPage.ADD_GAME_PAGE];
        }

        public void AddGameToViewModel(Jeu elementJeuSelectionne)
        {
            ((ElementsJeuxViewModel)LesViewModels[(int)EViewModels.JEU_VIEWMODEL]).AddGame(elementJeuSelectionne);
        }
    }

    enum ENomsPage
    {
        MAIN_PAGE = 0,
        DETAILS_JEU_PAGE = 1,
        ADD_GAME_PAGE = 2    
    };

    enum EViewModels
    {
        JEU_VIEWMODEL = 0,
        EDITION_VIEWMODEL = 1
    };
}
