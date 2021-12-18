using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Remboursement_DAL
    {
        public int ID { get; set; }
        public int ID_Personne { get; set; }
        public int ID_Projet { get; set; }
        public double Dette { get; set; }

        public Remboursement_DAL(int id_personne, int id_projet, double dette) => (ID_Personne, ID_Projet, Dette) = (id_personne, id_projet, dette);
        public Remboursement_DAL(int id, int id_personne, int id_projet, double dette) => (ID, ID_Personne, ID_Projet, Dette) = (id, id_personne, id_projet, dette);
    }
}
