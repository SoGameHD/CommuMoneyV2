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
    public class Remboursement_SERVICE
    {
        #region GetAll
        public List<Remboursement_METIER> GetAll()
        {
            var result = new List<Remboursement_METIER>();
            var depot = new RemboursementDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Remboursement_METIER(item.ID, item.ID_PERSONNE, item.ID_PROJET, item.DETTE, item.Created_at, item.Updated_at));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Remboursement_METIER GetByID(int id)
        {
            var depot = new RemboursementDepot_DAL();
            var personne = depot.GetByID(id);
            return new Remboursement_METIER(personne.ID, personne.ID_PERSONNE, personne.ID_PROJET, personne.DETTE, personne.Created_at, personne.Updated_at);
        }
        #endregion

        #region Insert
        public Remboursement_METIER Insert(Remboursement_METIER input)
        {
            var projet = new Remboursement_DAL(input.ID_Personne, input.ID_Projet, input.Dette, input.Created_At, input.Updated_At);
            var depot = new RemboursementDepot_DAL();
            depot.Insert(projet);

            return input;
        }
        #endregion

        #region Edit
        public Remboursement_METIER Edit(int id, Remboursement_METIER input)
        {
            var projet = new Remboursement_DAL(id, input.ID_Personne, input.ID_Projet, input.Dette, input.Created_At, input.Updated_At);
            var depot = new RemboursementDepot_DAL();
            depot.Update(projet);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Remboursement_DAL projet;
            RemboursementDepot_DAL depot = new RemboursementDepot_DAL();
            projet = depot.GetByID(id);
            depot.Delete(projet);
        }
        #endregion
    }
}