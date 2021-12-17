using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;
using System;
using Xunit;

namespace CommuMoney.DAL.Tests
{
    
    public class RemboursementDepot_DAL_Tests
    {
        #region RemboursementDepot_DAL_Test_Insert
        [Fact]
        public void RemboursementDepot_DAL_Test_Insert()
        {
            var id_personne = 1;
            var id_projet = 1;
            var dette = 0;

            var remboursement = new Remboursement_DAL(0, id_personne, id_projet, dette);
            var depot = new RemboursementDepot_DAL();

            depot.Insert(remboursement);

            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);
            Assert.NotNull(remboursement);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_GetAll
        [Fact]
        public void RemboursementDepot_DAL_Test_GetAll()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetAll();

            Assert.NotNull(remboursement);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_GetByID
        [Fact]
        public void RemboursementDepot_DAL_Test_GetByID()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetByID(2); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(remboursement);
            Assert.Equal(2, remboursement.ID);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_Update
        [Fact]
        public void RemboursementDepot_DAL_Test_Update()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = new Remboursement_DAL(2, 1, 1, 50);

            depot.Update(remboursement);

            Assert.NotNull(remboursement);
            Assert.Equal(50, remboursement.Dette);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_Delete
        [Fact]
        public void RemboursementDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var remboursement = new Remboursement_DAL(1,56, 5, 41);
            var depot = new RemboursementDepot_DAL();
            
            
            depot.Delete(remboursement);

            Assert.Null(remboursement);
        }
        #endregion
    }
}
