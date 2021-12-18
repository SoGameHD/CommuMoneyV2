using System;
using Xunit;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Tests
{
    public class Depenses_METIER_Tests
    {
        #region Depenses_METIER_Test_Insert
        [Fact]
        public void Depenses_METIER_Test_Insert()
        {
            int id_personne = 1;
            int id_projet = 1;
            double montant = 0;

            var depense = new Depenses_METIER(id_personne, id_projet, montant);

            depense.Insert();

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
        }
        #endregion

        #region Depenses_METIER_Test_Update
        [Fact]
        public void Depenses_METIER_Test_Update()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double montant = 50;

            var depense = new Depenses_METIER(id, id_personne, id_projet, montant);

            depense.Update();

            Assert.NotNull(depense);
            Assert.Equal(id_personne, depense.ID_Personne);
            Assert.Equal(id_projet, depense.ID_Projet);
            Assert.Equal(montant, depense.Montant);
        }
        #endregion

        #region Depenses_METIER_Test_Delete
        [Fact]
        public void Depenses_METIER_Test_Delete()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double montant = 50;

            var depense = new Depenses_METIER(id, id_personne, id_projet, montant);

            depense.Delete();
        }
        #endregion
    }
}
