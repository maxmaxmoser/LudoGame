using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LudoGame.Model
{
    class Jeu : INotifyPropertyChanged
    {
        private string nom;
        private string description;
        private int nbJoueursMin;
        private int nbJoueursMax;
        private int ageMin;
        private double prix;
        private string cheminImage;

        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public int NbJoueursMin
        {
            get => nbJoueursMin;
            set
            {
                nbJoueursMin = value;
                NotifyPropertyChanged();
            }
        }

        public int NbJoueursMax
        {
            get => nbJoueursMax;
            set
            {
                nbJoueursMax = value;
                NotifyPropertyChanged();
            }
        }

        public int AgeMin
        {
            get => ageMin;
            set
            {
                ageMin = value;
                NotifyPropertyChanged();
            }
        }

        public double Prix
        {
            get => prix;
            set
            {
                prix = value;
                NotifyPropertyChanged();
            }
        }

        public string CheminImage
        {
            get => cheminImage;
            set
            {
                cheminImage = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Jeu(string nom = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, string description = "", string cheminImage = "")
        {
            this.Nom = nom;
            this.NbJoueursMin = nbJoueurmin;
            this.nbJoueursMax = nbJoueursMax;
            this.AgeMin = ageMin;
            this.Prix = prix;
            this.Description = description;
            this.CheminImage = cheminImage;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
