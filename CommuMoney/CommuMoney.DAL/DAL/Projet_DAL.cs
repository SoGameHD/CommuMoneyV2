using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL
{
    public class Projet_DAL
    {
        public int ID { get; set; }
        public string NOM{ get; set; }
        public int ID_PERSONNE { get; set; }
        public float TOTAL_MONTANT { get; set; }
        public float MOYENNE { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Created_at { get; set; }

        public Projet_DAL(int id, string nom,int id_personne,float total_montant, float moyenne, DateTime? created_at, DateTime? updated_at)
        {
            ID = id;
            NOM = nom;
            ID_PERSONNE = id_personne;
            TOTAL_MONTANT = total_montant;
            MOYENNE = moyenne;
            Created_at = created_at;
            Updated_at = updated_at;
        }
        public Projet_DAL(string nom, int id_personne, float total_montant, float moyenne, DateTime? created_at, DateTime? updated_at)
        {
            NOM = nom;
            ID_PERSONNE = id_personne;
            TOTAL_MONTANT = total_montant;
            MOYENNE = moyenne;
            Created_at = created_at;
            Updated_at = updated_at;
        }


        #region Insert
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Projet(nom, id_personne, total_montant, moyenne,created_at) values(@nom, @id_personne,@total_montant,@moyenne, @Created_At); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@nom", NOM));
                commande.Parameters.Add(new SqlParameter("@id_personne", ID_PERSONNE));
                commande.Parameters.Add(new SqlParameter("@total_montant", TOTAL_MONTANT));
                commande.Parameters.Add(new SqlParameter("@moyenne", MOYENNE));
                commande.Parameters.Add(new SqlParameter("@Created_At", Created_at));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion

    }
}
