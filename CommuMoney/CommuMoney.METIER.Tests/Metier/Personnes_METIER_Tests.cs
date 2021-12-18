using System;
using Xunit;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Personnes_METIER_Tests
    {
        #region Personnes_METIER_Test_Insert
        [Fact]
        public void Personnes_METIER_Tests_Insert()
        {
            string nom = "Brant";
            string prenom = "Jacques";

            var personne = new Personnes_METIER(nom, prenom);

            personne.Insert();

            Assert.NotNull(personne);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
        }
        #endregion

        #region Personnes_METIER_Test_Update
        [Fact]
        public void Personnes_METIER_Tests_Update()
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var personne = new Personnes_METIER(id, nom, prenom);

            personne.Update();

            Assert.NotNull(personne);
            Assert.Equal(id, personne.ID);
            Assert.Equal(nom, personne.Nom);
            Assert.Equal(prenom, personne.Prenom);
        }
        #endregion

        #region Personnes_METIER_Test_Delete
        [Fact]
        public void Personnes_METIER_Test_Delete()
        {
            int id = 1;
            string nom = "Brant";
            string prenom = "Jacques";

            var personne = new Personnes_METIER(id, nom, prenom);

            personne.Delete();
        }
        #endregion
    }
}
