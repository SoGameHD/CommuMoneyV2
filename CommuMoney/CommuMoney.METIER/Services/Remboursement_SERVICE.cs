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
                result.Add(new Remboursement_METIER(item.ID, item.ID_Personne, item.ID_Projet, item.Dette));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Remboursement_METIER GetByID(int id)
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetByID(id);
            return new Remboursement_METIER(remboursement.ID, remboursement.ID_Personne, remboursement.ID_Projet, remboursement.Dette);
        }
        #endregion

        #region GetRemboursementByID_Personne
        public Remboursement_METIER GetRemboursementByID_Personne(int id_personne)
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetRemboursementByID_Personne(id_personne);
            return new Remboursement_METIER(remboursement.ID, remboursement.ID_Personne, remboursement.ID_Projet, remboursement.Dette);
        }
        #endregion

        #region GetRemboursementByID_Projet
        public Remboursement_METIER GetRemboursementByID_Projet(int id_projet)
        {
            var depot = new RemboursementDepot_DAL();
            var remboursement = depot.GetRemboursementByID_Projet(id_projet);
            return new Remboursement_METIER(remboursement.ID, remboursement.ID_Personne, remboursement.ID_Projet, remboursement.Dette);
        }
        #endregion

        #region GetListeRemboursementByID_Projet
        public List<Remboursement_METIER> GetListeRemboursementByID_Projet(int id_projet)
        {
            var result = new List<Remboursement_METIER>();
            var depot = new RemboursementDepot_DAL();
            foreach (var item in depot.GetListeRemboursementByID_Projet(id_projet))
            {
                result.Add(new Remboursement_METIER(item.ID, item.ID_Personne, item.ID_Projet, item.Dette));
            }
            return result;
        }
        #endregion

        #region Insert
        public Remboursement_METIER Insert(Remboursement_METIER input)
        {
            var remboursement = new Remboursement_DAL(input.ID_Personne, input.ID_Projet, input.Dette);
            var depot = new RemboursementDepot_DAL();
            depot.Insert(remboursement);

            return input;
        }
        #endregion

        #region Update
        public Remboursement_METIER Update(Remboursement_METIER input)
        {
            var remboursement = new Remboursement_DAL(input.ID, input.ID_Personne, input.ID_Projet, input.Dette);
            var depot = new RemboursementDepot_DAL();
            depot.Update(remboursement);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(Remboursement_METIER input)
        {
            var remboursement = new Remboursement_DAL(input.ID, input.ID_Personne, input.ID_Projet, input.Dette);
            RemboursementDepot_DAL depot = new RemboursementDepot_DAL();
            remboursement = depot.GetByID(input.ID);
            depot.Delete(remboursement);
        }
        #endregion
    }
}