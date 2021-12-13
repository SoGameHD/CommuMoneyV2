using System;
using Xunit;

namespace CommuMoney.DAL.Tests
{
    
    public class RemboursementDepot_DAL_Tests
    {
        [Fact]
        public void RemboursementDepot_DAL_Test_Insert()
        {
            var id_personne = 1;
            var id_projet = 1;
            var dette = 0;

            var remboursement = new Remboursement_DAL(0, id_personne, id_projet, dette, DateTime.Now, DateTime.Now); //Je ne pense pas être censé ajouter manuellement l'ID, (et/ou la date de création..?)
            var depot = new RemboursementDepot_DAL();

            depot.Insert(remboursement);

            Assert.NotNull(remboursement);
            Assert.NotNull(remboursement.Created_at);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_GetAll()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetAll();

            Assert.NotNull(remboursement);

        }

        [Fact]
        public void RemboursementDepot_DAL_Test_GetByID()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetByID(1); // L'ID devra obligatoirement eister pour faire fonctionner ce test.

            Assert.NotNull(remboursement);
            Assert.Equal(1, remboursement.ID);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_Update()
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = new Remboursement_DAL(5, 95, 0, DateTime.Now, DateTime.Now);

            depot.Update(remboursement);

            Assert.NotNull(remboursement);
            Assert.Equal(5, remboursement.ID_PERSONNE);
            Assert.Equal(95, remboursement.ID_PROJET);
            Assert.Equal(0, remboursement.DETTE);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var remboursement = new Remboursement_DAL(1,56, 5, 41, DateTime.Now, DateTime.Now);
            var depot = new RemboursementDepot_DAL();
            
            
            depot.Delete(remboursement);

            Assert.Null(remboursement);
        }
    }
}
