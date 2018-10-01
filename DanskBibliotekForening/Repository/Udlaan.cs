using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Udlaan
    {
        private DateTime afleveringsDato;

        public DateTime AfleveringsDato
        {
            get { return afleveringsDato; }
            set { afleveringsDato = value; }
        }

        public void BeregnAflereveringsDato(DateTime lenddate, string userStatus)
        {
            DateTime returnDate;
            switch (userStatus.ToLower())
            {
                case "administrator":
                    returnDate = lenddate.AddDays(120);
                    break;
                case "normallender":
                    returnDate = lenddate.AddDays(30);
                    break;
                case "superlender":
                    returnDate = lenddate.AddDays(60);
                    break;
                case "ansat":
                    returnDate = lenddate.AddDays(40);
                    break;
                default:
                    break;
            }
        }
    }
}
