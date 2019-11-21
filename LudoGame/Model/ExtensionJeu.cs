using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    class ExtensionJeu : ElementJeu
    {
        private Jeu jeuAssocie;
        public Jeu JeuAssocie
        {
            get => jeuAssocie;

            set
            {
                jeuAssocie = value;
                NotifyPropertyChanged();
            }
        }

        public ExtensionJeu(Jeu jeuAssocie, string nom = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, nbJoueurmin, nbJoueursMax, ageMin, prix, description, cheminImage)
        {
            this.JeuAssocie = jeuAssocie;
        }
    }
}
