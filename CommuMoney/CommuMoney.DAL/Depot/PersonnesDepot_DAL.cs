using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;

namespace CommuMoney.DAL.Depot
{
    public class PersonnesDepot_DAL : Depot_DAL<Personnes_DAL>
    {
        #region GetAll
        public override List<Personnes_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "select nom, prenom, created_at, updated_at from Personnes";
            var reader = commande.ExecuteReader();

            var listePersonnes = new List<Personnes_DAL>();

            while (reader.Read())
            {
                var personne = new Personnes_DAL(reader.GetString(0),
                                        reader.GetString(1));
                listePersonnes.Add(personne);
            }

            dbClose();

            return listePersonnes;
        }
        #endregion

        #region GetByID
        public override Personnes_DAL GetByID(int ID)
        {
            dbConnect();

            commande.CommandText = "SELECT ID, nom, prenom, created_at, updated_at FROM Personnes WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Personnes_DAL personne;
            if (reader.Read())
            {
                personne = new Personnes_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Personnes");
            }

            dbClose();

            return personne;
        }
        #endregion

        #region Insert
        public override Personnes_DAL Insert(Personnes_DAL personne)
        {
            dbConnect();

            commande.CommandText = "INSERT INTO Personnes(nom, prenom) VALUES (@Nom, @Prenom); SELECT SCOPE IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Nom", personne.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", personne.Prenom));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            personne.ID = ID;

            dbClose();

            return personne;
        }
        #endregion

        #region Update
        public override Personnes_DAL Update(Personnes_DAL personne)
        {
            dbConnect();

            commande.CommandText = "UPDATE Personnes SET nom = @Nom, prenom = @Prenom WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Nom", personne.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", personne.Prenom));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'ID de la table Personnes d'ID = {personne.ID}");
            }


            dbClose();

            return personne;
        }
        #endregion

        #region Delete
        public override void Delete(Personnes_DAL personne)
        {
            dbConnect();

            commande.CommandText = "DELETE FROM Personnes WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", personne.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer l'ID de la table Personnes d'ID = {personne.ID}");
            }

            dbClose();
        }
        #endregion
    }
}
