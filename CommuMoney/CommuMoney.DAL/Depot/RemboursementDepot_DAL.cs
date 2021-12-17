using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;

namespace CommuMoney.DAL.Depot
{
    public class RemboursementDepot_DAL : Depot_DAL<Remboursement_DAL>
    {
        public override void Delete(Remboursement_DAL remboursement)
        {
            dbConnect();

            commande.CommandText = "delete from Remboursement where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", remboursement.ID));
            var nbLigne = (int)commande.ExecuteNonQuery();

            if (nbLigne!=1)
            {
                throw new Exception($"Impossible de supprimer le remboursement d'ID {remboursement.ID}");
            }
            
            dbClose();
        }

        public override List<Remboursement_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "select * from Remboursement";
            var reader = commande.ExecuteReader();

            var listeDesRemboursements = new List<Remboursement_DAL>();
            while (reader.Read())
            {
                var rem = new Remboursement_DAL(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            reader.GetInt32(2),
                                            reader.GetFloat(3),
                                            reader.GetDateTime(4),
                                            reader.GetDateTime(5));
                listeDesRemboursements.Add(rem);
            }

            dbClose();
            return listeDesRemboursements;

        }


        public override Remboursement_DAL GetByID(int ID)
        {
            dbConnect();
            commande.CommandText = "select * from Remboursement where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Remboursement_DAL rem;

            if (reader.Read())
            {
                rem = new Remboursement_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetFloat(3),
                                        reader.GetDateTime(4),
                                        reader.GetDateTime(5));
            }
            else
            {
                throw new Exception($"Pas de remboursement de disponible avec l'ID {ID}");
            }

            dbClose();
            return rem;
        }


        public override Remboursement_DAL Insert(Remboursement_DAL remboursement)
        {
            dbConnect();

            commande.CommandText = "INSERT INTO Remboursement(id_personne, id_projet, dette, created_at, updated_at) VALUES (@ID_PERSONNE, @ID_PROJET, @DETTE, @CREATED_AT, @UPDATED_AT); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_PERSONNE", remboursement.ID_PERSONNE));
            commande.Parameters.Add(new SqlParameter("@ID_PROJET", remboursement.ID_PROJET));
            commande.Parameters.Add(new SqlParameter("@DETTE", remboursement.DETTE));
            commande.Parameters.Add(new SqlParameter("@CREATED_AT", remboursement.Created_at));
            commande.Parameters.Add(new SqlParameter("@UPDATED_AT", remboursement.Updated_at));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            remboursement.ID = ID;

            dbClose();

            return remboursement;
        }

        
        public override Remboursement_DAL Update(Remboursement_DAL remboursement)//On peut changer que la dette, vu que les IDs sont déjà fixés..?
        {
            dbConnect();

            commande.CommandText = "update Remboursement set dette=@DETTE, updated_at=getDate() where id_remboursement=@ID";
            commande.Parameters.Add(new SqlParameter("@DETTE", remboursement.DETTE));
            commande.Parameters.Add(new SqlParameter("@ID", remboursement.ID));
            
            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour la dépense avec l'ID {remboursement.ID}");
            }

            dbClose();
            return remboursement;
        }
    }
}
