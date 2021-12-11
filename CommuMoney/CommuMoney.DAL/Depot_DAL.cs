﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL
{
    public abstract class Depot_DAL<Type_DAL> : IDepot_DAL<Type_DAL>

    {
        public string ChaineDeConnexion { get; set; }

        protected SqlConnection connexion;
        protected SqlCommand commande;

        #region Depot_DAL
        public Depot_DAL()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();

            ChaineDeConnexion = config.GetSection("ConnectionStrings:default").Value;
        }
        #endregion

        #region dbConnect
        protected void dbConnect()
        {
            connexion = new SqlConnection(ChaineDeConnexion);
            connexion.Open();
            commande = new SqlCommand();
            commande.Connection = connexion;
        }
        #endregion

        #region dbClose
        protected void dbClose()
        {
            commande.Dispose();
            connexion.Close();
            connexion.Dispose();
        }
        #endregion

        #region Méthodes abstraites

        public abstract void Delete(Type_DAL item);

        public abstract List<Type_DAL> GetAll();

        public abstract Type_DAL GetByID(int ID);

        public abstract Type_DAL Insert(Type_DAL item);

        public abstract Type_DAL Update(Type_DAL item);
        #endregion
    }


}
