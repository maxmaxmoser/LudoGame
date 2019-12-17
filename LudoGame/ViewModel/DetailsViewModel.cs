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
    /// <summary>
    /// ViewModel relié à la page d'ajout d'un élément ainsi que les pages de détails.
    /// Il permet la manipulation d'un élément de jeu ciblé.
    /// </summary>
    class DetailsViewModel : BaseViewModel
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

        // Elément de jeu concerné par la page active.
        private ElementJeu elementjeuSelectionne;
        public ElementJeu ElementJeuSelectionne
        {
            get => elementjeuSelectionne;

            set
            {
                if (value != elementjeuSelectionne)
                {
                    elementjeuSelectionne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Booléen permettant d'indiquer si des modifications sont possibles ou non sur la page.
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

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialisation du viewModel.
        /// </summary>
        /// <remarks>
        /// Ce ViewModel est initialisé à partir du NavigationViewModel.
        /// </remarks>
        /// <param name="navigationViewModel">La référence vers le lien du ViewModel de navigation.</param>
        public DetailsViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            ModificationEstAutorisee = false;
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
                    goBackCommand = new RelayCommand<ElementJeu>((elementJeu) =>
                    {
                        switch (elementJeu.GetType().Name)
                        {
                            // Si on est dans les détails d'un jeu, on revient à la page d'acceuil.
                            case "Jeu":
                                {
                                    NavigationViewModel.GoToMain();  // Appel de la fonction de navigation du NavigationViewModel
                                    ModificationEstAutorisee = false;
                                    break;
                                }

                            // Si on est dans les détails d'une extension, on revient à son jeu associé
                            case "ExtensionJeu":
                                {                                
                                    NavigationViewModel.GoToDetails(((ExtensionJeu)elementJeu).JeuAssocie); // Appel de la fonction de navigation du NavigationViewModel
                                    break;
                                }
                        }
                    });
                }
                return goBackCommand;
            }
        }

        /// <summary>
        /// Permet d'accéder aux détails d'une extension du jeu courant.
        /// </summary>
        private ICommand goToExtensionsDetailsCommand;
        public ICommand GoToExtensionsDetailsCommand
        {
            get
            {
                if (goToExtensionsDetailsCommand == null)
                {
                    goToExtensionsDetailsCommand = new RelayCommand<ExtensionJeu>((extensionJeu) =>
                    {
                        if (extensionJeu != null)
                        {
                            NavigationViewModel.GoToDetails(extensionJeu);
                        }
                    });
                }
                return goToExtensionsDetailsCommand;
            }
        }

        /// <summary>
        /// Ouverture d'un explorateur de fichier pour sélectionner une image.
        /// </summary>
        private ICommand pickImageCommand;
        public ICommand PickImageCommand
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
                            ElementJeuSelectionne.CheminImage = openFileDialog.FileName;
                        }
                    });
                }
                return pickImageCommand;
            }
        }

        /// <summary>
        /// Commande utilisée par la page d'ajout pour ajouter le nouveau jeu à la liste d'accueil.
        /// </summary>
        private ICommand addElementJeuCommand;
        public ICommand AddElementJeuCommand
        {
            get
            {
                if (addElementJeuCommand == null)
                {
                    addElementJeuCommand = new RelayCommand<ElementJeu>((elementJeu) =>
                    {
                        switch (elementJeu.GetType().Name)
                        {
                            // Si on ajoute un jeu, ce dernier est intégré à la liste de la page d'acceuil avant d'y retourner.
                            case "Jeu":
                            {
                                    Jeu jeu = (Jeu)elementJeu;
                                    NavigationViewModel.AddGameToViewModel(jeu);
                                    NavigationViewModel.GoToMain();
                                    ModificationEstAutorisee = false;
                                    break;
                             }

                            // Si on ajoute une extension, on la ratache à son jeu associé avant de revenir à ses détails.
                            case "ExtensionJeu":
                            {
                                ExtensionJeu extensionJeu = (ExtensionJeu)elementJeu;
                                extensionJeu.JeuAssocie.addExtension(extensionJeu);
                                NavigationViewModel.GoToDetails(extensionJeu.JeuAssocie);
                                break;
                            }
                        }
                    });
                }
                return addElementJeuCommand;
            }
        }

        /// <summary>
        /// Commande présente dans les détails d'un jeu pour supprimer une extension de la liste.
        /// </summary>
        private ICommand removeExtensionCommand;
        public ICommand RemoveExtensionCommand
        {
            get
            {
                if (removeExtensionCommand == null)
                {
                    removeExtensionCommand = new RelayCommand<ExtensionJeu>((extension) => ((Jeu)ElementJeuSelectionne).LesExtensionsDuJeu.Remove(extension));
                }
                return removeExtensionCommand;
            }
        }

        /// <summary>
        /// Commande utilisée pour naviguer dans la fenêtre d'ajout d'une nouvelle extension de jeu.
        /// </summary>
        /// <remarks>
        /// L'extension en question est initialisée dans cette commande pour ensuite être passée en paramètre dans la fonction du NavigationViewModel.
        /// </remarks>
        private ICommand goToAddExtensionCommand;
        public ICommand GoToAddExtensionCommand
        {
            get
            {
                if (goToAddExtensionCommand == null)
                {
                    goToAddExtensionCommand = new RelayCommand<Object>((obj) =>
                    {
                       // NavigationViewModel.GoToAddGame(new ExtensionJeu((Jeu)ElementJeuSelectionne, editeur:ElementJeuSelectionne.Editeur));
                    });
                }
                return goToAddExtensionCommand;
            }
        }

        #endregion
    }
}
