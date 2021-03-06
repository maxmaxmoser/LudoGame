﻿using System;
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
using Microsoft.EntityFrameworkCore;

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
            LesJeux = NavigationViewModel.LudoGameDbContext.Table_Jeu.Local.ToObservableCollection();
            NavigationViewModel.LudoGameDbContext.Table_Jeu.Load();
            NavigationViewModel.LudoGameDbContext.Table_Extension.Load();
        }

        #endregion

        #region Fonctions et méthodes

        /// <summary>
        /// Ajout d'un jeu à la liste.
        /// </summary>
        /// <param name="jeu">Le jeu à ajouter.</param>
        public void AddGame(Jeu jeu)
        {
            LesJeux.Add(jeu);
            NavigationViewModel.SaveDbChanges();
        }

        /// <summary>
        /// Suppression d'un jeu à la liste.
        /// </summary>
        /// <param name="jeu">Le jeu à ajouter.</param>
        public void RemoveGame(Jeu jeu)
        {
            NavigationViewModel.LudoGameDbContext.Remove(jeu);
            NavigationViewModel.SaveDbChanges();
        }

        /// <summary>
        /// Ajout d'une extension à un jeu.
        /// </summary>
        /// <param name="jeu">Le jeu auquel appartient l'extension.</param>
        /// <param name="extensionJeu">L'extension à ajouter.</param>
        public void AddExtensionTogame(Jeu jeu, ExtensionJeu extensionJeu)
        {
            jeu.AddExtension(extensionJeu);
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
                    goToDetailsCommand = new RelayCommand<Jeu>((jeu) => 
                    {
                        if(jeu != null)
                        { 
                            NavigationViewModel.GoToDetails(jeu);
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
                        NavigationViewModel.GoToAddGameElement(new Jeu("/Pictures/Board_picture_dummy.png"));
                    });
                }
                return goToAddGameCommand;
            }
        }

        private ICommand goToStatistiquesCommand;
        public ICommand GoToStatistiquesCommand
        {
            get
            {
                if (goToStatistiquesCommand == null)
                {
                    goToStatistiquesCommand = new RelayCommand<Object>((obj) =>
                    {
                        NavigationViewModel.GoToStatistics(new List<Jeu>(LesJeux));
                    });
                }
                return goToStatistiquesCommand;
            }
        }

        #endregion
    }
}
