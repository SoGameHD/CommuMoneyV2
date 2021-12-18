using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuMoney.DAL.DAL;
using CommuMoney.DAL.Depot;

namespace CommuMoney.DAL.Depot
{
    public class ProjetDepot_DAL : Depot_DAL<Projet_DAL>
    {
        #region GetAll
        public override List<Projet_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "SELECT id, nom, id_personne, total_montant, moyenne, date_soiree FROM Projet";
            var reader = commande.ExecuteReader();

            var listeDesProjets = new List<Projet_DAL>();
            while (reader.Read())
            {
                var projet = new Projet_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetInt32(2),
                                            reader.GetDouble(3),
                                            reader.GetDouble(4),
                                            reader.GetDateTime(5));
                listeDesProjets.Add(projet);
            }

            dbClose();
            return listeDesProjets;

        }
        #endregion

        #region GetByID
        public override Projet_DAL GetByID(int ID)
        {
            dbConnect();
            commande.CommandText = "SELECT id, nom, id_personne, total_montant, moyenne, date_soiree FROM Projet WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Projet_DAL proj;

            if (reader.Read())
            {
                proj = new Projet_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetInt32(2),
                                            reader.GetDouble(3),
                                            reader.GetDouble(4),
                                            reader.GetDateTime(5));
            }
            else
            {
                throw new Exception($"Pas de projet de disponible avec l'ID {ID}");
            }

            dbClose();
            return proj;
        }
        #endregion

        #region GetProjetByID_Personne
        public List<Projet_DAL> GetProjetByIDPersonne(int ID_Personne)
        {
            dbConnect();
            commande.CommandText = "SELECT id, nom, id_personne, total_montant, moyenne, date_soiree FROM Projet WHERE ID_Personne=@ID_Personne";
            commande.Parameters.Add(new SqlParameter("@ID_Personne", ID_Personne));
            var reader = commande.ExecuteReader();

            Projet_DAL proj;
            var listeDesProjetsAssocieALaPersonne = new List<Projet_DAL>();

            while (reader.Read())
            {
                proj = new Projet_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetInt32(2),
                                            reader.GetDouble(3),
                                            reader.GetDouble(4),
                                            reader.GetDateTime(5));
                listeDesProjetsAssocieALaPersonne.Add(proj);
            }
        

            dbClose();
            return listeDesProjetsAssocieALaPersonne;
        }
        #endregion

        #region Insert
        public override Projet_DAL Insert(Projet_DAL projet)
        {
            dbConnect();

            commande.CommandText = "INSERT INTO Projet(nom, id_personne, total_montant, moyenne, date_soiree) VALUES (@Nom, @ID_Personne, @Total_Montant, @Moyenne, @Date_Soiree); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Nom", projet.Nom));
            commande.Parameters.Add(new SqlParameter("@ID_Personne", projet.ID_Personne));
            commande.Parameters.Add(new SqlParameter("@Total_Montant", projet.Total_Montant));
            commande.Parameters.Add(new SqlParameter("@Moyenne", projet.Moyenne));
            commande.Parameters.Add(new SqlParameter("@Date_Soiree", projet.Date_Soiree));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            projet.ID = ID;

            dbClose();

            return projet;
        }
        #endregion

        #region Update
        public override Projet_DAL Update(Projet_DAL projet)
        {
            dbConnect();

            commande.CommandText = "UPDATE Projet SET nom = @Nom, id_personne = @ID_Personne, total_montant = @Total_Montant, moyenne = @Moyenne, date_soiree = @Date_Soiree WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Nom", projet.Nom));
            commande.Parameters.Add(new SqlParameter("@ID_Personne", projet.ID_Personne));
            commande.Parameters.Add(new SqlParameter("@Total_Montant", projet.Total_Montant));
            commande.Parameters.Add(new SqlParameter("@Moyenne", projet.Moyenne));
            commande.Parameters.Add(new SqlParameter("@Date_Soiree", projet.Date_Soiree));
            commande.Parameters.Add(new SqlParameter("@ID", projet.ID));
            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le projet avec l'ID {projet.ID}");
            }

            dbClose();
            return projet;
        }
        #endregion

        #region Delete
        public override void Delete(Projet_DAL projet)
        {
            dbConnect();

            commande.CommandText = "DELETE FROM Projet WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", projet.ID));
            var nbLigne = (int)commande.ExecuteNonQuery();

            if (nbLigne != 1)
            {
                throw new Exception($"Impossible de supprimer le projet d'ID {projet.ID}");
            }

            dbClose();
        }
        #endregion
    }
}
