using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Remboursement_DAL
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public float Dette { get; set; }

        public Remboursement_DAL(int id, int id_personne, int id_projet, float dette)
        {
            ID = id;
            ID_Personne = id_personne;
            ID_Projet = id_projet;
            Dette = dette;

        }
        public Remboursement_DAL(int id_personne, int id_projet, float dette)
        {
            ID_Personne = id_personne;
            ID_Projet = id_projet;
            Dette = dette;
        }

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Remboursement(id_personne, id_projet, dette) VALUES (@ID_Personne, @ID_Projet, @Dette); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
                commande.Parameters.Add(new SqlParameter("@ID_Projet", ID_Projet));
                commande.Parameters.Add(new SqlParameter("@Dette", Dette));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
