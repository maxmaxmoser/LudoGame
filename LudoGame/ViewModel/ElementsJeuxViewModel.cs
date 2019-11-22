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
    class ElementsJeuxViewModel : BaseViewModel
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

        public ElementsJeuxViewModel(NavigationViewModel navigationViewModel)
        {

            this.NavigationViewModel = navigationViewModel;
            LesElementsDeJeux = new ObservableCollection<ElementJeu>();

            AddGame(new Jeu("Unlock", 1, 6, 10, 32.25, cheminImage:"/Pictures/Board_picture_dummy.png"));
            Jeu carcassone = new Jeu("Carcassone", 2, 6, 7, 70, cheminImage: "/Pictures/Board_picture_dummy.png");
            AddExtensionTogame(carcassone, new ExtensionJeu(carcassone, "Carcassone : Auberges & Cathédrales", 2, 6, 7, 13.50, cheminImage: "/Pictures/Board_picture_dummy.png"));

            AddGame(carcassone);
            AddGame(new Jeu("Smallworld", 1, 5, 10, 80, "Un jeu de conquêtes dans un univer fantastique", "/Pictures/Board_picture_dummy.png"));

        }

        public void AddGame(Jeu jeu)
        {
            LesElementsDeJeux.Add(jeu);
        }

        public void AddExtensionTogame(Jeu jeu, ExtensionJeu extensionJeu)
        {
            jeu.addExtension(extensionJeu);
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
                    supprimerJeu = new RelayCommand<ElementJeu>((elementJeu) => LesElementsDeJeux.Remove(elementJeu));
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

        private ICommand goToAddGameCommand;
        public ICommand GoToAddGame
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
