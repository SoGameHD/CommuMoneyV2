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
            var nom = "Soiree_Bar";
            var id_personne = 1;
            var total_montant = 50;
            var moyenne = 25;

            var projet = new Projet_DAL(nom, id_personne, total_montant, moyenne, DateTime.Now, DateTime.Now);
            var depot = new ProjetDepot_DAL();

            depot.Insert(projet);

            Assert.NotNull(projet);
            Assert.Equal(nom, projet.NOM);
            Assert.Equal(id_personne, projet.ID_PERSONNE);
            Assert.Equal(total_montant, projet.TOTAL_MONTANT);
            Assert.Equal(moyenne, projet.MOYENNE);
            Assert.NotNull(projet.Created_at);
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
            var depot = new ProjetDepot_DAL();
            var projet = depot.GetByID(1); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(projet);
            Assert.Equal(1, projet.ID);
        }
        #endregion

        #region ProjetDepot_DAL_Test_Update
        [Fact]
        public void ProjetDepot_DAL_Test_Update()
        {
            var nom = "Soiree_Bar";
            var id_personne = 1;
            var total_montant = 75;
            var moyenne = 35;

            var depot = new ProjetDepot_DAL();
            var projet = new Projet_DAL(nom, id_personne, total_montant, moyenne, DateTime.Now, DateTime.Now);

            depot.Update(projet);

            Assert.NotNull(projet);
            Assert.Equal(nom, projet.NOM);
            Assert.Equal(id_personne, projet.ID_PERSONNE);
            Assert.Equal(total_montant, projet.TOTAL_MONTANT);
            Assert.Equal(moyenne, projet.MOYENNE);
            Assert.NotNull(projet.Created_at);
            Assert.NotNull(projet.Updated_at);
        }
        #endregion

        #region ProjetDepot_DAL_Test_Delete
        [Fact]
        public void ProjetDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var nom = "Soiree_Bar";
            var id_personne = 1;
            var total_montant = 75;
            var moyenne = 35;

            var projet = new Projet_DAL(nom, id_personne, total_montant, moyenne, DateTime.Now, DateTime.Now);
            var depot = new ProjetDepot_DAL();


            depot.Delete(projet);

            Assert.Null(projet);
        }
        #endregion
    }
}
