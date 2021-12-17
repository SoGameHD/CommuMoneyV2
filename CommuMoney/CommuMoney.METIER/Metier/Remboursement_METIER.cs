using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.METIER.Metier
{
    public class Remboursement_METIER
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public float Dette { get; set; }

        public Remboursement_METIER(int id_personne, int id_projet, float dette) => (ID_Personne, ID_Projet, Dette) = (id_personne, id_projet, dette);
        public Remboursement_METIER(int id, int id_personne, int id_projet, float dette) => (ID, ID_Personne, ID_Projet, Dette) = (id, id_personne, id_projet, dette);


        #region Insert
        public void Insert()
        {
            Remboursement_DAL remboursement = new Remboursement_DAL(ID_Personne, ID_Projet, Dette);
            var depotRemboursement = new RemboursementDepot_DAL();
            remboursement = depotRemboursement.Insert(remboursement);

            ID = remboursement.ID;
        }
        #endregion

        #region Update
        public void Update()
        {
            Remboursement_DAL remboursement = new Remboursement_DAL(ID, ID_Personne, ID_Projet, Dette);
            var depotRemboursement = new RemboursementDepot_DAL();
            depotRemboursement.Update(remboursement);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Remboursement_DAL remboursement = new Remboursement_DAL(ID, ID_Personne, ID_Projet, Dette);
            var depotRemboursement = new RemboursementDepot_DAL();
            depotRemboursement.Delete(remboursement);
        }
        #endregion
    }
}
