using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.METIER.Metier
{
    public class Depenses_METIER
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public float Montant { get; set; }

        public Depenses_METIER(int id_personne, int id_projet, float montant) => (ID_Personne, ID_Projet, Montant) = (id_personne, id_projet, montant);
        public Depenses_METIER(int id, int id_personne, int id_projet, float montant) => (ID, ID_Personne, ID_Projet, Montant) = (id, id_personne, id_projet, montant);

        #region Insert
        public void Insert()
        {
            Depenses_DAL depense = new Depenses_DAL(ID_Personne, ID_Projet, Montant);
            var depotDepense = new DepensesDepot_DAL();
            depense = depotDepense.Insert(depense);

            ID = depense.ID;
        }
        #endregion

        #region Update
        public void Update()
        {
            Depenses_DAL depense = new Depenses_DAL(ID, ID_Personne, ID_Projet, Montant);
            var depotDepense = new DepensesDepot_DAL();
            depotDepense.Update(depense);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Depenses_DAL depense = new Depenses_DAL(ID, ID_Projet, ID_Personne, Montant);
            var depotDepense = new DepensesDepot_DAL();
            depotDepense.Delete(depense);
        }
        #endregion
    }
}
