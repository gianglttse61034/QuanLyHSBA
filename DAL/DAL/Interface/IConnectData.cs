using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConnectData
    {
        static DataTable ExecuteToDataTable(string str, CommandType type_cmd, params object[] par);
        static DataSet ExecuteToDataSet(string str, CommandType type_cmd, params object[] par);
        static void InsertCommand(string tableName, params object[] arr);
        static  void UpdateCommand(string tableName, params object[] arr);
    }
}
