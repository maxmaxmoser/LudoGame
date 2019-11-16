using LudoGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LudoGame.ViewModel
{
    class EditionViewModel : BaseViewModel
    {
        private NavigationViewModel navigationViewModel;
        public NavigationViewModel NavigationViewModel
        {
            get => navigationViewModel;
            set
            {
                if (value != navigationViewModel)
                {
                    navigationViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Jeu jeuSelectionne;
        public Jeu JeuSelectionne
        {
            get => jeuSelectionne;

            set
            {
                if (value != jeuSelectionne)
                {
                    jeuSelectionne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public EditionViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
        }

        private ICommand goToMainCommand;
        public ICommand GoToMain
        {
            get
            {
                if (goToMainCommand == null)
                {
                    goToMainCommand = new RelayCommand<Object>((obj) => NavigationViewModel.GoToMain());
                }
                return goToMainCommand;
            }
        }
    }
}
