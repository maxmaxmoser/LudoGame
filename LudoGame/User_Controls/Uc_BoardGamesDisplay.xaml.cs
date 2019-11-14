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
    /// Logique d'interaction pour Uc_BoardGamesDisplay.xaml
    /// </summary>
    public partial class Uc_BoardGamesDisplay : UserControl
    {
        public Uc_BoardGamesDisplay()
        {
            InitializeComponent();
           // this.DataContext = this;
        }

        
        #region NomJeu DP

        public string NomJeu 
        {
            get { return (string)GetValue(NomJeuProperty); }
            set { SetValue(NomJeuProperty, value); }
        }

        public static readonly DependencyProperty NomJeuProperty = DependencyProperty.Register(
            "NomJeu",
            typeof(string),
            typeof(Uc_BoardGamesDisplay));

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
            typeof(Uc_BoardGamesDisplay));

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
            typeof(Uc_BoardGamesDisplay));

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
            typeof(Uc_BoardGamesDisplay));

        #endregion

        #region ImageJeu DP

        public string ImageJeu
        {
            get { return (string)GetValue(ImageJeuProperty); }
            set { SetValue(ImageJeuProperty, value); }
        }

        public static readonly DependencyProperty ImageJeuProperty = DependencyProperty.Register(
            "ImageJeu",
            typeof(string),
            typeof(Uc_BoardGamesDisplay));

        #endregion
    }
}
