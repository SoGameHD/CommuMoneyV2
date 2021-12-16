﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.Depot;
using CommuMoney.DAL.DAL;
using CommuMoney.METIER.Metier;

namespace CommuMoney.METIER.Services
{
    public class Personnnes_SERVICES
    {
        #region GetAll
        public List<Personnes_METIER> GetAll()
        {
            var result = new List<Personnes_METIER>();
            var depot = new PersonnesDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Personnes_METIER(item.ID, item.Nom, item.Prenom, item.Created_At, item.Updated_At));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Personnes_METIER GetByID(int id)
        {
            var depot = new PersonnesDepot_DAL();
            var personne = depot.GetByID(id);
            return new Personnes_METIER(personne.ID, personne.Nom, personne.Prenom, personne.Created_At, personne.Updated_At);
        }
        #endregion

        #region Insert
        public Personnes_METIER Insert(Personnes_METIER input)
        {
            var personne = new Personnes_DAL(input.Nom, input.Prenom, input.Created_At, input.Updated_At);
            var depot = new PersonnesDepot_DAL();
            depot.Insert(personne);

            return input;
        }
        #endregion

        #region Edit
        public Personnes_METIER Edit(int id, Personnes_METIER input)
        {
            var personne = new Personnes_DAL(id, input.Nom, input.Prenom, input.Created_At, input.Updated_At);
            var depot = new PersonnesDepot_DAL();
            depot.Update(personne);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Personnes_DAL personne;
            PersonnesDepot_DAL depot = new PersonnesDepot_DAL();
            personne = depot.GetByID(id);
            depot.Delete(personne);
        }
        #endregion
    }
}