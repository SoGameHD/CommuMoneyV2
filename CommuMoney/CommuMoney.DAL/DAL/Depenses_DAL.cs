using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Depenses_DAL
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public double Montant { get; set; }

        public Depenses_DAL(int id_personne, int id_projet, double montant) => (ID_Personne, ID_Projet, Montant) = (id_personne, id_projet, montant);
        public Depenses_DAL(int id, int id_personne, int id_projet, double montant) => (ID, ID_Personne, ID_Projet, Montant) = (id, id_personne, id_projet, montant);
    }
}
