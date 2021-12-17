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

        public Personnes_DAL(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personnes_DAL(int id, string nom, string prenom) => (ID, Nom, Prenom) = (id, nom, prenom);

        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Personnes(nom, prenom) VALUES (@Nom, @Prenom); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}
