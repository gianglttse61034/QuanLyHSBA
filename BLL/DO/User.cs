using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DO
{
    public class User
    {
        private string id;
        private string userId;
        private string pass;
        private string name;
        private string address;
        private string birthDay;
        private string idEmployer;
        private int isUsed;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public string IdEmployer
        {
            get { return idEmployer; }
            set { idEmployer = value; }
        }

        public int IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }
    }
}
