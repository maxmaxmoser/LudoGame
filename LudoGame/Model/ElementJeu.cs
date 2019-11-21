using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    abstract class ElementJeu : INotifyPropertyChanged
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

        public ElementJeu(string nom, int nbJoueurmin, int nbJoueursMax, int ageMin, double prix, string description, string cheminImage)
        {
            this.Nom = nom;
            this.NbJoueursMin = nbJoueurmin;
            this.nbJoueursMax = nbJoueursMax;
            this.AgeMin = ageMin;
            this.Prix = prix;
            this.Description = description;
            this.CheminImage = cheminImage;
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
