using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.METIER.Metier
{
    public class Personnes_METIER
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Personnes_METIER(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personnes_METIER(int id, string nom, string prenom) => (ID, Nom, Prenom) = (id, nom, prenom);

        #region Insert
        public void Insert()
        {
            Personnes_DAL personne = new Personnes_DAL(Nom, Prenom);
            var depotPersonne = new PersonnesDepot_DAL();
            personne = depotPersonne.Insert(personne);

            ID = personne.ID;
        }
        #endregion

        #region Update
        public void Update()
        {
            Personnes_DAL personne = new Personnes_DAL(ID, Nom, Prenom);
            var depotPersonne = new PersonnesDepot_DAL();
            depotPersonne.Update(personne);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Personnes_DAL personne = new Personnes_DAL(ID, Nom, Prenom);
            var depotPersonne = new PersonnesDepot_DAL();
            depotPersonne.Delete(personne);
        }
        #endregion
    }
}
