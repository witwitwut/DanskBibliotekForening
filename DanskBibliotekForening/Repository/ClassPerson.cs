using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassPerson
    {
        private int _id;
        private string _navn;
        private string _adresse;
        private string _telefon;
        private string _mail;
        private int _rolle;
        public ClassPerson()
        {
            id = 0;
            navn = "";
            adresse = "";
            telefon = "";
            mail = "";
            rolle = 0;
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string navn
        {
            get { return _navn; }
            set { _navn = value; }
        }
        public string adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public string telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public int rolle
        {
            get { return _rolle; }
            set { _rolle = value; }
        }
    }
}
