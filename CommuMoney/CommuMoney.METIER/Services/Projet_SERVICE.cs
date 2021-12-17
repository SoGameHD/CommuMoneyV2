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
                result.Add(new Projet_METIER(item.ID, item.Nom, item.ID_Personne, item.Total_Montant, item.Moyenne, item.Date_Soiree));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Projet_METIER GetByID(int id)
        {
            var depot = new ProjetDepot_DAL();
            var projet = depot.GetByID(id);
            return new Projet_METIER(projet.ID, projet.Nom, projet.ID_Personne, projet.Total_Montant, projet.Moyenne, projet.Date_Soiree);
        }
        #endregion

        #region Insert
        public Projet_METIER Insert(Projet_METIER input)
        {
            var projet = new Projet_DAL(input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Date_Soiree);
            var depot = new ProjetDepot_DAL();
            depot.Insert(projet);

            return input;
        }
        #endregion

        #region Edit
        public Projet_METIER Edit(int id, Projet_METIER input)
        {
            var projet = new Projet_DAL(id, input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Date_Soiree);
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