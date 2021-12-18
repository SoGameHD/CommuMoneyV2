using System;
using Xunit;
using CommuMoney.METIER.Metier;
using CommuMoney.DAL.Depot;

namespace CommuMoney.METIER.Tests
{
    public class Remboursement_METIER_Tests
    {
        #region Remboursement_METIER_Test_Insert
        [Fact]
        public void Remboursement_METIER_Tests_Insert()
        {
            int id_personne = 1;
            int id_projet = 1;
            double dette = 0;

            var remboursement = new Remboursement_METIER(id_personne, id_projet, dette);

            remboursement.Insert();

            Assert.NotNull(remboursement);
            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);
        }
        #endregion

        #region Remboursement_METIER_Test_Update
        [Fact]
        public void Remboursement_METIER_Tests_Update()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 50;

            var remboursement = new Remboursement_METIER(id, id_personne, id_projet, dette);

            remboursement.Update();

            Assert.NotNull(remboursement);
            Assert.Equal(id, remboursement.ID);
            Assert.Equal(id_personne, remboursement.ID_Personne);
            Assert.Equal(id_projet, remboursement.ID_Projet);
            Assert.Equal(dette, remboursement.Dette);
        }
        #endregion

        #region Remboursement_METIER_Test_Delete
        [Fact]
        public void Remboursement_METIER_Test_Delete()
        {
            int id = 1;
            int id_personne = 1;
            int id_projet = 1;
            double dette = 50;

            var remboursement = new Remboursement_METIER(id, id_personne, id_projet, dette);

            remboursement.Delete();
        }
        #endregion
    }
}
