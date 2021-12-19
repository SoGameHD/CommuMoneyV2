using System;
using Xunit;
using CommuMoney.METIER.Services;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Projet_SERVICE_Tests
    {
        #region Projet_SERVICE_Tests_Insert
        [Fact]
        public void Projet_SERVICE_Tests_Insert()
        {
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 50;
            double moyenne = 25;
            DateTime? date_soiree = DateTime.Now;

            var depot = new Projet_SERVICE();
            var projet = new Projet_METIER(nom, id_personne, total_montant, moyenne, date_soiree);

            depot.Insert(projet);

            Assert.NotNull(projet);
            Assert.Equal(nom, projet.Nom);
            Assert.Equal(id_personne, projet.ID_Personne);
            Assert.Equal(total_montant, projet.Total_Montant);
            Assert.Equal(moyenne, projet.Moyenne);
            Assert.Equal(date_soiree, projet.Date_Soiree);

        }
        #endregion

        #region Projet_SERVICE_Tests_GetAll
        [Fact]
        public void Projet_SERVICE_Tests_GetAll()
        {
            var depot = new Projet_SERVICE();
            var projet = depot.GetAll();

            Assert.NotNull(projet);
        }
        #endregion

        #region Projet_SERVICE_Tests_GetByID
        [Fact]
        public void Projet_SERVICE_Tests_GetByID()
        {
            int id = 1;

            var depot = new Projet_SERVICE();
            var projet = depot.GetByID(id);

            Assert.NotNull(projet);
            Assert.Equal(id, projet.ID);
        }
        #endregion

        #region Projet_SERVICE_Tests_GetProjetByID_Personne
        [Fact]
        public void Projet_SERVICE_Tests_GetProjetByID_Personne()
        {
            int id_personne = 1;

            var depot = new Projet_SERVICE();
            var projet = depot.GetProjetByID_Personne(id_personne);

            Assert.NotNull(projet);
            Assert.Equal(id_personne, projet.ID_Personne);
        }
        #endregion

        #region Projet_SERVICE_Tests_GetListeProjetByID_Personne
        [Fact]
        public void Projet_SERVICE_Tests_GetListeProjetByID_Personne()
        {
            int id_personne = 1;

            var depot = new Projet_SERVICE();
            var projet = depot.GetListeProjetByID_Personne(id_personne);

            Assert.NotNull(projet);
        }
        #endregion

        #region Projet_SERVICE_Tests_Update
        [Fact]
        public void Projet_SERVICE_Tests_Update()
        {
            int id = 1;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 100;
            double moyenne = 50;
            DateTime? date_soiree = DateTime.Now;

            var depot = new Projet_SERVICE();
            var projet = new Projet_METIER(id, nom, id_personne, total_montant, moyenne, date_soiree);

            depot.Update(projet);

            Assert.NotNull(projet);
            Assert.Equal(id, projet.ID);
            Assert.Equal(nom, projet.Nom);
            Assert.Equal(id_personne, projet.ID_Personne);
            Assert.Equal(total_montant, projet.Total_Montant);
            Assert.Equal(moyenne, projet.Moyenne);
            Assert.Equal(date_soiree, projet.Date_Soiree);
        }
        #endregion

        #region Projet_SERVICE_Tests_Delete
        [Fact]
        public void Projet_SERVICE_Tests_Delete()
        {
            int id = 1;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 100;
            double moyenne = 50;
            DateTime? date_soiree = DateTime.Now;

            var projet = new Projet_METIER(id, nom, id_personne, total_montant, moyenne, date_soiree);
            var depot = new Projet_SERVICE();

            depot.Delete(projet);

            Assert.Throws<Exception>(() => depot.GetByID(projet.ID));
        }
        #endregion
    }
}
