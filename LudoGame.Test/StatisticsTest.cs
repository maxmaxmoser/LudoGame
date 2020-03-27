using System;
using Xunit;
using LudoGame.ViewModel;
using System.Collections.Generic;
using LudoGame.Model;

namespace LudoGame.Test
{
    /// <summary>
    /// Classe ayant pour objecctif de tester les méthodes utilisées pour les statistiques.
    /// </summary>
    public class StatisticsTest
    {
        /// <summary>
        /// Méthode privée utilisée pour générer le jeu de données de test.
        /// </summary>
        /// <param name="withExtensions"> Booléen pour indiquer si l'on souhaite un jeu de données avec des extensions.</param>
        /// <returns></returns>
        private StatistiquesViewModel InitEnvTest(bool withExtensions)
        {
            StatistiquesViewModel statistiques = new StatistiquesViewModel();
            statistiques.LesJeux = new List<Jeu>()
            {
                new Jeu("Jeux 1", "Editeur",  1, 6, 10, 32.25, dureeMoyenne:60, cheminImage:"/Pictures/Board_picture_dummy.png"),
                new Jeu("Jeux 2", "Editeur", 2, 6, 7, 24.95, dureeMoyenne: 35, cheminImage: "/Pictures/Board_picture_dummy.png"),           
                new Jeu("Jeux 3", "Editeur", 1, 5, 10, 45, 90, "Un jeu de conquêtes dans un univer fantastique", "/Pictures/Board_picture_dummy.png")
            };

            if(withExtensions)
            {
                Jeu carcassone = statistiques.LesJeux[1];
                carcassone.AddExtension(new ExtensionJeu(carcassone, "Extension 1 de jeu 2", carcassone.Editeur, 2, 6, 7, 13.50, 15, cheminImage: "/Pictures/Board_picture_dummy.png"));
                carcassone.AddExtension(new ExtensionJeu(carcassone, "Extension 2 de jeu 2", carcassone.Editeur, 2, 6, 7, 13.50, 15, cheminImage: "/Pictures/Board_picture_dummy.png"));
            }

            return statistiques;
        }

        /// <summary>
        /// Test sur le comptage des jeux.
        /// </summary>
        [Fact]
        public void Check_NbJeux()
        {
            StatistiquesViewModel statistiquesWithExtensions = InitEnvTest(true);

            Assert.Equal(3, statistiquesWithExtensions.LesJeux.Count);
        }

        /// <summary>
        /// Test de la méthode GetTotalNbExtensions qui renvoie le nombre total d'extensions.
        /// </summary>
        [Fact]
        public void Check_GetTotalNbExtensions()
        {
            StatistiquesViewModel statistiquesWithExtensions = InitEnvTest(true);
            StatistiquesViewModel statistiquesWithoutExtension = InitEnvTest(false);
         
            Assert.Equal(2, statistiquesWithExtensions.GetTotalNbExtensions());
            Assert.Equal(0, statistiquesWithoutExtension.GetTotalNbExtensions());
        }

        /// <summary>
        /// Test de la méthode GetTotalPrice qui renvoie le prix total.
        /// </summary>
        [Fact]
        public void Check_GetTotalPrice()
        {
            StatistiquesViewModel statistiquesWithExtensions = InitEnvTest(true);
            StatistiquesViewModel statistiquesWithoutExtension = InitEnvTest(false);

            Assert.Equal(129.2, statistiquesWithExtensions.GetTotalPrice());
            Assert.Equal(102.2, statistiquesWithoutExtension.GetTotalPrice());           
        }

        /// <summary>
        /// Test de la méthode GetTotalAvgDuration qui renvoie la durée totale découlant des jeux et de leurs extensions. 
        /// </summary>
        [Fact]
        public void Check_GetTotalAvgDuration()
        {
            StatistiquesViewModel statistiquesWithExtensions = InitEnvTest(true);
            StatistiquesViewModel statistiquesWithoutExtension = InitEnvTest(false);

            Assert.Equal(215, statistiquesWithExtensions.GetTotalAvgDuration());
            Assert.Equal(185, statistiquesWithoutExtension.GetTotalAvgDuration());
        }

    }
}
