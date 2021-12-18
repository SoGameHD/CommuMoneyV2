using System;
using Xunit;
using CommuMoney.METIER.Services;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Remboursement_SERVICE_Tests
    {
        #region Remboursement_SERVICE_Tests_Insert
        [Fact]
        public void Remboursement_SERVICE_Tests_Insert()
        {
            int id_personne = 1;
            int id_projet = 1;
            double dette = 0;

            var depot = new Remboursement_SERVICE();
            var remboursement = new Remboursement_METIER(id_personne, id_projet, dette);

            depot.Insert(remboursement);

            Assert.NotNull(remboursement);
            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);

        }
        #endregion

        #region Remboursement_SERVICE_Tests_GetAll
        [Fact]
        public void Remboursement_SERVICE_Tests_GetAll()
        {
            var depot = new Remboursement_SERVICE();
            var remboursement = depot.GetAll();

            Assert.NotNull(remboursement);
        }
        #endregion

        #region Remboursement_SERVICE_Tests_GetByID
        [Fact]
        public void Remboursement_SERVICE_Tests_GetByID()
        {
            int id = 1;

            var depot = new Remboursement_SERVICE();
            var remboursement = depot.GetByID(id);

            Assert.NotNull(remboursement);
            Assert.Equal(id, remboursement.ID);
        }
        #endregion

        #region Remboursement_SERVICE_Tests_Update
        [Fact]
        public void Remboursement_SERVICE_Tests_Update()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 0;

            var depot = new Remboursement_SERVICE();
            var remboursement = new Remboursement_METIER(id, id_personne, id_projet, dette);

            depot.Update(remboursement);

            Assert.NotNull(remboursement);
            Assert.Equal(id, remboursement.ID);
            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);
        }
        #endregion

        #region Projet_SERVICE_Tests_Delete
        [Fact]
        public void Projet_SERVICE_Tests_Delete()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 0;

            var depot = new Remboursement_SERVICE();
            var remboursement = new Remboursement_METIER(id, id_personne, id_projet, dette);

            depot.Delete(remboursement);

            Assert.Throws<Exception>(() => depot.GetByID(remboursement.ID));
        }
        #endregion
    }
}
