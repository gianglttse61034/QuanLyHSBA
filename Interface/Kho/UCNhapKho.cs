﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL.DO;
using BLL;
using Lib;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace Interface.UserControl.Kho
{
    public partial class UCNhapKho : DevExpress.XtraEditors.XtraUserControl
    {
        private ActionStatus currentActionStatus;
        public enum ActionStatus
        {
            Normal = 0,
            AddNew = 1,
            Update = 2
        }

        private NhapKho obj;
        public UCNhapKho()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            ChangeControlStatus(ActionStatus.Normal);
            LoadLayout();
        }
        public void ShownData()
        {
            RefeshData();
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
                gridView1.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("birth_day", "Ngày sinh", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_luu_tru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
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
                obj.Createby = row["create_by"] != null && !row["create_by"].Equals(DBNull.Value) ? row["create_by"].ToString() : "";
                obj.Createdate = row["create_date"] != null && !row["create_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["create_date"]) : DateTime.MinValue;
                obj.Updatedate = row["update_date"] != null && !row["update_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["update_date"]) : DateTime.MinValue;
                obj.Updateby = row["update_by"] != null && !row["update_by"].Equals(DBNull.Value) ? row["update_by"].ToString() : "";
                obj.Isused = Convert.ToInt16(row["is_used"]);
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
            }
            catch (Exception)
            {

            }


        }
        private void RefeshData()
        {
            DataTable dt = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getNhapKho(); };
            bw.RunWorkerCompleted += delegate
            {
                frmWait.Close();
                gridControl1.BeginUpdate();
                gridControl1.DataSource = null;
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                gridControl1.EndUpdate();

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
                    layoutDelete.Visibility = LayoutVisibility.Always;
                    layoutNew.Visibility = LayoutVisibility.Always;
                    layoutRefesh.Visibility = LayoutVisibility.Always;
                    layoutEdit.Visibility = LayoutVisibility.Always;

                    txtName.ReadOnly = true;
                    txtBirthDay.ReadOnly = true;
                    txtLuuTru.ReadOnly = true;
                    txtTicketHospital.ReadOnly = true;
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
                    break;
            }
        }

        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.AddNew);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Update);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Normal);
            if (MessageBox.Show("Bạn có muốn chắc chắn xóa hồ sơ này!", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)==DialogResult.Yes)
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
                if (row != null)
                {
                    SetDataRowToObject(row);
                    LoadDataToControl();
                }
            }
        }
        #endregion


    }
}
