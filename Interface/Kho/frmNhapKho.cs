﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using BLL.DO;
using DevExpress.XtraLayout.Utils;
using Lib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace Interface
{
    public partial class frmNhapKho : DevExpress.XtraEditors.XtraForm
    {
        private ActionStatus currentActionStatus;
        private NhapKho obj;
        private DataTable dtKHO;
        private int currentHandle;
        public enum ActionStatus
        {
            Normal = 0,
            AddNew = 1,
            Update = 2
        }
        public frmNhapKho()
        {
            InitializeComponent();
        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void frmNhapKho_Shown(object sender, EventArgs e)
        {
            ShownData();
        }
        public void LoadData()
        {
            LoadLayout();
            txtBirthDay.Properties.MaxLength = 4;
        }
        public void ShownData()
        {
            DataTable dt = new DataTable();
            dtKHO = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getNhapKho(); };
            bw.DoWork += delegate { dtKHO = BLL.QueryData.getInstance().getListKho(true); };
            bw.RunWorkerCompleted += delegate
            {
                frmWait.Close();

                searchLookUpEdit1.Properties.View.Columns.Clear();
                searchLookUpEdit1.Properties.View.Columns.Add((GridHelper.getInstance().Format("master_data_name", "Tên", GridHelper.GridHelperType.TextEdit, "", 0, 0)));
                searchLookUpEdit1.Properties.View.Columns.Add((GridHelper.getInstance().Format("freefield1", "STT", GridHelper.GridHelperType.TextEdit, "", 0, 0)));
                searchLookUpEdit1.Properties.View.BestFitColumns();
                searchLookUpEdit1.Properties.ShowClearButton = false;
                searchLookUpEdit1.Properties.NullText = "";
                searchLookUpEdit1.Properties.DisplayMember = "master_data_name";
                searchLookUpEdit1.Properties.ValueMember = "master_data_id";
                searchLookUpEdit1.Properties.DataSource = dtKHO;
                gridControl1.BeginUpdate();
                gridControl1.DataSource = null;
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                gridControl1.EndUpdate();

                ChangeControlStatus(ActionStatus.Normal);

            };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }
        private void LoadLayout()
        {
            if (gridView1.Columns.Count == 0)
            {
                gridView1.BeginUpdate();
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridView1.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
                gridView1.Appearance.Row.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridView1.Appearance.HeaderPanel.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.Columns.Clear();
                gridView1.Columns.Add(GridHelper.getInstance().Format("id", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridView1.Columns.Add(GridHelper.getInstance().Format("soct", "Số chứng từ", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("soct_xuat", "Số chứng từ Xuất", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("stt", "Số Kho", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("birth_day", "Ngày sinh", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_luu_tru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("create_date", "Ngày tạo", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("create_by", "Người tạo", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("update_date", "Ngày chỉnh sửa", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("update_by", "Người chỉnh sửa", GridHelper.GridHelperType.TextEdit));
                gridView1.BestFitColumns();
                gridView1.EndUpdate();
            }
        }
        private void SetDataRowToObject(DataRow row)
        {
            obj = new NhapKho();
            try
            {
                obj.Id = row["id"] != null && !row["id"].Equals(DBNull.Value) ? row["id"].ToString() : "";
                obj.Name = row["name"] != null && !row["name"].Equals(DBNull.Value) ? row["name"].ToString() : "";
                obj.Birthday = row["birth_day"] != null && !row["birth_day"].Equals(DBNull.Value) ? row["birth_day"].ToString() : "";
                obj.Tickethospital = row["id_ticket_hospital"] != null && !row["id_ticket_hospital"].Equals(DBNull.Value) ? row["id_ticket_hospital"].ToString() : "";
                obj.Luutru = row["id_luu_tru"] != null && !row["id_luu_tru"].Equals(DBNull.Value) ? row["id_luu_tru"].ToString() : "";
                obj.Kho = row["id_kho"] != null && !row["id_kho"].Equals(DBNull.Value) ? row["id_kho"].ToString() : "";
                obj.Stt = row["stt"] != null && !row["stt"].Equals(DBNull.Value) ? row["stt"].ToString() : "";
                obj.Soct = row["soct"] != null && !row["soct"].Equals(DBNull.Value) ? row["soct"].ToString() : "";
                obj.Description = row["description"] != null && !row["description"].Equals(DBNull.Value) ? row["description"].ToString() : "";
                obj.Createby = row["create_by"] != null && !row["create_by"].Equals(DBNull.Value) ? row["create_by"].ToString() : "";

                obj.Createdate = row["create_date"] != null && !row["create_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["create_date"]) : DateTime.MinValue;
                obj.Isused = Convert.ToInt16(row["is_used"]);
                obj.Updateby = row["update_by"] != null && !row["update_by"].Equals(DBNull.Value) ? row["update_by"].ToString() : "";
                obj.Updatedate = row["update_date"] != null && !row["update_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["update_date"]) : DateTime.MinValue;
            }
            catch (Exception)
            {

            }

        }
        private void SetDataFromControl()
        {
            try
            {
                obj.Name = txtName.Text;
                obj.Luutru = txtLuuTru.Text;
                obj.Tickethospital = txtTicketHospital.Text;
                obj.Birthday = txtBirthDay.Text;
                obj.Createby = DataAccount.User.UserId;
                obj.Createdate = DateTime.Now;
                obj.Isused = 1;
                obj.Updatedate = DateTime.Now;
                obj.Updateby = DataAccount.User.UserId;
                obj.Kho = searchLookUpEdit1.EditValue.ToString();
                obj.Description = txtGhiChu.Text;
                obj.Soct = txtSoCT.Text;
            }
            catch (Exception)
            {

            }
        }
        private void RefeshData()
        {
            DataTable dt = new DataTable();
            dtKHO = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getNhapKho(); };
            //bw.DoWork += delegate { dtKHO = BLL.QueryData.getInstance().getListKho(true); };
            bw.RunWorkerCompleted += delegate
            {
                frmWait.Close();
                gridControl1.BeginUpdate();
                gridControl1.DataSource = null;
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                gridControl1.EndUpdate();
                //searchLookUpEdit1.Properties.DataSource = dtKHO;
            };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }
        private void LoadDataToControl()
        {
            if (obj != null)
            {
                txtName.Text = obj.Name;
                txtLuuTru.Text = obj.Luutru;
                txtTicketHospital.Text = obj.Tickethospital;
                txtBirthDay.Text = obj.Birthday;
                searchLookUpEdit1.EditValue = obj.Kho.ToUpper();
                txtGhiChu.Text = obj.Description;
                txtSoCT.Text = obj.Soct;
            }
        }
        private void ChangeControlStatus(ActionStatus status)
        {
            currentActionStatus = status;
            switch (status)
            {
                case ActionStatus.Normal:
                    layoutCancle.Visibility = LayoutVisibility.Never;
                    layoutSave.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Always;
                    layoutRefesh.Visibility = LayoutVisibility.Always;
                    layoutEdit.Visibility = LayoutVisibility.Always;
                    if (gridView1.RowCount > 0)
                    {
                        layoutEdit.Visibility = LayoutVisibility.Always;
                        layoutDelete.Visibility = LayoutVisibility.Always;
                    }
                    else
                    {
                        layoutEdit.Visibility = LayoutVisibility.Never;
                        layoutDelete.Visibility = LayoutVisibility.Never;
                    }
                    txtName.ReadOnly = true;
                    txtBirthDay.ReadOnly = true;
                    txtLuuTru.ReadOnly = true;
                    txtTicketHospital.ReadOnly = true;
                    searchLookUpEdit1.ReadOnly = true;
                    txtSoCT.ReadOnly = true;
                    txtGhiChu.ReadOnly = true;
                    break;
                case ActionStatus.Update:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    txtName.ReadOnly = false;
                    txtBirthDay.ReadOnly = false;
                    txtLuuTru.ReadOnly = false;
                    txtTicketHospital.ReadOnly = false;
                    searchLookUpEdit1.ReadOnly = false;
                    txtSoCT.ReadOnly = true;
                    txtGhiChu.ReadOnly = false;
                    break;
                case ActionStatus.AddNew:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;

                    txtName.ReadOnly = false;
                    txtBirthDay.ReadOnly = false;
                    txtLuuTru.ReadOnly = false;
                    txtTicketHospital.ReadOnly = false;
                    searchLookUpEdit1.ReadOnly = false;
                    txtSoCT.ReadOnly = true;
                    txtGhiChu.ReadOnly = false;
                    break;
            }
        }

        private void getKhobySoVaoVien()
        {
            int number = 0;
            if (txtTicketHospital.Text == string.Empty)
                return;
            number = splitSoVaoVien(txtTicketHospital.Text);
            dtKHO.DefaultView.RowFilter = $"min is not null and max is not null and min < = {number} and max >= {number}";
            dtKHO.DefaultView.Sort = "min desc";
            DataTable dt = dtKHO.DefaultView.ToTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                searchLookUpEdit1.EditValue = dt.Rows[0]["master_data_id"];
            }
        }

        private int splitSoVaoVien(string str)
        {
            string returnStr = string.Empty;
            string[] lst = str.Split('/');
            if (lst != null && lst.Count() > 0)
            {
                try
                {
                    return Convert.ToInt32(lst[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng của số vào viện: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return -9999;
        }

        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.AddNew);
            clearControl();
            //Lấy số ct
            txtSoCT.Text = QueryData.autoCreatedHandleId("HDN." + DateTime.Now.ToString("yyMMdd"), "soct", QueryData.tableNhapKho);
        }

        private void clearControl()
        {
            txtBirthDay.Text = "";
            txtGhiChu.Text = "";
            txtName.Text = "";
            txtSoCT.Text = "";
            txtTicketHospital.Text = "";
            searchLookUpEdit1.EditValue = "";
            txtLuuTru.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Update);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Normal);
            if (MessageBox.Show("Bạn có muốn chắc chắn xóa hồ sơ này!", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (obj == null || obj.Id == string.Empty) return;
                //SetDataFromControl();
                if (BLL.QueryData.getInstance().DeleteNhapKho(obj))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                    if (gridView1.RowCount == 0)
                    {
                        obj = new NhapKho();
                        LoadDataToControl();
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.Normal) return;
            if (currentActionStatus == ActionStatus.Update)
            {
                if (obj == null || obj.Id == string.Empty) return;
                SetDataFromControl();
                if (BLL.QueryData.getInstance().UpdateNhapKho(obj))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (currentActionStatus == ActionStatus.AddNew)
            {
                obj = new NhapKho();
                SetDataFromControl();
                if (BLL.QueryData.getInstance().InsertNhapKho(obj))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Normal);
            if (gridView1.RowCount > 0)
            {
                try
                {
                    LoadDataToControl();
                }
                catch (Exception)
                {
                }
            }
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            RefeshData();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle != GridControl.AutoFilterRowHandle && e.FocusedRowHandle >= 0)
            {
                DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
                currentHandle = e.FocusedRowHandle;
                if (row != null)
                {
                    SetDataRowToObject(row);
                    LoadDataToControl();
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData ==(Keys.Control | Keys.S) && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnSave_Click(new object(), EventArgs.Empty);
            }
            if (keyData == (Keys.Control | Keys.E) && currentActionStatus == ActionStatus.Normal)
            {
                btnEdit_Click(new object(), EventArgs.Empty);
            }
            if (keyData == (Keys.Control |  Keys.N) && currentActionStatus == ActionStatus.Normal)
            {
                btnNew_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Escape && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnCancle_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.F5 && currentActionStatus == ActionStatus.Normal)
            {
                btnRefesh_Click(new object(), EventArgs.Empty);
            }
            if (keyData == (Keys.Control | Keys.Delete) && currentActionStatus == ActionStatus.Normal)
            {
                btnDelete_Click(new object(), EventArgs.Empty);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.AddNew && dtKHO.Columns.Contains("master_data_id"))
            {
                dtKHO.DefaultView.RowFilter = $"master_data_id = '{searchLookUpEdit1.EditValue.ToString().ToLower()}'";
                if (dtKHO.DefaultView.ToTable().Rows.Count > 0)
                {
                    DataRow row = dtKHO.DefaultView.ToTable().Rows[0];
                    txtSoLuuKho.Text = QueryData.autoCreatedHandleId(row != null && row["kihieu"] != null ? row["kihieu"].ToString() : "KHO", "stt", QueryData.tableNhapKho);
                }
                dtKHO.DefaultView.RowFilter = string.Empty;
            }
        }*/
        private void txtTicketHospital_EditValueChanged(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.AddNew)
                getKhobySoVaoVien();
        }

        #endregion

        private void txtTicketHospital_Validated(object sender, EventArgs e)
        {
            if (!QueryData.getInstance().CheckSoNhapVien(txtTicketHospital.Text))
            {
                MessageBox.Show("Số nhập viện là số duy nhất. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
        }
    }
}