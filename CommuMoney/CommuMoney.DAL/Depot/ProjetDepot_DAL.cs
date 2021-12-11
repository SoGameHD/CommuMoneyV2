using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL
{
    public class ProjetDepot_DAL : Depot_DAL<Projet_DAL>
    {
        public override void Delete(Projet_DAL projet)
        {
            dbConnect();

            commande.CommandText = "delete from Projet where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", projet.ID));
            var nbLigne = (int)commande.ExecuteNonQuery();

            if (nbLigne!=1)
            {
                throw new Exception($"Impossible de supprimer le point d'ID {projet.ID}");
            }
            
            dbClose();
        }

      

        public override List<Projet_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "select * from Projet";
            var reader = commande.ExecuteReader();

            var listeDesProjets = new List<Projet_DAL>();
            while (reader.Read())
            {
                var proj = new Projet_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetInt32(2),
                                            reader.GetFloat(3),
                                            reader.GetFloat(4),
                                            reader.GetDateTime(5));
                listeDesProjets.Add(proj);
            }

            dbClose();
            return listeDesProjets;

        }


        public override Projet_DAL GetByID(int ID)
        {
            dbConnect();
            commande.CommandText = "select * from Remboursement where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Projet_DAL proj;

            if (reader.Read())
            {
                proj = new Projet_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetInt32(2),
                                            reader.GetFloat(3),
                                            reader.GetFloat(4),
                                            reader.GetDateTime(5));
            }
            else
            {
                throw new Exception($"Pas de remboursement de disponible avec l'ID {ID}");
            }

            dbClose();
            return proj;
        }

        

        public override Projet_DAL Insert(Projet_DAL projet)
        {
            dbConnect();

            commande.CommandText = "insert into Remboursement(id, nom, id_personne, total_montant, moyenne ,created_at) values (@ID, @NOM, @ID_PERSONNE, @TOTAL, @MOYENNE , @CREATED_AT); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@ID", projet.ID));
            commande.Parameters.Add(new SqlParameter("@NOM", projet.NOM));
            commande.Parameters.Add(new SqlParameter("@ID_PERSONNE", projet.ID_PERSONNE));
            commande.Parameters.Add(new SqlParameter("@TOTAL", projet.TOTAL_MONTANT));
            commande.Parameters.Add(new SqlParameter("@MOYENNE", projet.MOYENNE));
            commande.Parameters.Add(new SqlParameter("@CREATED_AT", projet.Created_at));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            projet.ID = ID;

            dbClose();

            return projet;
        }

        
        public override Projet_DAL Update(Projet_DAL projet)//Ajouter une personne, modifi
        {
            dbConnect();

            commande.CommandText = "update Projet set nom=@NOM,id_personne=@ID_PERSONNE,total_montant=@TOTAL,moyenne=@MOYENNE, updated_at=getDate() where id_remboursement=@ID";
            commande.Parameters.Add(new SqlParameter("@NOM", projet.NOM));
            commande.Parameters.Add(new SqlParameter("@ID_PERSONNE", projet.ID_PERSONNE));
            commande.Parameters.Add(new SqlParameter("@TOTAL", projet.TOTAL_MONTANT));
            commande.Parameters.Add(new SqlParameter("@MOYENNE", projet.MOYENNE));
            commande.Parameters.Add(new SqlParameter("@ID", projet.ID));
            
            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour la dépense avec l'ID {projet.ID}");
            }

            dbClose();
            return projet;
        }
    }
}
