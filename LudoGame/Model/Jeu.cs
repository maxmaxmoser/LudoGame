using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Model
{
    class Jeu : ElementJeu
    {
        private List<ExtensionJeu> lesExtensionsDuJeu;
        public List<ExtensionJeu> LesExtensionsDuJeu
        {
            get => lesExtensionsDuJeu;

            set
            {
                lesExtensionsDuJeu = value;
                NotifyPropertyChanged();
            }

        }
        public Jeu(string nom = "", int nbJoueurmin = 0, int nbJoueursMax = 0, int ageMin = 0, double prix = 0, string description = "", string cheminImage = "/Pictures/Board_picture_dummy.png")
            : base(nom, nbJoueurmin, nbJoueursMax, ageMin, prix, description, cheminImage) 
        {
            this.lesExtensionsDuJeu = new List<ExtensionJeu>();
        }

        public void addExtension(ExtensionJeu extension)
        {
            LesExtensionsDuJeu.Add(extension);
        }
    }
}
