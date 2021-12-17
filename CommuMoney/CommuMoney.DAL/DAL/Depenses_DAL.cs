using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Depenses_DAL
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public double Montant { get; set; }

        public Depenses_DAL(int id_personne, int id_projet, double montant) => (ID_Personne, ID_Projet, Montant) = (id_personne, id_projet, montant);
        public Depenses_DAL(int id, int id_personne, int id_projet, double montant) => (ID, ID_Personne, ID_Projet, Montant) = (id, id_personne, id_projet, montant);

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Depenses(id_personne, id_projet, montant) VALUE (@ID_Personne, @ID_Projet, @Montant); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
                commande.Parameters.Add(new SqlParameter("@ID_Projet", ID_Projet));
                commande.Parameters.Add(new SqlParameter("@Montant", Montant));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
