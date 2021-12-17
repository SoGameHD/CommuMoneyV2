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

            var depense = new Depenses_DAL(0, id_personne, id_projet, montant, DateTime.Now, DateTime.Now);
            var depot = new DepensesDepot_DAL();

            depot.Insert(depense);

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
            Assert.NotNull(depense.Created_At);
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
            var remboursement = depot.GetByID(1); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(remboursement);
            Assert.Equal(1, remboursement.ID);
        }
        #endregion

        #region DepensesDepot_DAL_Test_Update
        [Fact]
        public void DepensesDepot_DAL_Test_Update()
        {
            var id_personne = 1;
            var id_projet = 1;
            var montant = 50;

            var depot = new DepensesDepot_DAL();
            var depense = new Depenses_DAL(id_personne, id_projet, montant, DateTime.Now, DateTime.Now);

            depot.Update(depense);

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
            Assert.NotNull(depense.Updated_At);
        }
        #endregion

        #region DepensesDepot_DAL_Test_Delete
        [Fact]
        public void DepensesDepot_DAL_Test_Delete() //DELETE TOUJOURS EN DERNIER
        {
            var depense = new Depenses_DAL(1, 56, 5, 41, DateTime.Now, DateTime.Now);
            var depot = new DepensesDepot_DAL();


            depot.Delete(depense);

            Assert.Null(depense);
        }
        #endregion
    }
}
