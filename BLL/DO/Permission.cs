using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DO
{
    public class Permission
    {
        private string id;
        private string userId;
        private string permissionName;
        private int allowEdit;
        private int allowNew;
        private int allowPrint;
        private int allowExport;

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

        public string PermissionName
        {
            get { return permissionName; }
            set { permissionName = value; }
        }

        public int AllowEdit
        {
            get { return allowEdit; }
            set { allowEdit = value; }
        }

        public int AllowNew
        {
            get { return allowNew; }
            set { allowNew = value; }
        }

        public int AllowPrint
        {
            get { return allowPrint; }
            set { allowPrint = value; }
        }

        public int AllowExport
        {
            get { return allowExport; }
            set { allowExport = value; }
        }
    }
}
