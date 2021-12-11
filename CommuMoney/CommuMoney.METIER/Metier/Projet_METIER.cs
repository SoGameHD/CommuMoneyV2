using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL;

namespace CommuMoney.METIER.Metier
{
    public class Projet_METIER
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public int ID_Personne { get; set; }
        public float Total_Montant { get; set; }
        public float Moyenne { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        public Projet_METIER(string nom, int id_personne, float total_montant, float moyenne, DateTime? created_at, DateTime? updated_at) => (Nom, ID_Personne, Total_Montant, Moyenne, Created_At, Updated_At) = (nom, id_personne, total_montant, moyenne, created_at, updated_at);
        public Projet_METIER(int id, string nom, int id_personne, float total_montant, float moyenne, DateTime? created_at, DateTime? updated_at) => (ID, Nom, ID_Personne, Total_Montant, Moyenne, Created_At, Updated_At) = (id, nom, id_personne, total_montant, moyenne ,created_at, updated_at);

        #region Insert
        public void Insert()
        {
            Projet_DAL projet = new Projet_DAL(Nom, ID_Personne, Total_Montant, Moyenne, Created_At, Updated_At);
            var depotProjet = new ProjetDepot_DAL();
            projet = depotProjet.Insert(projet);

            ID = projet.ID;
        }
        #endregion

        #region Update
        public void Update()
        {
            Projet_DAL projet = new Projet_DAL(ID, Nom, ID_Personne, Total_Montant, Moyenne, Created_At, Updated_At);
            var depotProjet = new ProjetDepot_DAL();
            depotProjet.Update(projet);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Projet_DAL projet = new Projet_DAL(ID, Nom, ID_Personne, Total_Montant, Moyenne, Created_At, Updated_At);
            var depotProjet = new ProjetDepot_DAL();
            depotProjet.Delete(projet);
        }
        #endregion
    }
}
