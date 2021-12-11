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

            var rem = new Remboursement_DAL(0,id_personne, id_projet, dette, DateTime.Now);//Je ne pense pas être censé ajouter manuellement l'ID, (et/ou la date de création..?)
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
        public void RemboursementDepot_DAL_Test_Update()
        {
            var depot = new RemboursementDepot_DAL();
            var rem = new Remboursement_DAL(5, 95, 0, DateTime.Now);

            depot.Update(rem);

            Assert.NotNull(rem);
            Assert.Equal(5, rem.ID_PERSONNE);
            Assert.Equal(95, rem.ID_PROJET);
            Assert.Equal(0, rem.DETTE);
        }

        [Fact]
        public void RemboursementDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var rem = new Remboursement_DAL(1,56, 5, 41, DateTime.Now);
            var depot = new RemboursementDepot_DAL();
            
            
            depot.Delete(rem);

            Assert.Null(rem);
        }
    }
}
