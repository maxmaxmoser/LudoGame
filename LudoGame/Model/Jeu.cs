using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    class Jeu : ElementJeu
    {
        private List<ExtensionJeu> lesExtensionsDeJeux;
        public List<ExtensionJeu> LesExtensionsDeJeux
        {
            get => lesExtensionsDeJeux;

            set
            {
                lesExtensionsDeJeux = value;
                NotifyPropertyChanged();
            }

        }
        public Jeu(string nom = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, nbJoueurmin, nbJoueursMax, ageMin, prix, description, cheminImage) 
        {
            this.LesExtensionsDeJeux = new List<ExtensionJeu>();
        }

        public void addExtension(ExtensionJeu extension)
        {
            LesExtensionsDeJeux.Add(extension);
        }
    }
}
