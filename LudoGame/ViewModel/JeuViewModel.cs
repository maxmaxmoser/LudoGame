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
    class JeuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

       
        public JeuViewModel()
        {
            LesJeux = new ObservableCollection<Jeu>();

            LesJeux.Add(new Jeu("Unlock", 1, 6, 10, 32.25, "/Pictures/Board_picture_dummy.png"));
            LesJeux.Add(new Jeu("Carcassone", 2, 6, 7, 70, "/Pictures/Board_picture_dummy.png"));
            LesJeux.Add(new Jeu("Zombicide : saison 1", 1, 5, 10, 80, "/Pictures/Board_picture_dummy.png"));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
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

        /* Ouverture d'un pop up de création
        private ICommand afficherAjout;

        public ICommand AfficherAjout
        {
            get
            {
                if(afficherAjout == null)
                {
                    afficherAjout = new RelayCommand<Object>((obj) =>
                    {
                        PopUpAjoutJeu test = new PopUpAjoutJeu();
                        winTest.Show();
                    }); 
                }
                return afficherEdition;
            }
        }
        */

        #endregion
    }
}
