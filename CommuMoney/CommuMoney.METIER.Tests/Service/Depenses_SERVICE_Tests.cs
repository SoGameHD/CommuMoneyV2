using System;
using Xunit;
using CommuMoney.METIER.Services;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Depenses_SERVICE_Tests
    {
        #region Depenses_SERVICE_Tests_Insert
        [Fact]
        public void Depenses_SERVICE_Tests_Insert()
        {
            int id_personne = 1;
            int id_projet = 1;
            double montant = 0;

            var depot = new Depenses_SERVICE();
            var depense = new Depenses_METIER(id_personne, id_projet, montant);

            depot.Insert(depense);

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_personne, depense.ID_Projet);

        }
        #endregion

        #region Depenses_SERVICE_Tests_GetAll
        [Fact]
        public void Depenses_SERVICE_Tests_GetAll()
        {
            var depot = new Depenses_SERVICE();
            var depense = depot.GetAll();

            Assert.NotNull(depense);
        }
        #endregion

        #region Depenses_SERVICE_Tests_GetByID
        [Fact]
        public void Depenses_SERVICE_Tests_GetByID()
        {
            int id = 3;

            var depot = new Depenses_SERVICE();
            var depense = depot.GetByID(id);

            Assert.NotNull(depense);
            Assert.Equal(id, depense.ID);
        }
        #endregion

        #region Depenses_SERVICE_Tests_Update
        [Fact]
        public void Depenses_SERVICE_Tests_Update()
        {
            int id = 10;
            int id_personne = 1;
            int id_projet = 1;
            double montant = 50;

            var depot = new Depenses_SERVICE();
            var depense = new Depenses_METIER(id, id_personne, id_projet, montant);

            depot.Update(depense);

            Assert.NotNull(depense);
            Assert.Equal(id, depense.ID);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
        }
        #endregion

        #region Depenses_SERVICE_Tests_Delete
        [Fact]
        public void Depenses_SERVICE_Tests_Delete()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double montant = 50;

            var depense = new Depenses_METIER(id, id_personne, id_projet, montant);
            var depot = new Depenses_SERVICE();

            depot.Delete(depense);

            Assert.Throws<Exception>(() => depot.GetByID(depense.ID));
        }
        #endregion
    }
}
