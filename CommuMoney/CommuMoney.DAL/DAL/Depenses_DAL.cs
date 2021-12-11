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
        public float Montant { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        public Depenses_DAL(int id_personne, int id_projet, float montant, DateTime? created_at, DateTime? updated_at) => (ID_Personne, ID_Projet, Montant, Created_At, Created_At) = (id_personne, id_projet, montant, created_at, updated_at);
        public Depenses_DAL(int id, int id_personne, int id_projet, float montant, DateTime? created_at, DateTime? updated_at) => (ID, ID_Personne, ID_Projet, Montant, Created_At, Created_At) = (id, id_personne, id_projet, montant, created_at, updated_at);

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Depenses(id_personne, id_projet, montant, created_at, update_at)" + "value(@ID_Personne, @ID_Projet, @Montant, @Created_at, Update_at); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
                commande.Parameters.Add(new SqlParameter("@ID_Projet", ID_Projet));
                commande.Parameters.Add(new SqlParameter("@Montant", Montant));
                commande.Parameters.Add(new SqlParameter("@Created_At", Created_At));
                commande.Parameters.Add(new SqlParameter("@Uptaded_At", Updated_At));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
