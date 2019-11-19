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
    class JeuViewModel : BaseViewModel
    {
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

        private ObservableCollection<Jeu> lesJeux;
        public ObservableCollection<Jeu> LesJeux
        {
            get => lesJeux;

            set
            {
                if (value != lesJeux)
                {
                    lesJeux = value;
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

        public JeuViewModel(NavigationViewModel navigationViewModel)
        {

            this.NavigationViewModel = navigationViewModel;
            LesJeux = new ObservableCollection<Jeu>();

            LesJeux.Add(new Jeu("Unlock", 1, 6, 10, 32.25, cheminImage:"/Pictures/Board_picture_dummy.png"));
            LesJeux.Add(new Jeu("Carcassone", 2, 6, 7, 70, cheminImage:"/Pictures/Board_picture_dummy.png"));
            LesJeux.Add(new Jeu("Zombicide : saison 1", 1, 5, 10, 80, "Un jeu post apocalyptique de zombies", "/Pictures/Board_picture_dummy.png"));
        }

        #region Commandes interactives avec la vue

        // Suppression d'un jeu de la liste
        private ICommand supprimerJeu;
        public ICommand SupprimerJeu
        {
            get
            {
                if (supprimerJeu == null)
                {
                    supprimerJeu = new RelayCommand<Jeu>((jeu) => lesJeux.Remove(jeu));
                }
                return supprimerJeu;
            }
        }

        private ICommand goToDetailsCommand;
        public ICommand GoToDetails
        {
            get
            {
                if(goToDetailsCommand == null)
                {
                    goToDetailsCommand = new RelayCommand<Object>((obj) => 
                    {
                        if(JeuSelectionne != null)
                        { 
                            NavigationViewModel.GoToDetails(JeuSelectionne);
                        }
                    });
                }
                return goToDetailsCommand;
            }
        }
        #endregion
    }
}
