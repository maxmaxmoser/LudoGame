using LudoGame.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LudoGame.Model;

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
            LesViewModels.Add(new JeuViewModel(this));
            LesViewModels.Add(new DetailsViewModel(this));

            LesPages = new ObservableCollection<Page>();

            AddPageToNavigation(new MainPage(), LesViewModels[(int)EViewModels.JeuViewModel]);
            AddPageToNavigation(new DetailsPage(), LesViewModels[(int)EViewModels.EditionViewModel]);
            AddPageToNavigation(new AddGamePage(), LesViewModels[(int)EViewModels.EditionViewModel]);

            PageCourante = LesPages[(int)ENomsPage.MainPage];
        }

        private void AddPageToNavigation(Page page, BaseViewModel dataContext)
        {
            page.DataContext = dataContext;   
            lesPages.Add(page);
        }

        public void GoToMain()
        {
            PageCourante = LesPages[(int)ENomsPage.MainPage];
        }

        public  void GoToDetails(Jeu jeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.EditionViewModel];
            detailsViewModel.JeuSelectionne = jeuSelectionne;
            PageCourante = LesPages[(int)ENomsPage.EditionPage];
        }

        public void GoToAddGame(Jeu jeuSelectionne)
        {
            DetailsViewModel detailsViewModel = (DetailsViewModel)LesViewModels[(int)EViewModels.EditionViewModel];
            detailsViewModel.JeuSelectionne = jeuSelectionne;
            PageCourante = LesPages[(int)ENomsPage.AddGamePage];
        }

        public void AddGameToViewModel(Jeu jeu)
        {
            ((JeuViewModel)LesViewModels[(int)EViewModels.JeuViewModel]).AddGame(jeu);
        }
    }

    enum ENomsPage
    {
        MainPage = 0,
        EditionPage = 1,
        AddGamePage = 2    
    };

    enum EViewModels
    {
        JeuViewModel = 0,
        EditionViewModel = 1
    };
}
