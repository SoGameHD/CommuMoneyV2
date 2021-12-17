using System;
using Xunit;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.DAL.Tests
{
    public class PersonnesDepot_DAL_Tests
    {
        #region PersonnesDepot_DAL_Test_Insert
        [Fact]
        public void PersonnesDepot_DAL_Test_Insert()
        {
            var nom = "Brant";
            var prenom = "Jacques";

            var personne = new Personnes_DAL(nom, prenom, DateTime.Now, DateTime.Now);
            var depot = new PersonnesDepot_DAL();

            depot.Insert(personne);

            Assert.NotNull(personne);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
            Assert.NotNull(personne.Created_At);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_GetAll
        [Fact]
        public void PersonnesDepot_DAL_Test_GetAll()
        {
            var depot = new PersonnesDepot_DAL();
            var personne = depot.GetAll();

            Assert.NotNull(personne);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_GetByID
        [Fact]
        public void PersonnesDepot_DAL_Test_GetByID()
        {
            var depot = new RemboursementDepot_DAL();
            var personne = depot.GetByID(1); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(personne);
            Assert.Equal(1, personne.ID);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_Update
        [Fact]
        public void PersonnesDepot_DAL_Test_Update()
        {
            var nom = "Brant";
            var prenom = "Jacques";

            var depot = new PersonnesDepot_DAL();
            var personne = new Personnes_DAL(nom, prenom, DateTime.Now, DateTime.Now);

            depot.Update(personne);

            Assert.NotNull(personne);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
            Assert.NotNull(personne.Created_At);
            Assert.NotNull(personne.Updated_At);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_Delete
        [Fact]
        public void PersonnesDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            var nom = "Brant";
            var prenom = "Jacques";

            var personne = new Personnes_DAL(nom, prenom, DateTime.Now, DateTime.Now);
            var depot = new PersonnesDepot_DAL();


            depot.Delete(personne);

            Assert.Null(personne);
        }
        #endregion
    }
}
