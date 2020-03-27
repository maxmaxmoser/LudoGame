using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LudoGame.User_Controls
{
    /// <summary>
    /// Logique d'interaction pour Uc_BoardGameAttributes.xaml
    /// </summary>
    public partial class Uc_BoardGameAttributes : UserControl
    {
        public Uc_BoardGameAttributes()
        {
            InitializeComponent();
        }

        #region NomElementJeu DP

        public string NomElementJeu
        {
            get { return (string)GetValue(NomElementJeuProperty); }
            set { SetValue(NomElementJeuProperty, value); }
        }

        public static readonly DependencyProperty NomElementJeuProperty = DependencyProperty.Register(
            "NomElementJeu",
            typeof(string),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region EditeurElementJeu DP

        public string EditeurElementJeu
        {
            get { return (string)GetValue(EditeurElementJeuProperty); }
            set { SetValue(EditeurElementJeuProperty, value); }
        }

        public static readonly DependencyProperty EditeurElementJeuProperty = DependencyProperty.Register(
            "EditeurElementJeu",
            typeof(string),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region DescriptionElementJeu DP

        public string DescriptionElementJeu
        {
            get { return (string)GetValue(DescriptionElementJeuProperty); }
            set { SetValue(DescriptionElementJeuProperty, value); }
        }

        public static readonly DependencyProperty DescriptionElementJeuProperty = DependencyProperty.Register(
            "DescriptionElementJeu",
            typeof(string),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region NbJoueursMin DP

        public int NbJoueursMin
        {
            get { return (int)GetValue(NbJoueursMinProperty); }
            set { SetValue(NbJoueursMinProperty, value); }
        }

        public static readonly DependencyProperty NbJoueursMinProperty = DependencyProperty.Register(
            "NbJoueursMin",
            typeof(int),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region NbJoueursMax DP

        public int NbJoueursMax
        {
            get { return (int)GetValue(NbJoueursMaxProperty); }
            set { SetValue(NbJoueursMaxProperty, value); }
        }

        public static readonly DependencyProperty NbJoueursMaxProperty = DependencyProperty.Register(
            "NbJoueursMax",
            typeof(int),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region AgeMin DP

        public int AgeMin
        {
            get { return (int)GetValue(AgeMinProperty); }
            set { SetValue(AgeMinProperty, value); }
        }

        public static readonly DependencyProperty AgeMinProperty = DependencyProperty.Register(
            "AgeMin",
            typeof(int),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region PrixElementJeu DP

        public int PrixElementJeu
        {
            get { return (int)GetValue(PrixElementJeuProperty); }
            set { SetValue(PrixElementJeuProperty, value); }
        }

        public static readonly DependencyProperty PrixElementJeuProperty = DependencyProperty.Register(
            "PrixElementJeu",
            typeof(double),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region DureeMoyenneElementJeu DP

        public int DureeMoyenneElementJeu
        {
            get { return (int)GetValue(DureeMoyenneElementJeuProperty); }
            set { SetValue(DureeMoyenneElementJeuProperty, value); }
        }

        public static readonly DependencyProperty DureeMoyenneElementJeuProperty = DependencyProperty.Register(
            "DureeMoyenneElementJeu",
            typeof(double),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region ImageElementJeu DP

        public string ImageElementJeu
        {
            get { return (string)GetValue(ImageElementJeuProperty); }
            set { SetValue(ImageElementJeuProperty, value); }
        }

        public static readonly DependencyProperty ImageElementJeuProperty = DependencyProperty.Register(
            "ImageElementJeu",
            typeof(string),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region PickImageCommand DP

        public ICommand PickImageCommand
        {
            get { return (ICommand)GetValue(PickImageCommandProperty); }
            set { SetValue(PickImageCommandProperty, value); }
        }

        public static readonly DependencyProperty PickImageCommandProperty = DependencyProperty.Register(
            "PickImageCommand",
            typeof(ICommand),
            typeof(Uc_BoardGameAttributes));

        #endregion

        #region ModificationEstAutorisee DP

        public bool ModificationEstAutorisee
        {
            get { return (bool)GetValue(ModificationEstAutoriseeProperty); }
            set { SetValue(ModificationEstAutoriseeProperty, value); }
        }

        public static readonly DependencyProperty ModificationEstAutoriseeProperty = DependencyProperty.Register(
            "ModificationEstAutorisee",
            typeof(Boolean),
            typeof(Uc_BoardGameAttributes));

        #endregion
    }
}
