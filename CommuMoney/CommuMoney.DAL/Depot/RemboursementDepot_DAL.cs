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
        #region GetAll
        public override List<Remboursement_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "SELECT id_personne, id_projet, dette FROM Remboursement";
            var reader = commande.ExecuteReader();

            var listeDesRemboursements = new List<Remboursement_DAL>();
            while (reader.Read())
            {
                var remboursement = new Remboursement_DAL(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            reader.GetDouble(2));
                listeDesRemboursements.Add(remboursement);
            }

            dbClose();
            return listeDesRemboursements;

        }
        #endregion

        #region GetByID
        public override Remboursement_DAL GetByID(int ID)
        {
            dbConnect();
            commande.CommandText = "SELECT id, id_personne, id_projet, dette FROM Remboursement WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Remboursement_DAL remboursement;

            if (reader.Read())
            {
                remboursement = new Remboursement_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDouble(3));
            }
            else
            {
                throw new Exception($"Pas de remboursement de disponible avec l'ID {ID}");
            }

            dbClose();
            return remboursement;
        }
        #endregion

        #region GetRemboursementByID_Personne
        public Remboursement_DAL GetRemboursementByID_Personne(int ID_Personne)
        {
            dbConnect();
            commande.CommandText = "SELECT id, id_personne, id_projet, dette FROM Remboursement WHERE ID_Personne=@ID_Personne";
            commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
            var reader = commande.ExecuteReader();

            Remboursement_DAL remboursement;

            if (reader.Read())
            {
                remboursement = new Remboursement_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDouble(3));
            }
            else
            {
                throw new Exception($"Pas de remboursement de disponible avec l'ID_Personne {ID_Personne}");
            }

            dbClose();
            return remboursement;
        }
        #endregion

        #region GetRemboursementByID_Projet
        public Remboursement_DAL GetRemboursementByID_Projet(int ID_Projet)
        {
            dbConnect();
            commande.CommandText = "SELECT id, id_personne, id_projet, dette FROM Remboursement WHERE ID_Projet=@ID_Projet";
            commande.Parameters.Add(new SqlParameter("@ID_Projet", ID_Projet));
            var reader = commande.ExecuteReader();

            Remboursement_DAL remboursement;

            if (reader.Read())
            {
                remboursement = new Remboursement_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDouble(3));
            }
            else
            {
                throw new Exception($"Pas de remboursement de disponible avec l'ID_Projet {ID_Projet}");
            }

            dbClose();
            return remboursement;
        }
        #endregion

        #region Insert
        public override Remboursement_DAL Insert(Remboursement_DAL remboursement)
        {
            dbConnect();

            commande.CommandText = "INSERT INTO Remboursement (id_personne, id_projet, dette) VALUES (@ID_Personne, @ID_Projet, @Dette); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_Personne", remboursement.ID_Personne));
            commande.Parameters.Add(new SqlParameter("@ID_Projet", remboursement.ID_Projet));
            commande.Parameters.Add(new SqlParameter("@Dette", remboursement.Dette));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            remboursement.ID = ID;

            dbClose();

            return remboursement;
        }
        #endregion

        #region Update
        public override Remboursement_DAL Update(Remboursement_DAL remboursement)//On peut changer que la dette, vu que les IDs sont déjà fixés..?
        {
            dbConnect();

            commande.CommandText = "UPDATE Remboursement SET dette=@DETTE WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@DETTE", remboursement.Dette));
            commande.Parameters.Add(new SqlParameter("@ID", remboursement.ID));
            
            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le remboursement avec l'ID {remboursement.ID}");
            }

            dbClose();
            return remboursement;
        }
        #endregion

        #region Delete
        public override void Delete(Remboursement_DAL remboursement)
        {
            dbConnect();

            commande.CommandText = "DELETE FROM Remboursement WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", remboursement.ID));
            var nbLigne = (int)commande.ExecuteNonQuery();

            if (nbLigne != 1)
            {
                throw new Exception($"Impossible de supprimer le remboursement d'ID {remboursement.ID}");
            }

            dbClose();
        }
        #endregion
    }
}
