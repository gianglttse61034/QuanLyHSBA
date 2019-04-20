using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DO
{
    public class MasterData
    {
        private string id;
        private string master_data_id;
        private string master_data_name;
        private string freefield1;
        private string freefield2;
        private string freefield3;
        private string freefield4;
        private string freefield5;
        private string freefield6;
        private DateTime create_date;
        private string create_by;
        private DateTime update_date;
        private string update_by;
        private int is_used;
        private string description;
        private string groupId;
        private string parentId;

        public MasterData()
        {
            master_data_id = "";
            master_data_name = "";
            freefield1 = "";
            freefield2 = "";
            freefield3 = "";
            create_date = DateTime.Now;
            create_by = "";
            update_by = "";
            update_date = DateTime.Now;
            is_used = 1;
            description = "";
            groupId = "";
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string MasterDataId
        {
            get { return master_data_id; }
            set { master_data_id = value; }
        }

        public string MasterDataName
        {
            get { return master_data_name; }
            set { master_data_name = value; }
        }

        public string Freefield1
        {
            get { return freefield1; }
            set { freefield1 = value; }
        }

        public string Freefield2
        {
            get { return freefield2; }
            set { freefield2 = value; }
        }

        public string Freefield3
        {
            get { return freefield3; }
            set { freefield3 = value; }
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

        public DateTime UpdateDate
        {
            get { return update_date; }
            set { update_date = value; }
        }

        public int IsUsed
        {
            get { return is_used; }
            set { is_used = value; }
        }

        public string UpdateBy
        {
            get { return update_by; }
            set { update_by = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string Freefield4
        {
            get { return freefield4; }
            set { freefield4 = value; }
        }

        public string Freefield5
        {
            get { return freefield5; }
            set { freefield5 = value; }
        }

        public string Freefield6
        {
            get { return freefield6; }
            set { freefield6 = value; }
        }
    }
}
