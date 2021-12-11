using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL
{
    public class Remboursement_DAL
    {
        public int ID { get; set; }
        public int ID_PERSONNE { get; set; }
        public float ID_PROJET { get; set; }
        public float DETTE { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Created_at { get; set; }

        public Remboursement_DAL(int id, int id_personne, int id_projet, float dette, DateTime? created_at)
        {
            ID = id;
            ID_PERSONNE = id_personne;
            ID_PROJET = id_projet;
            DETTE = dette;
            Created_at = created_at;

        }

    }
}
