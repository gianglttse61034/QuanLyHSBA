using BLL.DO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QueryData
    {
        public const string tableNhapKho = "NHAP_KHO";
        public const string tableNhapKhoLog = "NHAP_KHO_LOG";
        public const string tableXuatKho = "XUAT_KHO";
        public const string tableXuatKhoLog = "XUAT_KHO_LOG";
        public const string tableMasterData = "MASTER_DATA";
        public const string tableUser = "USERAPP";
        public const string tablePermission = "PERMISSION";
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
        public bool InsertXuatKho(XuatKho obj)
        {

            try
            {
                string idLog = Guid.NewGuid().ToString();
                string idXuatKho = Guid.NewGuid().ToString(); DAL.ConnectData.getInstance().InsertCommand(tableXuatKho,
                      "id", SqlDbType.UniqueIdentifier, new Guid(idXuatKho),
                      "id_hdn", SqlDbType.UniqueIdentifier, new Guid(obj.IdHdn),
                      "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.IdKho),
                      "id_ticket_hospital", SqlDbType.NVarChar, obj.IdTicketHospital,
                      "id_luutru", SqlDbType.NVarChar, obj.IdLuutru,
                      "id_xuatkho_log", SqlDbType.NVarChar, idLog,
                      "create_date", SqlDbType.DateTime, obj.CreateDate,
                      "create_by", SqlDbType.NVarChar, obj.CreateBy,
                      "thoigian_xuattam", SqlDbType.Int, obj.ThoigiangXuattam,
                      "thoigian_tra_dukien", SqlDbType.DateTime, obj.ThoigianTraDukien,
                      "nguoitiepnhan", SqlDbType.NVarChar, obj.Nguoitiepnhan,
                      "description", SqlDbType.NVarChar, obj.Description,
                      "soct", SqlDbType.NVarChar, obj.Soct,
                      "is_used", SqlDbType.Int, 1
                      );

                DAL.ConnectData.getInstance().InsertCommand(tableXuatKhoLog,
                    "id", SqlDbType.UniqueIdentifier, new Guid(idLog),
                    "id_xuat_kho", SqlDbType.UniqueIdentifier, new Guid(idXuatKho),
                    "create_date", SqlDbType.DateTime, obj.CreateDate,
                    "create_by", SqlDbType.NVarChar, obj.CreateBy,
                    "thoigian_xuattam", SqlDbType.Int, obj.ThoigiangXuattam,
                    "thoigian_tra_dukien", SqlDbType.DateTime, obj.ThoigianTraDukien,
                    "nguoitiepnhan", SqlDbType.NVarChar, obj.Nguoitiepnhan,
                    "description", SqlDbType.NVarChar, obj.Description
                );

                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.IdHdn),
                    "id_hdx", SqlDbType.NVarChar, idXuatKho,
                    "flag", SqlDbType.Int, 0
                );

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdateXuatKho(XuatKho obj)
        {

            try
            {
                string idLog = Guid.NewGuid().ToString();
                DAL.ConnectData.getInstance().UpdateCommand(tableXuatKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    //"id_hdn", SqlDbType.NVarChar, obj.IdHdn,
                    //"id_kho", SqlDbType.NVarChar, obj.IdKho,
                    //"id_ticket_hospital", SqlDbType.NVarChar, obj.IdTicketHospital,
                    //"id_luu_tru", SqlDbType.NVarChar, obj.IdLuutru,
                    "id_xuatkho_log", SqlDbType.NVarChar, idLog,
                    "update_date", SqlDbType.DateTime, obj.UpdateDate,
                    "update_by", SqlDbType.NVarChar, obj.UpdateBy,
                    "thoigian_xuattam", SqlDbType.Int, obj.ThoigiangXuattam,
                    "thoigian_tra_dukien", SqlDbType.DateTime, obj.ThoigianTraDukien,
                    "nguoitiepnhan", SqlDbType.NVarChar, obj.Nguoitiepnhan,
                    "description", SqlDbType.NVarChar, obj.Description,
                    "is_used", SqlDbType.Int, 1
                );


                DAL.ConnectData.getInstance().InsertCommand(tableXuatKhoLog,
                    "id", SqlDbType.UniqueIdentifier, new Guid(idLog),
                    "id_xuat_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "create_date", SqlDbType.DateTime, obj.CreateDate,
                    "create_by", SqlDbType.NVarChar, obj.CreateBy,
                    "thoigian_xuattam", SqlDbType.Int, obj.ThoigiangXuattam,
                    "thoigian_tra_dukien", SqlDbType.DateTime, obj.ThoigianTraDukien,
                    "nguoitiepnhan", SqlDbType.NVarChar, obj.Nguoitiepnhan,
                    "description", SqlDbType.NVarChar, obj.Description
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteXuatKho(XuatKho obj)
        {
            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableXuatKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "is_used", SqlDbType.Int, 0,
                    "update_date", SqlDbType.DateTime, obj.UpdateDate,
                    "update_by", SqlDbType.NVarChar, obj.UpdateBy
                );
                //Cập nhật thông tin bên HDN
                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.IdHdn),
                    "id_hdx", SqlDbType.NVarChar, DBNull.Value
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataTable getXuatKho()
        {

            try
            {
                string sql = $"Select hdx.*,d.freefield2 as kho_name,hdn_detail.soct soct_nhap, hdn.name, " +
                " case when isnull(hdn.soct,'') = '' " +
                " then N'Đã tái nhập kho:' + hdn_detail.soct " +
                " else N'Chưa tái nhập kho' end detail " +
                $" from {tableXuatKho} hdx" +
                $" left join {tableMasterData} d on d.id = hdx.id_kho and d.is_used = 1" +
                $" left join {tableNhapKho} hdn on hdn.id_hdx = hdx.id and hdn.is_used = 1" +
                $" left join {tableNhapKho} hdn_detail on hdn_detail.id = hdx.id_hdn and hdn_detail.is_used = 1" +
                "where hdx.is_used = 1  and d.is_used = 1 ";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public DataTable getDanhSachNhapKhoChuaXuat()
        {
            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name, t.soct + ' - '+ t.name as display_member from {tableNhapKho} t left join MASTER_DATA d on d.id = t.id_kho where (t.id_hdx is null or t.id_hdx = '') and t.is_used = 1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        #endregion

        #region Nhập kho
        public bool InsertNhapKho(NhapKho obj)
        {

            try
            {
                string id = Guid.NewGuid().ToString();
                string idLog = Guid.NewGuid().ToString();
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(id),
                    "name", SqlDbType.NVarChar, obj.Name,
                     "birth_day", SqlDbType.NVarChar, obj.Birthday,
                     "description", SqlDbType.NVarChar, obj.Description,
                     "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital.ToLower().Trim(),
                     "id_luu_tru", SqlDbType.NVarChar, obj.Luutru.ToLower().Trim(),
                     "stt", SqlDbType.NVarChar, obj.Stt,
                     "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                     "create_date", SqlDbType.DateTime, obj.Createdate,
                     "create_by", SqlDbType.NVarChar, obj.Createby,
                     "is_used", SqlDbType.Int, 1,
                     "id_hdx", SqlDbType.UniqueIdentifier, DBNull.Value,
                     "id_nhapkho_log", SqlDbType.UniqueIdentifier, new Guid(idLog),
                     "soct", SqlDbType.NVarChar, obj.Soct
                     );

                //Lưu log
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKhoLog,
                    "id", SqlDbType.UniqueIdentifier, new Guid(idLog),
                    "id_hdn", SqlDbType.UniqueIdentifier, new Guid(id),
                    "description", SqlDbType.NVarChar, obj.Description,
                    "create_date", SqlDbType.DateTime, obj.Createdate,
                    "create_by", SqlDbType.NVarChar, obj.Createby,
                    "id_hdx", SqlDbType.UniqueIdentifier, DBNull.Value,
                    "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                    "soct", SqlDbType.NVarChar, obj.Soct);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhapKho(NhapKho obj)
        {
            try
            {
                string idLog = Guid.NewGuid().ToString();
                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                       "id", SqlDbType.NVarChar, obj.Id,
                       "name", SqlDbType.NVarChar, obj.Name,
                       "birth_day", SqlDbType.NVarChar, obj.Birthday,
                       "stt", SqlDbType.NVarChar, obj.Stt,
                       "description", SqlDbType.NVarChar, obj.Description,
                       "id_ticket_hospital", SqlDbType.NVarChar, obj.Tickethospital.ToLower().Trim(),
                       "id_luu_tru", SqlDbType.NVarChar, obj.Luutru.ToLower().Trim(),
                       "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                       "update_date", SqlDbType.DateTime, obj.Updatedate,
                       "update_by", SqlDbType.NVarChar, obj.Updateby,
                       "id_nhapkho_log", SqlDbType.UniqueIdentifier, new Guid(idLog),
                       "is_used", SqlDbType.Int, 1);

                //Lưu log
                DAL.ConnectData.getInstance().InsertCommand(tableNhapKhoLog,
                    "id", SqlDbType.UniqueIdentifier, new Guid(idLog),
                    "id_hdn", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "description", SqlDbType.NVarChar, obj.Description,
                    "create_date", SqlDbType.DateTime, obj.Createdate,
                    "create_by", SqlDbType.NVarChar, obj.Createby,
                    "id_kho", SqlDbType.UniqueIdentifier, new Guid(obj.Kho),
                    "soct", SqlDbType.NVarChar, obj.Soct);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdateTaiNhapKho(NhapKho obj)
        {
            try
            {
                string idLog = Guid.NewGuid().ToString();
                DAL.ConnectData.getInstance().UpdateCommand(tableNhapKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "id_hdx", SqlDbType.UniqueIdentifier, DBNull.Value,
                    "flag", SqlDbType.Int, 1,
                    "update_date", SqlDbType.DateTime, obj.Updatedate,
                    "update_by", SqlDbType.NVarChar, obj.Updateby
                );

                //Bật cờ tái nhập kho trong phiếu xuất
                DAL.ConnectData.getInstance().UpdateCommand(tableXuatKho,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.IdHdx),
                    "id_xuatkho_log", SqlDbType.UniqueIdentifier, new Guid(idLog), // cập nhật lại file log
                    "flag", SqlDbType.Int, 1, // 1 đã tái nhập kho
                    "update_date", SqlDbType.DateTime, obj.Updatedate,
                    "update_by", SqlDbType.NVarChar, obj.Updateby,
                    "thoigian_tra_thucte", SqlDbType.DateTime, DateTime.Now
                );

                //Lưu log
                DAL.ConnectData.getInstance().InsertCommand(tableXuatKhoLog,
                    "id", SqlDbType.UniqueIdentifier, new Guid(idLog),
                    "id_xuat_kho", SqlDbType.UniqueIdentifier, new Guid(obj.IdHdx),
                    "create_date", SqlDbType.DateTime, DateTime.Now,
                    "create_by", SqlDbType.NVarChar, obj.Createby,
                    "thoigian_xuattam", SqlDbType.Int, 0, "thoigian_tra_dukien", SqlDbType.DateTime, DateTime.Now,
                    "nguoitiepnhan", SqlDbType.NVarChar, "",
                    "flag", SqlDbType.NVarChar, 1,
                    "thoigian_tra_thucte", SqlDbType.DateTime, DateTime.Now,
                    "description", SqlDbType.NVarChar, DateTime.Now, $"[NhapKho-Tai]-{obj.Description}"
                );
            }
            catch (Exception ex)
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
                    "is_used", SqlDbType.Int, 0,
                    "update_date", SqlDbType.DateTime, obj.Updatedate,
                    "update_by", SqlDbType.NVarChar, obj.Updateby
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
                string sql = $"Select t.*,d.freefield2 as kho_name, hdx.soct as soct_xuat from {tableNhapKho} t " +
                             $"left join MASTER_DATA d on d.id = t.id_kho and d.is_used = 1 " +
                             $"left join {tableXuatKho} hdx on hdx.id = t.id_hdx and hdx.is_used = 1" +
                             $"where t.is_used = 1 and d.is_used = 1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        private static string getMaxId(string refix, string column, string table)
        {
            string maxID = string.Empty;
            string sql = string.Format($"select max({column}) from {table} where {column} like '{refix}.[0-9]%'");
            DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                maxID = dt.Rows[0][0].ToString();
            }
            return maxID;
        }
        public static string autoCreatedHandleId(string refix, string column, string table)
        {
            try
            {
                string sMax = getMaxId(refix, column, table);
                string sOut = CreateId(sMax, 4, refix);
                return sOut;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string CreateId(string sInputMax, int iLenght, string sPrefix)
        {
            if (sInputMax == null || (sInputMax != null && sInputMax == ""))
            {
                sInputMax = "0";
            }
            else
            {
                string[] list = sInputMax.Split('.');
                if (list.Length > 0)
                {
                    sInputMax = list[list.Length - 1];
                }
                else
                {
                    sInputMax = "0";
                }
            }
            try
            {
                string sOut = "";
                int iCurId = int.Parse(sInputMax);
                if (iCurId <= 0)
                    iCurId = 1;
                else
                    iCurId = iCurId + 1;
                sOut = iCurId.ToString();
                int iMustLenght = iLenght - sOut.Length;
                for (int i = 0; i < iMustLenght; i++)
                {
                    sOut = "0" + sOut;
                }
                return sPrefix + "." + sOut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        //Lưu log
        #region Danh mục
        public DataTable getListViTriLuuKho()
        {

            try
            {
                string sql =
                @"Select ct2.id,ct.id as parent_id,ct2.master_data_name,ct2.description,ct2.master_data_id,ct2.freefield2,ct2.freefield3,ct2.freefield4 ,ct2.freefield5,ct2.freefield6,ct.master_data_name as master_data_name_parent,ct2.freefield1 from
                MASTER_DATA ct
                inner join
                MASTER_DATA ct2 on ct2.parent_id = convert(nvarchar(50),ct.id) where ct.group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and ct2.group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and ct.is_used = 1 and ct2.is_used = 1
                union all
                select id,null, master_data_name,description,master_data_id,freefield2,freefield3,freefield4,freefield5,freefield6,null,freefield1 from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and (parent_id is null or parent_id = '') and is_used = 1
                order by ct2.freefield1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;

            }
            catch (Exception)
            {

            }
            return null;
        }
        //Lấy danh sách tái nhập kho
        public DataTable getNhapKho_TaiNhap()
        {
            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name from {tableNhapKho} t left join MASTER_DATA d on d.id = t.id_kho where (id_hdx is null or id_hdx ='')  and t.is_used = 1";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
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
                    sql = @"Select convert(nvarchar(50),id) as master_data_id, freefield2 as master_data_name, freefield1,master_data_id as kihieu,freefield4 as min ,freefield5 as max,freefield6 as year from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c' and id <> 'f60a6394-72fe-4541-b77e-3ae68058d1e0' and is_used = 1 order by freefield1";
                else
                {
                    sql = @"Select convert(nvarchar(50),id) as master_data_id, freefield2 as master_data_name, freefield1,master_data_id as kihieu,freefield4 as min ,freefield5 as max,freefield6 as year   from MASTER_DATA where group_id = '74c788c0-9c2f-44fc-9e1f-108f60a1909c'  and is_used = 1 order by freefield1";
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
                object objMin = obj.Freefield4;
                object objMax = obj.Freefield5;
                object objYear = obj.Freefield6;
                DAL.ConnectData.getInstance().InsertCommand(tableMasterData,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "master_data_id", SqlDbType.NVarChar, obj.MasterDataId,
                    "master_data_name", SqlDbType.NVarChar, obj.MasterDataName,
                    "description", SqlDbType.NVarChar, obj.Description,
                    "freefield1", SqlDbType.NVarChar, obj.Freefield1,
                    "freefield2", SqlDbType.NVarChar, obj.Freefield2,
                    "freefield3", SqlDbType.NVarChar, obj.Freefield3,
                    "freefield4", SqlDbType.Int, objMin == null ? DBNull.Value : objMin,
                    "freefield5", SqlDbType.Int, objMax == null ? DBNull.Value : objMax,
                    "freefield6", SqlDbType.Int, objYear == null ? DBNull.Value : objYear, "group_id", SqlDbType.NVarChar, obj.GroupId,
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
                    "freefield4", SqlDbType.NVarChar, obj.Freefield4,
                    "freefield5", SqlDbType.NVarChar, obj.Freefield5,
                    "freefield6", SqlDbType.NVarChar, obj.Freefield6,
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

        public bool CheckSoNhapVien(string str)
        {
            bool tf = false;
            string sql = $"Select id_ticket_hospital from NHAP_KHO where id_ticket_hospital = '{str.ToLower().Trim()}'";
            DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
            if (dt != null && dt.Rows.Count == 0)
            {
                tf = true;
            }

            return tf;
        }

        #endregion

        #region Report
        public DataTable getReportNhapKho(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name from {tableNhapKho} t " +
                             $"left join MASTER_DATA d on d.id = t.id_kho and d.is_used = 1 " +
                             $"where t.is_used = 1 and d.is_used = 1";
                if (!fromDate.Equals(DateTime.MinValue))
                {
                    sql += $"and t.create_date >= '{fromDate.ToString("yyyy-MM-dd")}'";
                }

                if (!fromDate.Equals(DateTime.MinValue))
                {
                    sql += $"and t.create_date <='{toDate.ToString("yyyy-MM-dd")}' ";
                }
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public DataTable getReportXuatKho(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = $"Select t.*,d.freefield2 as kho_name from {tableXuatKho} t " +
                             $"left join MASTER_DATA d on d.id = t.id_kho and d.is_used = 1 " +
                             $"where t.is_used = 1 and d.is_used = 1";
                if (!fromDate.Equals(DateTime.MinValue))
                {
                    sql += $"and t.create_date >= '{fromDate.ToString("yyyy-MM-dd")}'";
                }

                if (!fromDate.Equals(DateTime.MinValue))
                {
                    sql += $"and t.create_date <= '{toDate.ToString("yyyy-MM-dd")}' ";
                }
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
            }
            return null;
        }
        public DataSet getReportLichSuHoSoBenhAn(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = "proc_HSBA_ReportLichSuHoSoBenhAn";
                DataSet ds = DAL.ConnectData.getInstance().ExecuteToDataSet(sql, CommandType.StoredProcedure,
                    "@fromDate", SqlDbType.VarChar, fromDate.ToString("yyyy-MM-dd"),
                    "@toDate", SqlDbType.VarChar, toDate.ToString("yyyy-MM-dd"));
                ds.Tables[0].TableName = "g";
                ds.Tables[1].TableName = "ct";

                //Relationship
                DataColumn[] parentColumns = { ds.Tables["g"].Columns["ID"] };
                DataColumn[] childColumns = { ds.Tables["ct"].Columns["ID_HDN"] };
                ds.Relations.Add("R_ct", parentColumns, childColumns);
                return ds;
            }
            catch (Exception)
            {
            }
            return null;
        }
        #endregion

        #region Permission
        public bool InsertUser(User obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tableUser,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "UserId", SqlDbType.NVarChar, obj.UserId,
                    "Pass", SqlDbType.NVarChar, obj.Pass,
                    "Name", SqlDbType.NVarChar, obj.Name,
                    "Address", SqlDbType.NVarChar, obj.Address,
                    "BirthDay", SqlDbType.NVarChar, obj.BirthDay,
                    "IdEmployer", SqlDbType.NVarChar, obj.IdEmployer,
                    "IsUsed", SqlDbType.Int, obj.IsUsed
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdateUser(User obj)
        {

            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableUser,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "UserId", SqlDbType.NVarChar, obj.UserId,
                    "Pass", SqlDbType.NVarChar, obj.Pass,
                    "Name", SqlDbType.NVarChar, obj.Name,
                    "Address", SqlDbType.NVarChar, obj.Address,
                    "BirthDay", SqlDbType.NVarChar, obj.BirthDay,
                    "IdEmployer", SqlDbType.NVarChar, obj.IdEmployer,
                    "IsUsed", SqlDbType.Int, obj.IsUsed
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DeleteUser(User obj)
        {
            try
            {
                DAL.ConnectData.getInstance().UpdateCommand(tableUser,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "is_used", SqlDbType.Int, 0
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool InsertPermission(Permission obj)
        {

            try
            {
                DAL.ConnectData.getInstance().InsertCommand(tablePermission,
                    "id", SqlDbType.UniqueIdentifier, new Guid(obj.Id),
                    "UserId", SqlDbType.NVarChar, obj.UserId,
                    "PermissionName", SqlDbType.NVarChar, obj.PermissionName,
                    "AllowEdit", SqlDbType.Int, obj.AllowEdit,
                    "AllowNew", SqlDbType.Int, obj.AllowNew,
                    "AllowPrint", SqlDbType.Int, obj.AllowPrint,
                    "AllowExport", SqlDbType.Int, obj.AllowExport

                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DeletePermission(string UserName)
        {

            try
            {
                string sql = $"Delete {tablePermission} where UserId = '{UserName}'";
               int kq = DAL.ConnectData.getInstance().ExecuteNonQuery(sql, CommandType.Text);
                if (kq == 1)
                {
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
            return false;
        }
        public DataTable getPermissionUser(string userName)
        {
            try
            {
                string sql = $"Select * from Permission where userId = '{userName}'";
                DataTable dt = DAL.ConnectData.getInstance().ExecuteToDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getUserManager()
        {
            try
            {
                string sql = $"proc_HSBA_User";
                DataSet ds = DAL.ConnectData.getInstance().ExecuteToDataSet(sql, CommandType.StoredProcedure);
                if (ds != null)
                {
                    ds.Tables[1].Columns.Add("AllowEdit_bool",typeof(bool));
                    ds.Tables[1].Columns.Add("AllowNew_bool", typeof(bool));
                    ds.Tables[1].Columns.Add("AllowPrint_bool", typeof(bool));
                    ds.Tables[1].Columns.Add("AllowExport_bool", typeof(bool));
                }

                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[1].Rows[i];
                    row["AllowEdit_bool"] = Convert.ToBoolean(row["AllowEdit"]);
                    row["AllowNew_bool"] = Convert.ToBoolean(row["AllowNew"]);
                    row["AllowPrint_bool"] = Convert.ToBoolean(row["AllowPrint"]);
                    row["AllowExport_bool"] = Convert.ToBoolean(row["AllowExport"]);
                }
                ds.Tables[0].TableName = "g";
                ds.Tables[1].TableName = "ct";
                DataColumn[] parentColumns = { ds.Tables["g"].Columns["UserId"] };
                DataColumn[] childColumns = { ds.Tables["ct"].Columns["UserId"] };
                ds.Relations.Add("R_ct", parentColumns, childColumns);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
    public static class DataAccount
    {
        public static BLL.DO.User user;
        public static User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
