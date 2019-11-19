using LudoGame.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LudoGame.ViewModel
{
    class DetailsViewModel : BaseViewModel
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

        private Boolean modificationEstAutorisee;
        public Boolean ModificationEstAutorisee
        {
            get => modificationEstAutorisee;

            set
            {
                if (value != modificationEstAutorisee)
                {
                    modificationEstAutorisee = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DetailsViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            ModificationEstAutorisee = false;
        }

        private ICommand goToMainCommand;
        public ICommand GoToMain
        {
            get
            {
                if (goToMainCommand == null)
                {
                    goToMainCommand = new RelayCommand<Object>((obj) =>
                    {
                        NavigationViewModel.GoToMain();
                        ModificationEstAutorisee = false;
                    });
                }
                return goToMainCommand;
            }
        }

        private ICommand pickImageCommand;
        public ICommand PickImage
        {
            get
            {
                if (pickImageCommand == null)
                {
                    pickImageCommand = new RelayCommand<Object>((obj) =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Image files (*.png;*.jpeg; *.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

                        if (openFileDialog.ShowDialog() == true)
                        {
                            JeuSelectionne.CheminImage = openFileDialog.FileName;
                        }
                    });
                }
                return pickImageCommand;
            }
        }

        private ICommand addGameCommand;
        public ICommand AddGame
        {
            get
            {
                if (addGameCommand == null)
                {
                    addGameCommand = new RelayCommand<Jeu>((jeu) =>
                    {
                        NavigationViewModel.AddGameToViewModel(jeu);
                        NavigationViewModel.GoToMain();
                        ModificationEstAutorisee = false;
                    });
                }
                return addGameCommand;
            }
        }
    }
}
