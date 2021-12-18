using System;
using Xunit;
using CommuMoney.METIER.Services;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Personnes_SERVICE_Tests
    {
        #region Personnes_SERVICE_Tests_Insert
        [Fact]
        public void Personnes_SERVICE_Tests_Insert()
        {
            string nom = "Brant";
            string prenom = "Jacques";

            var depot = new Personnnes_SERVICES();
            var personne = new Personnes_METIER(nom, prenom);

            depot.Insert(personne);

            Assert.NotNull(personne);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);

        }
        #endregion

        #region Personnes_SERVICE_Tests_GetAll
        [Fact]
        public void Personnes_SERVICE_Tests_GetAll()
        {
            var depot = new Personnnes_SERVICES();
            var personne = depot.GetAll();

            Assert.NotNull(personne);
        }
        #endregion

        #region Personnes_SERVICE_Tests_GetByID
        [Fact]
        public void Personnes_SERVICE_Tests_GetByID()
        {
            int id = 1;

            var depot = new Personnnes_SERVICES();
            var personne = depot.GetByID(id);

            Assert.NotNull(personne);
            Assert.Equal(id, personne.ID);
        }
        #endregion

        #region Personnes_SERVICE_Tests_Update
        [Fact]
        public void Personnes_SERVICE_Tests_Update()
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var depot = new Personnnes_SERVICES();
            var personne = new Personnes_METIER(id, nom, prenom);

            depot.Update(personne);

            Assert.NotNull(personne);
            Assert.Equal(id, personne.ID);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
        }
        #endregion

        #region Personnes_SERVICE_Tests_Delete
        [Fact]
        public void Personnes_SERVICE_Tests_Delete()
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var personne = new Personnes_METIER(id, nom, prenom);
            var depot = new Personnnes_SERVICES();

            depot.Delete(personne);
            depot.GetByID(personne.ID);
        }
        #endregion
    }
}
