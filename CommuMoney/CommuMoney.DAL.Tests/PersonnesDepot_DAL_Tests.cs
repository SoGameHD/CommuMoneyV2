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
            string nom = "Brant";
            string prenom = "Jacques";

            var depot = new PersonnesDepot_DAL();
            var personne = new Personnes_DAL(nom, prenom);

            depot.Insert(personne);

            Assert.NotNull(personne);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
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
            int id = 1;

            var depot = new PersonnesDepot_DAL();
            var personne = depot.GetByID(id); // L'ID devra obligatoirement exister pour faire fonctionner ce test.

            Assert.NotNull(personne);
            Assert.Equal(id, personne.ID);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_Update
        [Fact]
        public void PersonnesDepot_DAL_Test_Update()
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var depot = new PersonnesDepot_DAL();
            var personne = new Personnes_DAL(id, nom, prenom);

            depot.Update(personne);

            Assert.NotNull(personne);
            Assert.Equal(id, personne.ID);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
        }
        #endregion

        #region PersonnesDepot_DAL_Test_Delete
        [Fact]
        public void PersonnesDepot_DAL_Test_Delete()//DELETE TOUJOURS EN DERNIER
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var depot = new PersonnesDepot_DAL();
            var personne = new Personnes_DAL(id, nom, prenom);

            depot.Delete(personne);

            Assert.Throws<Exception>(() => depot.GetByID(personne.ID));
        }
        #endregion
    }
}
