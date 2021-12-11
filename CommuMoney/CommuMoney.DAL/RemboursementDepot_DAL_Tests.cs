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

            var rem = new Remboursement_DAL(id_personne, id_projet, dette, DateTime.Now);//Je ne pense pas être censé ajouter manuellement l'ID, (et/ou la date de création..?)
            var depot = new RemboursementDepot_DAL();

            depot.Insert(rem);

            Assert.NotNull(rem);
            Assert.NotNull(rem.Created_at);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_GetAll()
        {
            var depot = new RemboursementDepot_DAL();
            var rem = depot.GetAll();

            Assert.NotNull(rem);

        }

        
       

        [Fact]
        public void RemboursementDepot_DAL_Test_GetByID()
        {
            var depot = new RemboursementDepot_DAL();
            var rem = depot.GetByID(1);//

            Assert.NotNull(rem);
            Assert.Equal(1, rem.ID);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var depot = new RemboursementDepot_DAL();
            var rem = depot.GetByID(1);
            
            depot.Delete(rem);

            Assert.Null(rem);
        }
    }
}
