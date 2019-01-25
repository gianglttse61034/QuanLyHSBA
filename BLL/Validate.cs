using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DO;
using DAL;

namespace BLL
{
    public class Validate
    {
        private static Validate _instance = null;
        public Validate() { }
        public static Validate getInstance()
        {
            try
            {
                if (_instance == null)
                {
                    _instance = new Validate();
                }
            }
            catch
            {

            }
            return _instance;
        }
        public DataTable GetPermission(string userName)
        {
            DataTable dt = new DataTable();
            string sql = "Select * from dbo.Permission where UserID = ";
            return dt;
        }
        public int ValidateUser(string userName, string passWord, ref User user)
        {
            int result = 0;
            try
            {
                string sql = $"Select Id,UserID, Pass, isUsed, Name from UserApp where UserId ='{userName}'";
                DataTable dt = ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                if (dt!=null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row != null && row["Pass"] != null && row["Pass"].ToString().Equals(passWord))
                    {
                        if (Convert.ToInt16(row["isUsed"]).Equals(1))
                        {
                            result = 1; // Đúng Pass nhưng còn hoạt động
                            user = new User();
                            user.Id = row["Id"].ToString();
                            user.Name = row["Name"].ToString();
                            user.UserId = row["UserID"].ToString();
                        }
                        else
                        {
                            result = 2;// Đúng pass không còn hoạt động
                        }
                        
                    }
                    else 
                    {
                        result = 3;//Sai pass
                    }
                }
                else
                {
                    result = 4; // Không có tài khoản này trong hệ thống
                }

            }
            catch (Exception )
            {
                result = -1;
            }

            return result;
        }
    }
}
