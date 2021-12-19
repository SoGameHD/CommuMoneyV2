using System;
using Xunit;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.DAL.Tests
{
    public class ProjetDepot_DAL_Tests
    {
        #region ProjetDepot_DAL_Test_Insert
        [Fact]
        public void ProjetDepot_DAL_Test_Insert()
        {
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 50;
            double moyenne = 25;
            DateTime? date_soiree = DateTime.Now;

            var projet = new Projet_DAL(nom, id_personne, total_montant, moyenne, date_soiree);
            var depot = new ProjetDepot_DAL();

            depot.Insert(projet);

            Assert.NotNull(projet);
            Assert.Equal(nom, projet.Nom);
            Assert.Equal(id_personne, projet.ID_Personne);
            Assert.Equal(total_montant, projet.Total_Montant);
            Assert.Equal(moyenne, projet.Moyenne);
            Assert.Equal(date_soiree, projet.Date_Soiree);
        }
        #endregion

        #region ProjetDepot_DAL_Test_GetAll
        [Fact]
        public void ProjetDepot_DAL_Test_GetAll()
        {
            var depot = new ProjetDepot_DAL();
            var projet = depot.GetAll();

            Assert.NotNull(projet);
        }
        #endregion

        #region ProjetDepot_DAL_Test_GetByID
        [Fact]
        public void ProjetDepot_DAL_Test_GetByID()
        {
            int id = 1;

            var depot = new ProjetDepot_DAL();
            var projet = depot.GetByID(id); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(projet);
            Assert.Equal(id, projet.ID);
        }
        #endregion

        #region ProjetDepot_DAL_Test_GetProjetByID_Personne
        [Fact]
        public void ProjetDepot_DAL_Test_GetProjetByID_Personne()
        {
            int id_personne = 1;

            var depot = new ProjetDepot_DAL();
            var projet = depot.GetProjetByIDPersonne(id_personne); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(projet);
            Assert.Equal(id_personne, projet.ID_Personne);
        }
        #endregion

        #region ProjetDepot_DAL_Test_GetListeProjetByID_Personne
        [Fact]
        public void ProjetDepot_DAL_Test_GetListeProjetByID_Personne()
        {
            int id_personne = 1;

            var depot = new ProjetDepot_DAL();
            var projet = depot.GetListeProjetByID_Personne(id_personne); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(projet);
        }
        #endregion

        #region ProjetDepot_DAL_Test_Update
        [Fact]
        public void ProjetDepot_DAL_Test_Update()
        {
            int id = 1;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 75;
            double moyenne = 35;
            DateTime? date_soiree = DateTime.Now;


            var depot = new ProjetDepot_DAL();
            var projet = new Projet_DAL(id, nom, id_personne, total_montant, moyenne, date_soiree);

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

        #region ProjetDepot_DAL_Test_Delete
        [Fact]
        public void ProjetDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            int id = 8;
            string nom = "Soiree_Bar";
            int id_personne = 1;
            double total_montant = 75;
            double moyenne = 35;
            DateTime? date_soiree = DateTime.Now;

            var depot = new ProjetDepot_DAL();
            var projet = new Projet_DAL(id, nom, id_personne, total_montant, moyenne, date_soiree);

            depot.Delete(projet);

            Assert.Throws<Exception>(() => depot.GetByID(projet.ID));
        }
        #endregion
    }
}
