using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.Depot;
using CommuMoney.DAL.DAL;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Services
{
    public class Depenses_SERVICE
    {
        #region GetAll
        public List<Depenses_METIER> GetAll()
        {
            var result = new List<Depenses_METIER>();
            var depot = new DepensesDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Depenses_METIER(item.ID, item.ID_Personne, item.ID_Projet, item.Montant, item.Created_At, item.Updated_At));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Depenses_METIER GetByID(int id)
        {
            var depot = new DepensesDepot_DAL();
            var depense = depot.GetByID(id);
            return new Depenses_METIER(depense.ID, depense.ID_Personne, depense.ID_Projet, depense.Montant, depense.Created_At, depense.Updated_At);
        }
        #endregion

        #region Insert
        public Depenses_METIER Insert(Depenses_METIER input)
        {
            var depense = new Depenses_DAL(input.ID_Personne, input.ID_Projet, input.Montant, input.Created_At, input.Updated_At);
            var depot = new DepensesDepot_DAL();
            depot.Insert(depense);

            return input;
        }
        #endregion

        #region Edit
        public Depenses_METIER Edit(int id, Depenses_METIER input)
        {
            var depense = new Depenses_DAL(id, input.ID_Personne, input.ID_Projet, input.Montant, input.Created_At, input.Updated_At);
            var depot = new DepensesDepot_DAL();
            depot.Update(depense);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Depenses_DAL depense;
            DepensesDepot_DAL depot = new DepensesDepot_DAL();
            depense = depot.GetByID(id);
            depot.Delete(depense);
        }
        #endregion
    }
}