using LudoGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LudoGame.ViewModel
{
    public class StatistiquesViewModel : BaseViewModel
    {

        #region Champs et propriétés

        // Référence vers le ViewModel de navigation dans l'application.
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

        // Liste des jeux provenants de la page d'accueil.
        private List<Jeu> lesJeux;
        public List<Jeu> LesJeux
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

        // Nombre total de jeux.
        private int nbJeux;
        public int NbJeux
        {
            get => nbJeux;

            set
            {
                if (value != nbJeux)
                {
                    nbJeux = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Nombre total d'extensions.
        private int nbExtensions;
        public int NbExtensions
        {
            get => nbExtensions;

            set
            {
                if (value != nbExtensions)
                {
                    nbExtensions = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Cout tôtal des éléments de jeu.
        private double coutTotal;
        public double CoutTotal
        {
            get => coutTotal;

            set
            {
                if (value != coutTotal)
                {
                    coutTotal = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Durée moyenne totale des éléments de jeu.
        private double dureeMoyenneTotale;
        public double DureeMoyenneTotale
        {
            get => dureeMoyenneTotale;

            set
            {
                if (value != dureeMoyenneTotale)
                {
                    dureeMoyenneTotale = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur vierge utilisé pour les tests unitaires
        /// </summary>
        public StatistiquesViewModel()
        {
            navigationViewModel = null;
        }

        /// <summary>
        /// Initialisation du viewModel.
        /// </summary>
        /// <remarks>
        /// Ce ViewModel est initialisé à partir du NavigationViewModel.
        /// </remarks>
        /// <param name="navigationViewModel">La référence vers le lien du ViewModel de navigation.</param>
        public StatistiquesViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
        }

        #endregion

        #region Fonctions et méthodes

        /// <summary>
        /// Fonction utilisée pour actualiser les statistiques.
        /// </summary>
        /// <remarks>
        /// Appellée depuis le NavigationViewModel avant de passer à la page des statistiques.
        /// </remarks>
        public void LoadStatistics()
        {
            this.NbJeux = LesJeux.Count;
            this.NbExtensions = GetTotalNbExtensions();
            this.CoutTotal = GetTotalPrice();
            this.DureeMoyenneTotale = GetTotalAvgDuration();
        }

        /// <summary>
        /// Fonction qui renvoie le nombre total d'extensions.
        /// </summary>
        public int GetTotalNbExtensions()
        {
            int totExtensions = 0;

            foreach(Jeu jeu in LesJeux)
            {
                totExtensions += jeu.GetNumberOfExtensions();
            }
            return totExtensions;
        }

        /// <summary>
        /// Fonction qui renvoie le prix total des jeux.
        /// </summary>
        public double GetTotalPrice()
        {
            double totPrix = 0;

            foreach (Jeu jeu in LesJeux)
            {
                totPrix += jeu.GetPricewithAddons();
            }
            return totPrix;
        }

        /// <summary>
        /// Fonction qui renvoie la durée moyenne totale en minutes.
        /// </summary>
        public int GetTotalAvgDuration()
        {
            int totDuration = 0;

            foreach (Jeu jeu in LesJeux)
            {
                totDuration += jeu.GetDurationwithAddons();
            }
            return totDuration;
        }

        #endregion

        #region Commandes

        /// <summary>
        /// Permet de revenir à la page précédente en cas d'appui sur un bouton "annuler" par exemple.
        /// </summary>
        private ICommand goBackCommand;
        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new RelayCommand<Object>((obj) =>
                    {
                        NavigationViewModel.GoToMain();  // Appel de la fonction de navigation du NavigationViewModel
                    });
                }
                return goBackCommand;
            }
        }
        #endregion
    }
}
