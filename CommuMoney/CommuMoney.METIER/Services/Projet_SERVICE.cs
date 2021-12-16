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
    public class Projet_SERVICE
    {
        #region GetAll
        public List<Projet_METIER> GetAll()
        {
            var result = new List<Projet_METIER>();
            var depot = new ProjetDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Projet_METIER(item.ID, item.NOM, item.ID_PERSONNE, item.TOTAL_MONTANT, item.MOYENNE, item.Created_at, item.Updated_at));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Projet_METIER GetByID(int id)
        {
            var depot = new ProjetDepot_DAL();
            var personne = depot.GetByID(id);
            return new Projet_METIER(personne.ID, personne.NOM, personne.ID_PERSONNE, personne.TOTAL_MONTANT, personne.MOYENNE, personne.Created_at, personne.Updated_at);
        }
        #endregion

        #region Insert
        public Projet_METIER Insert(Projet_METIER input)
        {
            var projet = new Projet_DAL(input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Created_At, input.Updated_At);
            var depot = new ProjetDepot_DAL();
            depot.Insert(projet);

            return input;
        }
        #endregion

        #region Edit
        public Projet_METIER Edit(int id, Projet_METIER input)
        {
            var projet = new Projet_DAL(id, input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Created_At, input.Updated_At);
            var depot = new ProjetDepot_DAL();
            depot.Update(projet);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Projet_DAL projet;
            ProjetDepot_DAL depot = new ProjetDepot_DAL();
            projet = depot.GetByID(id);
            depot.Delete(projet);
        }
        #endregion
    }
}