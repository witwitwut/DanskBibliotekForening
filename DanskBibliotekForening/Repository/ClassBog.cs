using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassBog
    {
        public ClassBog()
        {

        }
        public ClassBog(int inId, string inIsbnNr, string inTitel, string inForfatter, string inForlag, string inGenre, string inType, decimal inPris)
        {
            id = inId;
            isbnNr = inIsbnNr;
            titel = inTitel;
            forfatter = inForfatter;
            forlag = inForlag;
            genre = inGenre;
            type = inType;
            pris = inPris;
        }
        private int _id;
        private string _isbnNr;
        private string _titel;
        private string _forfatter;
        private string _forlag;
        private string _genre;
        private string _type;
        private decimal _pris;

        public int id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string isbnNr
        {
            get { return _isbnNr; }
            set { _isbnNr = value; }
        }
        public string titel
        {
            get { return _titel; }
            set { _titel = value; }
        }
        public string forfatter
        {
            get { return _forfatter; }
            set { _forfatter = value; }
        }
        public string forlag
        {
            get { return _forlag; }
            set { _forlag = value; }
        }
        public string genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public decimal pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

    }
}
