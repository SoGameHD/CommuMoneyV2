using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Personnes_DAL
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        public Personnes_DAL(string nom, string prenom, DateTime? created_at, DateTime? updated_at) => (Nom, Prenom, Created_At, Updated_At) = (nom, prenom, created_at, updated_at);
        public Personnes_DAL(int id, string nom, string prenom, DateTime? created_at, DateTime? updated_at) => (ID, Nom, Prenom, Created_At, Updated_At) = (id, nom, prenom, created_at, updated_at);

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Personnes(nom, prenom, created_at, update_at)" + "value(@Nom, @Prenom, @Created_At, Update_At); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@Created_at", Created_At));
                commande.Parameters.Add(new SqlParameter("@Uptaded_at", Updated_At));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
