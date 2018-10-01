using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassLogin
    {
        private string _id;
        private string _user;
        public ClassLogin()
        {
            id = "";
            user = "";
        }
        public ClassLogin(string inId, string inUser)
        {
            id = inId;
            user = inUser;
        }
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
