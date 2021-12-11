using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL
{
    public class Projet_DAL
    {
        public int ID { get; set; }
        public string NOM{ get; set; }
        public int ID_PERSONNE { get; set; }
        public float TOTAL_MONTANT { get; set; }
        public float MOYENNE { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Created_at { get; set; }

        public Projet_DAL(int id, string nom,int id_personne,float total_montant, float moyenne, DateTime? created_at)
        {
            ID = id;
            NOM = nom;
            ID_PERSONNE = id_personne;
            TOTAL_MONTANT = total_montant;
            MOYENNE = moyenne;
            Created_at = created_at;

        }

    }
}
