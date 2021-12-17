using System;
using Xunit;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.DAL.Tests
{
    public class DepensesDepot_DAL_Tests
    {
        #region DepensesDepot_DAL_Test_Insert
        [Fact]
        public void DepensesDepot_DAL_Test_Insert()
        {
            var id_personne = 1;
            var id_projet = 1;
            var montant = 0;

            var depense = new Depenses_DAL(0, id_personne, id_projet, montant);
            var depot = new DepensesDepot_DAL();

            depot.Insert(depense);

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
        }
        #endregion

        #region DepensesDepot_DAL_Test_GetAll
        [Fact]
        public void DepensesDepot_DAL_Test_GetAll()
        {
            var depot = new DepensesDepot_DAL();
            var depense = depot.GetAll();

            Assert.NotNull(depense);
        }
        #endregion

        #region DepensesDepot_DAL_Test_GetByID
        [Fact]
        public void DepensesDepot_DAL_Test_GetByID()
        {
            var depot = new RemboursementDepot_DAL();
            var depense = depot.GetByID(3); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(depense);
            Assert.Equal(3, depense.ID);
        }
        #endregion

        #region DepensesDepot_DAL_Test_Update
        [Fact]
        public void DepensesDepot_DAL_Test_Update()
        {
            int id = 2;
            int id_personne = 1;
            int id_projet = 1;
            float montant = 50;

            var depot = new DepensesDepot_DAL();
            var depense = new Depenses_DAL(id, id_personne, id_projet, montant);

            depot.Update(depense);

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
        }
        #endregion

        #region DepensesDepot_DAL_Test_Delete
        [Fact]
        public void DepensesDepot_DAL_Test_Delete() //DELETE TOUJOURS EN DERNIER
        {
            var depense = new Depenses_DAL(1, 56, 5, 41);
            var depot = new DepensesDepot_DAL();
            
            depot.Delete(depense);

            depot.GetByID(depense.ID);
        }
        #endregion
    }
}
