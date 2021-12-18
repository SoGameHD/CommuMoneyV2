using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuMoney.DAL.DAL
{
    public class Personnes_DAL
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Personnes_DAL(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personnes_DAL(int id, string nom, string prenom) => (ID, Nom, Prenom) = (id, nom, prenom);
    }
}
