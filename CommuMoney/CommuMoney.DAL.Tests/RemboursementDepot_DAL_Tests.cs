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
            int id_personne = 1;
            int id_projet = 1;
            double dette = 0;

            var remboursement = new Remboursement_DAL(id_personne, id_projet, dette);
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
            int id = 1;

            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetByID(id); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(remboursement);
            Assert.Equal(id, remboursement.ID);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_Update
        [Fact]
        public void RemboursementDepot_DAL_Test_Update()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 50;

            var depot = new RemboursementDepot_DAL();
            var remboursement = new Remboursement_DAL(id, id_personne, id_projet, dette);

            depot.Update(remboursement);

            Assert.NotNull(remboursement);
            Assert.Equal(id, remboursement.ID);
            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);
        }
        #endregion

        #region RemboursementDepot_DAL_Test_Delete
        [Fact]
        public void RemboursementDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 50;

            var depot = new RemboursementDepot_DAL();
            var remboursement = new Remboursement_DAL(id, id_personne, id_projet, dette);
            
            depot.Delete(remboursement);
            depot.GetByID(remboursement.ID);
        }
        #endregion
    }
}
