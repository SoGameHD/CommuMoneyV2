using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Projet_DAL
    {
        public int ID { get; set; }
        public string Nom{ get; set; }
        public int ID_Personne { get; set; }
        public double Total_Montant { get; set; }
        public double Moyenne { get; set; }
        public DateTime? Date_Soiree { get; set; }

        public Projet_DAL(string nom, int id_personne, double total_montant, double moyenne, DateTime? date_soiree) => (Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (nom, id_personne, total_montant, moyenne, date_soiree);
        public Projet_DAL(int id, string nom, int id_personne, double total_montant, double moyenne, DateTime? date_soiree) => (ID, Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (id, nom, id_personne, total_montant, moyenne, date_soiree);
    }
}
