using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DO
{
    public class XuatKho
    {

        private string id;
        private string id_hdn;
        private string id_kho;
        private string id_luutru;
        private string id_ticket_hospital;
        private string id_xuatkho_log;
        private DateTime create_date;
        private string create_by;
        private string update_by;
        private DateTime update_date;
        private int thoigiang_xuattam;
        private DateTime thoigian_tra_dukien;
        private string nguoitiepnhan;
        private DateTime thoigian_tra_thucte;
        private int flag;
        private string soct;
        private string description;
        public XuatKho()
        {

        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string IdHdn
        {
            get { return id_hdn; }
            set { id_hdn = value; }
        }

        public string IdKho
        {
            get { return id_kho; }
            set { id_kho = value; }
        }

        public string IdLuutru
        {
            get { return id_luutru; }
            set { id_luutru = value; }
        }

        public string IdTicketHospital
        {
            get { return id_ticket_hospital; }
            set { id_ticket_hospital = value; }
        }

        public string IdXuatkhoLog
        {
            get { return id_xuatkho_log; }
            set { id_xuatkho_log = value; }
        }

        public DateTime CreateDate
        {
            get { return create_date; }
            set { create_date = value; }
        }

        public string CreateBy
        {
            get { return create_by; }
            set { create_by = value; }
        }

        public string UpdateBy
        {
            get { return update_by; }
            set { update_by = value; }
        }

        public DateTime UpdateDate
        {
            get { return update_date; }
            set { update_date = value; }
        }

        public int ThoigiangXuattam
        {
            get { return thoigiang_xuattam; }
            set { thoigiang_xuattam = value; }
        }

        public DateTime ThoigianTraDukien
        {
            get { return thoigian_tra_dukien; }
            set { thoigian_tra_dukien = value; }
        }

        public string Nguoitiepnhan
        {
            get { return nguoitiepnhan; }
            set { nguoitiepnhan = value; }
        }

        public DateTime ThoigianTraThucte
        {
            get { return thoigian_tra_thucte; }
            set { thoigian_tra_thucte = value; }
        }

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public string Soct
        {
            get { return soct; }
            set { soct = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
