using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DO
{
    public class NhapKho
    {
        private string id;
        private string name;
        private string birthday;
        private string tickethospital;
        private string luutru;
        private DateTime createdate;
        private string createby;
        private DateTime updatedate;
        private string updateby;
        private string kho;
        private string description;
        private string stt;
        private string id_hdx;
        private string soct;
        private int flag;
        public NhapKho()
        {

        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Tickethospital
        {
            get { return tickethospital; }
            set { tickethospital = value; }
        }

        public DateTime Createdate
        {
            get { return createdate; }
            set { createdate = value; }
        }

        public string Luutru
        {
            get { return luutru; }
            set { luutru = value; }
        }

        public string Createby
        {
            get { return createby; }
            set { createby = value; }
        }

        public DateTime Updatedate
        {
            get { return updatedate; }
            set { updatedate = value; }
        }

        public string Updateby
        {
            get { return updateby; }
            set { updateby = value; }
        }

        public int Isused { get; set; }

        public string Kho
        {
            get { return kho; }
            set { kho = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Stt
        {
            get { return stt; }
            set { stt = value; }
        }

        public string IdHdx
        {
            get { return id_hdx; }
            set { id_hdx = value; }
        }

        public string Soct
        {
            get { return soct; }
            set { soct = value; }
        }

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
    }
}
