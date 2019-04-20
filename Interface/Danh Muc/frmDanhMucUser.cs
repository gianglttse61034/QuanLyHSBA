using BLL.DO;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
    public partial class frmDanhMucUser : DevExpress.XtraEditors.XtraForm
    {
        private ActionStatus currentActionStatus;
        private User obj;
        private bool isChangeData = false;
        public enum ActionStatus
        {
            Normal = 0,
            AddNew = 1,
            Update = 2
        }
        public frmDanhMucUser()
        {
            InitializeComponent();
        }
        private void frmDanhMucUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void frmDanhMucUser_Shown(object sender, EventArgs e)
        {
            ShownData();
        }
        public void LoadData()
        {
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
                gridView1.Columns.Add(GridHelper.getInstance().Format("UserId", "Số chứng từ", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("Pass", "Kho", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridView1.Columns.Add(GridHelper.getInstance().Format("Name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("Address", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("Birthday", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("IdEmployer", "Ghi chú", GridHelper.GridHelperType.TextEdit));
                gridView1.BestFitColumns();
                gridView1.EndUpdate();
            }

            if (gridView2.Columns.Count == 0)
            {
                gridView2.BeginUpdate();
                gridView2.OptionsSelection.MultiSelect = true;
                gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridView2.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
                gridView2.Appearance.Row.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridView2.Appearance.HeaderPanel.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridView2.OptionsView.ColumnAutoWidth = false;
                gridView2.Columns.Clear();

                gridView2.Columns.Add(GridHelper.getInstance().Format("userid", "Số chứng từ", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridView2.Columns.Add(GridHelper.getInstance().Format("PermissionName", "Kho", GridHelper.GridHelperType.TextEdit));
                gridView2.Columns.Add(GridHelper.getInstance().Format("AllowNew_bool", "Thêm mới", GridHelper.GridHelperType.CheckEdit));
                gridView2.Columns.Add(GridHelper.getInstance().Format("AllowEdit_bool", "Sửa", GridHelper.GridHelperType.CheckEdit));
                gridView2.Columns.Add(GridHelper.getInstance().Format("AllowPrint_bool", "In", GridHelper.GridHelperType.CheckEdit));
                gridView2.Columns.Add(GridHelper.getInstance().Format("AllowExport_bool", "Xuất dữ liệu", GridHelper.GridHelperType.CheckEdit));
                gridView2.BestFitColumns();
                gridView2.EndUpdate();
            }

        }
        private User SetRowUserToObject(DataRow row)
        {

            if (row == null) return null;
            User temp = new User();
            try
            {
                temp.Id = row["id"] == null || row["id"].Equals(DBNull.Value) ? "" : row["id"].ToString(); // Id 
                temp.Address = row["Address"] == null || row["Address"].Equals(DBNull.Value) ? "" : row["Address"].ToString(); //Address 
                temp.Name = row["Name"] == null || row["Name"].Equals(DBNull.Value) ? "" : row["Name"].ToString(); // Name
                temp.BirthDay = row["BirthDay"] == null || row["BirthDay"].Equals(DBNull.Value) ? "" : row["BirthDay"].ToString(); //BirthDay
                temp.IdEmployer = row["IdEmployer"] == null || row["IdEmployer"].Equals(DBNull.Value) ? "" : row["IdEmployer"].ToString(); // IdEmployer
                temp.Pass = row["Pass"] == null || row["Pass"].Equals(DBNull.Value) ? "" : row["Pass"].ToString();// Pass
                temp.UserId = row["UserId"] == null || row["UserId"].Equals(DBNull.Value) ? "" : row["UserId"].ToString();//UserId
                temp.IsUsed = row["isUsed"] == null || row["isUsed"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(row["isUsed"]);//UserId
            }
            catch (Exception)
            {

                throw;
            }

            return temp;
        }
        private Permission SetRowPermissionToObject(DataRow row)
        {

            if (row == null) return null;Permission per = new Permission();
            try
            {
                per.Id = Guid.NewGuid().ToString().ToLower();
                per.UserId = txtUserId.Text;
                per.PermissionName = !row["PermissionName"].Equals(DBNull.Value) ? "" : row["PermissionName"].ToString();
                per.AllowEdit = !row["AllowEdit_bool"].Equals(DBNull.Value) && Convert.ToBoolean(row["AllowEdit_bool"]) == true ? 1 : 0;
                per.AllowExport = !row["AllowExport_bool"].Equals(DBNull.Value) && Convert.ToBoolean(row["AllowExport_bool"]) == true ? 1 : 0;
                per.AllowNew = !row["AllowNew_bool"].Equals(DBNull.Value) && Convert.ToBoolean(row["AllowNew_bool"]) == true ? 1 : 0;
                per.AllowPrint = !row["AllowPrint_bool"].Equals(DBNull.Value) && Convert.ToBoolean(row["AllowPrint_bool"]) == true ? 1 : 0;
            }
            catch (Exception)
            {
                throw;
            }

            return per;
        }
        private User SetDataFromControl()
        {
            User temp = new User();
            try
            {
                if (currentActionStatus == ActionStatus.AddNew){
                    temp.UserId = txtUserId.Text;
                    temp.Pass = Lib.CommonFuntion.EncodeMD5(txtPass.Text);
                    temp.Id = Guid.NewGuid().ToString().ToLower();
                    temp.BirthDay = txtYear.Text;
                    temp.IdEmployer = txtMaNhanVien.Text;
                    temp.Name = txtName.Text;
                    temp.Address = txtDiaChi.Text;temp.IsUsed = chkIsUsed.Checked ? 1 : 0;
                }

                if (currentActionStatus == ActionStatus.Update)
                {
                    temp.UserId = txtUserId.Text;
                    temp.Pass = Lib.CommonFuntion.EncodeMD5(txtPass.Text);
                    temp.BirthDay = txtYear.Text;
                    temp.IdEmployer = txtMaNhanVien.Text;
                    temp.Name = txtName.Text;
                    temp.Address = txtDiaChi.Text;
                    temp.Id = obj.Id.ToLower();
                    temp.IsUsed = chkIsUsed.Checked ? 1 : 0;
                }
            }
            catch (Exception e)
            {
            }
            return temp;
        }
        private void RefeshData()
        {
            DataSet ds = new DataSet();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { ds = BLL.QueryData.getInstance().getUserManager(); };
            bw.RunWorkerCompleted += delegate
            {

                frmWait.Close();
                gridControl1.BeginUpdate();
                gridControl2.BeginUpdate();
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                gridControl1.DataSource = ds;
                gridControl1.DataMember = "g";
                gridControl2.DataSource = ds;
                gridControl2.DataMember = "g.R_ct";
                gridView1.BestFitColumns();
                gridView2.BestFitColumns();
                gridControl1.EndUpdate();
                gridControl2.EndUpdate();

                ChangeControlStatus(ActionStatus.Normal);
            };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }
        private void LoadDataToControl()
        {
            if (obj != null)
            {
                txtUserId.Text = obj.UserId;
                txtName.Text = obj.Name;
                txtDiaChi.Text = obj.Address;
                txtMaNhanVien.Text = obj.IdEmployer;
                txtYear.Text = obj.BirthDay;
                txtPass.Text = obj.Pass;
                chkIsUsed.Checked = Convert.ToBoolean(obj.IsUsed);
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
                    txtPass.ReadOnly = true;
                    txtUserId.ReadOnly = true;
                    txtMaNhanVien.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    txtYear.ReadOnly = true;
                    chkIsUsed.ReadOnly = true;
                    gridView2.OptionsBehavior.ReadOnly = true;
                    break;
                case ActionStatus.Update:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    txtName.ReadOnly = false;
                    txtPass.ReadOnly = false;
                    txtUserId.ReadOnly = false;
                    txtMaNhanVien.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    txtYear.ReadOnly = false;
                    chkIsUsed.ReadOnly = false;
                    gridView2.OptionsBehavior.ReadOnly = false;
                    break;
                case ActionStatus.AddNew:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    txtName.ReadOnly = false;
                    txtPass.ReadOnly = false;
                    txtUserId.ReadOnly = false;
                    txtMaNhanVien.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    txtYear.ReadOnly = false;
                    chkIsUsed.ReadOnly = false;
                    gridView2.OptionsBehavior.ReadOnly = false;
                    break;
            }
        }
        private void ClearData()
        {
            txtName.Text = "";
            txtPass.Text = "";
            txtUserId.Text = "";
            txtMaNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtYear.Text = "";
            chkIsUsed.Checked = false;
        }

        private void UpdateData()
        {
            try
            {
                User insertObj = SetDataFromControl();

                if (BLL.QueryData.getInstance().UpdateUser(insertObj))
                {
                    if (BLL.QueryData.getInstance().DeletePermission(insertObj.UserId))
                    {
                        DataTable dt = ((DataView)gridView2.DataSource).ToTable();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];
                            Permission temp = SetRowPermissionToObject(row);
                            BLL.QueryData.getInstance().InsertPermission(temp);
                        }
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeControlStatus(ActionStatus.Normal);
                        RefeshData();
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void InsertData()
        {
            User insertObj = SetDataFromControl();

            if (BLL.QueryData.getInstance().UpdateUser(insertObj))
            {
                DataTable dt = ((DataView)gridView2.DataSource).ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    Permission temp = SetRowPermissionToObject(row);
                    BLL.QueryData.getInstance().InsertPermission(temp);
                }
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeControlStatus(ActionStatus.Normal);
                RefeshData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.AddNew);
            ClearData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Update);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn chắc chắn xóa người dùng này!", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (obj == null || obj.Id == string.Empty) return;
                if (BLL.QueryData.getInstance().DeleteUser(obj))
                {
                    if (BLL.QueryData.getInstance().DeletePermission(obj.UserId))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeControlStatus(ActionStatus.Normal);
                        RefeshData();
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.Normal) return;
            if (currentActionStatus == ActionStatus.Update && CheckData())
            {
                UpdateData();
            }
            if (currentActionStatus == ActionStatus.AddNew && CheckData())
            {
                InsertData();
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
        private void treeList1_GetCustomSummaryValue(object sender, GetCustomSummaryValueEventArgs e)
        {
            if (e.Column.FieldName == "master_data_name")
            {
                e.CustomValue = e.Nodes.Count;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Control && keyData == Keys.S && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnSave_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Control && keyData == Keys.E && currentActionStatus == ActionStatus.Normal)
            {
                btnEdit_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Control && keyData == Keys.N && currentActionStatus == ActionStatus.Normal)
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
            if (keyData == Keys.Delete && currentActionStatus == ActionStatus.Normal)
            {
                btnDelete_Click(new object(), EventArgs.Empty);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private bool CheckData()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtUserId.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserId.Focus();
                return false;
            }

            if (txtPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return false;
            }

            return true;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow row = gridView1.GetFocusedDataRow();
                obj = SetRowUserToObject(row);
                LoadDataToControl();
            }
        }
    }
}