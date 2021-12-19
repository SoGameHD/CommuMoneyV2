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

        #region GetProjetByID_Personne
        public List<Projet_METIER> GetProjetByID_Personne(int id_personne)
        {
            var res = new List<Projet_METIER>();
            var depot = new ProjetDepot_DAL();

            foreach (var item in depot.GetProjetByIDPersonne(id_personne))
            {
                res.Add(new Projet_METIER(item.ID, item.Nom, item.ID_Personne, item.Total_Montant, item.Moyenne, item.Date_Soiree));
            }
            return res;
        }
        #endregion

        #region GetListeProjetByID_Personne
        public List<Projet_METIER> GetListeProjetByID_Personne(int id_personne)
        {
            var result = new List<Projet_METIER>();
            var depot = new ProjetDepot_DAL();
            foreach (var item in depot.GetListeProjetByID_Personne(id_personne))
            {
                result.Add(new Projet_METIER(item.ID, item.Nom, item.ID_Personne, item.Total_Montant, item.Moyenne, item.Date_Soiree));
            }
            return result;
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

        #region Update
        public Projet_METIER Update(Projet_METIER input)
        {
            var projet = new Projet_DAL(input.ID, input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Date_Soiree);
            var depot = new ProjetDepot_DAL();
            depot.Update(projet);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(Projet_METIER input)
        {
            var projet = new Projet_DAL(input.ID, input.Nom, input.ID_Personne, input.Total_Montant, input.Moyenne, input.Date_Soiree);
            ProjetDepot_DAL depot = new ProjetDepot_DAL();
            projet = depot.GetByID(input.ID);
            depot.Delete(projet);
        }
        #endregion
    }
}