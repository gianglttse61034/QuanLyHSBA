using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectData 
    {
        private static SqlConnection Conn;
        private static ConnectData _instance = null;
        private string strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        public ConnectData() { }
        public static ConnectData getInstance()
        {
            try
            {
                if (_instance == null)
                {
                    _instance = new ConnectData();
                }
            }
            catch
            {
            }
            return _instance;
        }

        private void Connect()
        {

            try
            {
                Conn = new SqlConnection(strConn);
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                else
                {
                    Conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public DataTable ExecuteToDataTable(string str, CommandType type_cmd, params object[] par)
        {
            DataSet ds = new DataSet();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(str, Conn);
                cmd.CommandType = type_cmd;
                for (int i = 0; i < par.Length; i = i + 3)
                {
                    string name = par[i].ToString();
                    SqlDbType type = (SqlDbType)par[i + 1];
                    object value = par[i + 2];
                    cmd.Parameters.Add(name, type);
                    cmd.Parameters[name].Value = value;
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                Conn.Close();
            }
            catch (Exception )
            {

            }
            return ds.Tables[0];

        }
        public DataSet ExecuteToDataSet(string str, CommandType type_cmd, params object[] par)
        {
            Connect();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(str, Conn);
            cmd.CommandType = type_cmd;
            for (int i = 0; i < par.Length; i = i + 3)
            {
                string name = par[i].ToString();
                SqlDbType type = (SqlDbType)par[i + 1];
                object value = par[i + 2];
                cmd.Parameters.Add(name, type);
                cmd.Parameters[name].Value = value;
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            Conn.Close();
            return ds;

        }
        public void InsertCommand(string tableName, params object[] arr)
        {
            Connect();
            //Thành lập chuỗi insert
            string sql_a = string.Format("Insert into {0} ( ", tableName);
            string str_sau = string.Empty;
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                #region string_ trước 
                string name_values = "@" + arr[i].ToString();
                string name = arr[i].ToString();
                if (i == arr.Length - 3)
                {
                    str_sau = str_sau + name_values;
                    sql_a = sql_a + name;
                }
                else
                {
                    sql_a = sql_a + name + ",";
                    str_sau = str_sau + name_values + ",";
                }
                #endregion
            }
            sql_a = sql_a + ") Values (" + str_sau + ")";

            SqlCommand cmd = new SqlCommand(sql_a, Conn);
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                string name = arr[i].ToString();
                SqlDbType type = (SqlDbType)arr[i + 1];
                object value = arr[i + 2];
                cmd.Parameters.Add(name, type);
                cmd.Parameters[name].Value = value;
            }
            try
            {
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        // khai báo key_key se để vị trí đầu
        public void UpdateCommand(string tableName, params object[] arr)
        {
            Connect();
            //Thành lập chuỗi insert
            string sql_a = string.Format("Update {0} set ", tableName);
            string key = string.Empty;
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                key = arr[0].ToString();
                string name = arr[i].ToString() + " = @" + arr[i].ToString();
                if (i == arr.Length - 3)
                {
                    sql_a = sql_a + name;
                }
                else
                    sql_a = sql_a + name + ",";
            }
            sql_a = sql_a + string.Format(" where {0}  = {1}", key, "@" + key);
            SqlCommand cmd = new SqlCommand(sql_a, Conn);
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                string name = arr[i].ToString();
                SqlDbType type = (SqlDbType)arr[i + 1];
                object value = arr[i + 2];
                cmd.Parameters.Add(name, type);
                cmd.Parameters[name].Value = value;
            }
            try
            {
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
