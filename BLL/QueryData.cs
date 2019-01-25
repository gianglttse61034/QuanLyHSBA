using BLL.DO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QueryData
    {
        private string tableNhapKho = "NHAP_KHO";
        private string tableMasterData = "MASTER_DATA";
        private static QueryData _instance = null;
        public QueryData() { }
        public static QueryData getInstance()
        {
            try
            {
                if (_instance == null)
                {
                    _instance = new QueryData();
                }
            }
            catch
            {

            }
            return _instance;
        }
        #region Xuat kho
        public bool InsertXuatKho(NhapKho obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKho,
                     "name", SqlDbType.NVarChar, obj.Name,
                     "birth_day", SqlDbType.NVarChar, obj.Birthday,
                     "description", SqlDbType.NVarChar, obj.Description,
                     "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital,
                     "id_luu_tru", SqlDbType.NVarChar, obj.Luutru,
                     "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                     "create_date", SqlDbType.DateTime, obj.Createdate,
                     "create_by", SqlDbType.NVarChar, obj.Createby,
                     "is_used", SqlDbType.Int, 1
                     );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateXuatKho(NhapKho obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKho,
                       "id", SqlDbType.NVarChar, obj.Id,
                       "name", SqlDbType.NVarChar, obj.Name,
                       "birth_day", SqlDbType.NVarChar, obj.Birthday,
                        "description", SqlDbType.NVarChar, obj.Description,
                       "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital,
                       "id_luu_tru", SqlDbType.NVarChar, obj.Luutru,
                       "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                       "update_date", SqlDbType.DateTime, obj.Updatedate,
                       "update_by", SqlDbType.NVarChar, obj.Updateby,
                       "is_used", SqlDbType.Int, 1
                   );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteXuatKho(NhapKho obj)
        {
            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                    "id", SqlDbType.NVarChar, obj.Id,
                    "is_used", SqlDbType.Int, 0
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public DataTable getXuatKho()
        {

            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name from {tableNhapKho} t left join MASTER_DATA d on d.id = t.id_kho where t.is_used = 1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion

        #region Nhập kho
        public bool InsertNhapKho(NhapKho obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKho,
                     "name", SqlDbType.NVarChar, obj.Name,
                     "birth_day", SqlDbType.NVarChar, obj.Birthday,
                     "description", SqlDbType.NVarChar, obj.Description,
                     "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital,
                     "id_luu_tru", SqlDbType.NVarChar, obj.Luutru,
                     "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                     "create_date", SqlDbType.DateTime, obj.Createdate,
                     "create_by", SqlDbType.NVarChar, obj.Createby,
                     "is_used", SqlDbType.Int, 1
                     );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhapKho(NhapKho obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKho,
                       "id", SqlDbType.NVarChar, obj.Id,
                       "name", SqlDbType.NVarChar, obj.Name,
                       "birth_day", SqlDbType.NVarChar, obj.Birthday,
                        "description", SqlDbType.NVarChar, obj.Description,
                       "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital,
                       "id_luu_tru", SqlDbType.NVarChar, obj.Luutru,
                       "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                       "update_date", SqlDbType.DateTime, obj.Updatedate,
                       "update_by", SqlDbType.NVarChar, obj.Updateby,
                       "is_used", SqlDbType.Int, 1
                   );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteNhapKho(NhapKho obj)
        {
            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                    "id", SqlDbType.NVarChar, obj.Id,
                    "is_used", SqlDbType.Int, 0
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public DataTable getNhapKho()
        {
            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name from {tableNhapKho} t left join MASTER_DATA d on d.id = t.id_kho where t.is_used = 1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion
        //Lưu log

        #region Danh mục
        public DataTable getListViTriLuuKho()
        {

            try
            {
                string sql =
                @"Select ct2.id,ct.id as parent_id,ct2.master_data_name,ct2.description,ct2.freefield2,ct2.freefield3,ct.master_data_name as master_data_name_parent,ct2.freefield1 from
                MASTER_DATA ct
                inner join
                MASTER_DATA ct2 on ct2.parent_id = ct.id where ct.group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and ct2.group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and ct.is_used = 1 and ct2.is_used = 1
                union all
                select id,null, master_data_name,description,freefield2,freefield3,null,freefield1 from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and parent_id is null and is_used = 1
                order by ct2.freefield1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;

            }
            catch (Exception)
            {

            }
            return null;
        }

        public DataTable getListKho(bool tf = false)
        {
            try
            {
                string sql = string.Empty;
                if (tf)
                    sql = @"Select convert(nvarchar(50),id) as master_data_id, freefield2 as master_data_name, freefield1  from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and id <> 'f60a6394-72fe-4541-b77e-3ae68058d1e0' and is_used = 1 order by freefield1";
                else
                {
                    sql = @"Select convert(nvarchar(50),id) as master_data_id, freefield2 as master_data_name, freefield1  from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c'  and is_used = 1 order by freefield1";
                }
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;

            }
            catch (Exception)
            {

            }
            return null;
        }
        public bool InsertDanhMuc(MasterData obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableMasterData,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "master_data_id", SqlDbType.NVarChar, obj.MasterDataId,
                    "master_data_name", SqlDbType.NVarChar, obj.MasterDataName,
                    "description", SqlDbType.NVarChar, obj.Description,
                    "freefield1", SqlDbType.NVarChar, obj.Freefield1,
                    "freefield2", SqlDbType.NVarChar, obj.Freefield2,
                    "freefield3", SqlDbType.NVarChar, obj.Freefield3,
                    "group_id", SqlDbType.NVarChar, obj.GroupId,
                    "parent_id", SqlDbType.NVarChar, obj.ParentId.ToLower(),
                    "create_date", SqlDbType.DateTime, obj.CreateDate,
                    "create_by", SqlDbType.NVarChar, obj.CreateBy,
                    //"update_date", SqlDbType.DateTime, obj.UpdateDate,
                    //"update_by", SqlDbType.NVarChar, obj.UpdateBy,
                    "is_used", SqlDbType.Int, obj.IsUsed
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdateDanhMuc(MasterData obj)
        {

            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableMasterData,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "master_data_id", SqlDbType.NVarChar, obj.MasterDataId,
                    "master_data_name", SqlDbType.NVarChar, obj.MasterDataName,
                    "description", SqlDbType.NVarChar, obj.Description,
                    "freefield1", SqlDbType.NVarChar, obj.Freefield1,
                    "freefield2", SqlDbType.NVarChar, obj.Freefield2,
                    "freefield3", SqlDbType.NVarChar, obj.Freefield3,
                    "group_id", SqlDbType.NVarChar, obj.GroupId,
                    "parent_id", SqlDbType.NVarChar, obj.ParentId,
                    "update_date", SqlDbType.DateTime, obj.UpdateDate,
                    "update_by", SqlDbType.NVarChar, obj.UpdateBy,
                    "is_used", SqlDbType.Int, obj.IsUsed
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Delete_DanhMuc(MasterData obj)
        {
            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableMasterData,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "update_date", SqlDbType.DateTime, obj.UpdateDate,
                    "update_by", SqlDbType.NVarChar, obj.UpdateBy,
                    "is_used", SqlDbType.Int, 0
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CheckDataDelete()
        {
            return true;
        }

        #endregion
    }
}
