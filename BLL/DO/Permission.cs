using System;
using System.Collections.Generic;
using System.Data;
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

        public Permission()
        {
            Id = "";
            UserId = "";
            PermissionName = "";
            AllowEdit = 0;
            AllowNew = 0;
            AllowPrint = 0;
            AllowExport = 0;
        }

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

    public class Resource
    {
        private string id;
        private string resource_id;
        private int priority;
        private int group_id;
        private int parent_id;
        private int is_used;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ResourceId
        {
            get { return resource_id; }
            set { resource_id = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public int GroupId
        {
            get { return group_id; }
            set { group_id = value; }
        }

        public int ParentId
        {
            get { return parent_id; }
            set { parent_id = value; }
        }

        public int IsUsed
        {
            get { return is_used; }
            set { is_used = value; }
        }
    }
}
