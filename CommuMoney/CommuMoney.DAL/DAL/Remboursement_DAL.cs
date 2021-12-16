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
        public int ID_PERSONNE { get; set; }
        public int ID_PROJET { get; set; }
        public float DETTE { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Created_at { get; set; }

        public Remboursement_DAL(int id, int id_personne, int id_projet, float dette, DateTime? created_at, DateTime? updated_at)
        {
            ID = id;
            ID_PERSONNE = id_personne;
            ID_PROJET = id_projet;
            DETTE = dette;
            Created_at = created_at;
            Updated_at = updated_at;

        }
        public Remboursement_DAL(int id_personne, int id_projet, float dette, DateTime? created_at, DateTime? updated_at)
        {
            ID_PERSONNE = id_personne;
            ID_PROJET = id_projet;
            DETTE = dette;
            Created_at = created_at;
            Updated_at = updated_at;
        }

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Remboursement(id_personne, id_projet, dette, created_at, updated_at) VALUES (@id_personne, @id_projet,@dette, @Created_at, @Updated_at); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@id_personne", ID_PERSONNE));
                commande.Parameters.Add(new SqlParameter("@id_projet", ID_PROJET));
                commande.Parameters.Add(new SqlParameter("@dette", DETTE));
                commande.Parameters.Add(new SqlParameter("@Created_at", Created_at));
                commande.Parameters.Add(new SqlParameter("@Updated_at", Updated_at));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
