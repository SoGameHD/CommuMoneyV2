using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;

namespace CommuMoney.DAL.Depot
{
    public class DepensesDepot_DAL : Depot_DAL<Depenses_DAL>
    {
        #region GetAll
        public override List<Depenses_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "SELECT id_personne, id_projet, montant, created_at, updated_at from Depenses";
            var reader = commande.ExecuteReader();

            var listeDepenses = new List<Depenses_DAL>();

            while (reader.Read())
            {
                var depense = new Depenses_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetFloat(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4));
                listeDepenses.Add(depense);
            }

            dbClose();

            return listeDepenses;
        }
        #endregion

        #region GetByID
        public override Depenses_DAL GetByID(int ID)
        {
            dbConnect();

            commande.CommandText = "SELECT ID, id_personne, id_projet, montant, created_at, updated_at FROM Depenses WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Depenses_DAL depense;
            if (reader.Read())
            {
                depense = new Depenses_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetFloat(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Depenses");
            }

            dbClose();

            return depense;
        }
        #endregion

        #region Insert
        public override Depenses_DAL Insert(Depenses_DAL depense)
        {
            dbConnect();

            commande.CommandText = "INSERT INTO Depenses(id_personne, id_projet, montant, created_at, updated_at)" + " values (@ID_Personne, @ID_Projet, @Montant, @Created_At, @Updated_At); SELECT SCOPE IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_Personne", depense.ID_Personne));
            commande.Parameters.Add(new SqlParameter("@ID_Projet", depense.ID_Projet));
            commande.Parameters.Add(new SqlParameter("@Montant", depense.Montant));
            commande.Parameters.Add(new SqlParameter("@Created_At", depense.Created_At));
            commande.Parameters.Add(new SqlParameter("@Updated_At", depense.Updated_At));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            depense.ID = ID;

            dbClose();

            return depense;
        }
        #endregion

        #region Update
        public override Depenses_DAL Update(Depenses_DAL depense)
        {
            dbConnect();

            commande.CommandText = "UPDATE Depenses SET id_personne = @ID_Personne, id_projet = @ID_Projet, montant=@Montant, created_at = @Created_At, update_at = @Updated_At WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID_Personne", depense.ID_Personne));
            commande.Parameters.Add(new SqlParameter("@ID_Projet", depense.ID_Projet));
            commande.Parameters.Add(new SqlParameter("@Montant", depense.Montant));
            commande.Parameters.Add(new SqlParameter("@Created_At", depense.Created_At));
            commande.Parameters.Add(new SqlParameter("@Updated_At", depense.Updated_At));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'ID de la table Depenses d'ID = {depense.ID}");
            }


            dbClose();

            return depense;
        }
        #endregion

        #region Delete
        public override void Delete(Depenses_DAL depense)
        {
            dbConnect();

            commande.CommandText = "DELETE FROM Depenses WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", depense.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer l'ID de la table Depenses d'ID = {depense.ID}");
            }

            dbClose();
        }
        #endregion
    }
}
