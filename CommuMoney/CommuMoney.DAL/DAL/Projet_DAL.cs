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
        public float Total_Montant { get; set; }
        public float Moyenne { get; set; }
        public DateTime? Date_Soiree { get; set; }

        public Projet_DAL(string nom, int id_personne, float total_montant, float moyenne, DateTime? date_soiree) => (Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (nom, id_personne, total_montant, moyenne, date_soiree);
        public Projet_DAL(int id, string nom, int id_personne, float total_montant, float moyenne, DateTime? date_soiree) => (ID, Nom, ID_Personne, Total_Montant, Moyenne, Date_Soiree) = (id, nom, id_personne, total_montant, moyenne, date_soiree);

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Projet(nom, id_personne, total_montant, moyenne, date_soiree) VALUES (@Nom, @ID_Personne, @Total_Montant, @Moyenne, @Date_Soiree); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
                commande.Parameters.Add(new SqlParameter("@Total_Montant", Total_Montant));
                commande.Parameters.Add(new SqlParameter("@Moyenne", Moyenne));
                commande.Parameters.Add(new SqlParameter("@Date_Soiree", Date_Soiree));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion

    }
}
