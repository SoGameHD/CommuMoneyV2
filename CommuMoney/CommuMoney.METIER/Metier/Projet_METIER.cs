using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.METIER.Metier
{
    public class Projet_METIER
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public int ID_Personne { get; set; }
        public float Total_Montant { get; set; }
        public float Moyenne { get; set; }
        public DateTime? Date_Soiree { get; set; }

        public Projet_METIER(string nom, int id_personne, float total_montant, float moyenne, DateTime? date_soiree) => (Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (nom, id_personne, total_montant, moyenne, date_soiree);
        public Projet_METIER(int id, string nom, int id_personne, float total_montant, float moyenne, DateTime? date_soiree) => (ID, Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (id, nom, id_personne, total_montant, moyenne, date_soiree);

        #region Insert
        public void Insert()
        {
            Projet_DAL projet = new Projet_DAL(Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree);
            var depotProjet = new ProjetDepot_DAL();
            projet = depotProjet.Insert(projet);

            ID = projet.ID;
        }
        #endregion

        #region Update
        public void Update()
        {
            Projet_DAL projet = new Projet_DAL(ID, Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree);
            var depotProjet = new ProjetDepot_DAL();
            depotProjet.Update(projet);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Projet_DAL projet = new Projet_DAL(ID, Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree);
            var depotProjet = new ProjetDepot_DAL();
            depotProjet.Delete(projet);
        }
        #endregion
    }
}
