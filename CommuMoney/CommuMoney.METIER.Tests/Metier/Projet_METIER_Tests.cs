using System;
using Xunit;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Projet_METIER_Tests
    {
        #region Projet_METIER_Test_Insert
        [Fact]
        public void Projet_METIER_Tests_Insert()
        {
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 50;
            double moyenne = 25;
            DateTime? date_soiree = DateTime.Now;

            var projet = new Projet_METIER(nom, id_personne, total_montant, moyenne, date_soiree);

            projet.Insert();

            Assert.NotNull(projet);
            Assert.Equal(nom, projet.Nom);
            Assert.Equal(id_personne, projet.ID_Personne);
            Assert.Equal(total_montant, projet.Total_Montant);
            Assert.Equal(moyenne, projet.Moyenne);
            Assert.Equal(date_soiree, projet.Date_Soiree);
        }
        #endregion

        #region Projet_METIER_Test_Update
        [Fact]
        public void Projet_METIER_Tests_Update()
        {
            int id = 1;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 100;
            double moyenne = 50;
            DateTime? date_soiree = DateTime.Now;

            var projet = new Projet_METIER(id, nom, id_personne, total_montant, moyenne, date_soiree);

            projet.Update();

            Assert.NotNull(projet);
            Assert.Equal(id, projet.ID);
            Assert.Equal(nom, projet.Nom);
            Assert.Equal(id_personne, projet.ID_Personne);
            Assert.Equal(total_montant, projet.Total_Montant);
            Assert.Equal(moyenne, projet.Moyenne);
            Assert.Equal(date_soiree, projet.Date_Soiree);
        }
        #endregion

        #region Projet_METIER_Test_Delete
        [Fact]
        public void Projet_METIER_Test_Delete()
        {
            int id = 1;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 100;
            double moyenne = 50;
            DateTime? date_soiree = DateTime.Now;

            var projet = new Projet_METIER(id, nom, id_personne, total_montant, moyenne, date_soiree);

            projet.Delete();
        }
        #endregion
    }
}
