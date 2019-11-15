using LudoGame.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        

        public static int nb = 0;

        private int iD;
        public int ID { get => iD; set => iD = value; }


        public NavigationViewModel()
        {
            ID = nb;
            nb++;
            JeuViewModel jeuViewModel = new JeuViewModel(this);

            LesPages = new ObservableCollection<Page>();

            AddPageToNavigation(new MainPage(), jeuViewModel);
            AddPageToNavigation(new EditionPage(), jeuViewModel);

            PageCourante = LesPages[(int)NomsPage.MainPage];
        }

        private void AddPageToNavigation(Page page, BaseViewModel dataContext)
        {
            page.DataContext = dataContext;   
            lesPages.Add(page);
        }

        public void GoToMain()
        {
            PageCourante = LesPages[(int)NomsPage.MainPage];
        }

        public  void GoToEdition()
        {
            PageCourante = LesPages[(int)NomsPage.EditionPage];
        }
    }

    enum NomsPage
    {
        MainPage = 0,
        EditionPage = 1
    };
}
