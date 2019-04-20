using System;
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
    public partial class frmXuatKho : DevExpress.XtraEditors.XtraForm
    {
        private ActionStatus currentActionStatus;
        private NhapKho objNhapKho;
        private XuatKho objXuatKho;
        private DataTable dtKHO;
        private DataTable dtNhapKho;
        private CurrentAction currentAction;
        private int currentHandle;
        public enum CurrentAction
        {
            XuatKho = 0,
            TaiNhapKho = 1
        }
        public enum ActionStatus
        {
            Normal = 0,
            AddNew = 1,
            Update = 2
        }
        public frmXuatKho()
        {
            InitializeComponent();
        }
        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void frmXuatKho_Shown(object sender, EventArgs e)
        {
            ShownData();
        }
        public void LoadData()
        {
            currentAction = CurrentAction.XuatKho;
            LoadLayout();
        }
        public void ShownData()
        {
            DataTable dt = new DataTable();
            DataTable dtNhapKhoChuaXuat = new DataTable();
            dtKHO = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getXuatKho(); };
            bw.DoWork += delegate { dtKHO = BLL.QueryData.getInstance().getListKho(true); };
            bw.DoWork += delegate { dtNhapKhoChuaXuat = BLL.QueryData.getInstance().getDanhSachNhapKhoChuaXuat(); };
            bw.DoWork += delegate { dtNhapKho = BLL.QueryData.getInstance().getNhapKho(); };
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

                searchLookUpEdit2.Properties.View.Columns.Clear();
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("id", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("soct", "Số Chứng từ", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("stt", "Số Kho", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("birth_day", "Ngày sinh", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("id_luu_tru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                searchLookUpEdit2.Properties.View.BestFitColumns();
                searchLookUpEdit2.Properties.ShowClearButton = false;
                searchLookUpEdit2.Properties.NullText = "";
                searchLookUpEdit2.Properties.DisplayMember = "display_member";
                searchLookUpEdit2.Properties.ValueMember = "id";
                searchLookUpEdit2.Properties.DataSource = dtNhapKhoChuaXuat;

                gridControl1.BeginUpdate();
                gridControl1.DataSource = null;
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                gridControl1.EndUpdate();

                ChangeControlStatus(ActionStatus.Normal);
            }; bw.RunWorkerAsync();
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
                gridView1.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("id_luutru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("description", "Ghi chú", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("thoigian_tra_dukien", "Thời gian trả dự kiến", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("nguoitiepnhan", "Người tiếp nhận", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("thoigian_tra_thucte", "Thời gian trả thực tế", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("detail", "Chi tiết", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("soct_nhap", "Số chứng từ nhập", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("create_date", "Ngày tạo", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("create_by", "Người tạo", GridHelper.GridHelperType.TextEdit));
                gridView1.Columns.Add(GridHelper.getInstance().Format("update_date", "Ngày chỉnh sửa", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridView1.Columns.Add(GridHelper.getInstance().Format("update_by", "Người chỉnh sửa", GridHelper.GridHelperType.TextEdit));
                gridView1.BestFitColumns();
                gridView1.EndUpdate();
            }
        }
        private void SetDataRowToObjectXuatKho(DataRow row)
        {
            objXuatKho = new XuatKho();
            try
            {
                objXuatKho.Id = row["id"] != null && !row["id"].Equals(DBNull.Value) ? row["id"].ToString() : "";
                objXuatKho.IdHdn = row["id_hdn"] != null && !row["id_hdn"].Equals(DBNull.Value) ? row["id_hdn"].ToString() : "";
                objXuatKho.IdKho = row["id_kho"] != null && !row["id_kho"].Equals(DBNull.Value) ? row["id_kho"].ToString() : "";
                objXuatKho.IdTicketHospital = row["id_ticket_hospital"] != null && !row["id_ticket_hospital"].Equals(DBNull.Value) ? row["id_ticket_hospital"].ToString() : "";
                objXuatKho.IdLuutru = row["id_luutru"] != null && !row["id_luutru"].Equals(DBNull.Value) ? row["id_luutru"].ToString() : "";
                objXuatKho.IdXuatkhoLog = row["id_xuatkho_log"] != null && !row["id_xuatkho_log"].Equals(DBNull.Value) ? row["id_xuatkho_log"].ToString() : "";
                objXuatKho.ThoigianTraDukien = row["thoigian_tra_dukien"] != null && !row["thoigian_tra_dukien"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["thoigian_tra_dukien"]) : DateTime.MinValue;
                objXuatKho.Nguoitiepnhan = row["nguoitiepnhan"] != null && !row["nguoitiepnhan"].Equals(DBNull.Value) ? row["nguoitiepnhan"].ToString() : "";
                objXuatKho.ThoigiangXuattam = row["thoigian_xuattam"] != null && !row["thoigian_xuattam"].Equals(DBNull.Value) ? Convert.ToInt32(row["thoigian_xuattam"]) : 0;
                objXuatKho.Flag = row["flag"] != null && !row["flag"].Equals(DBNull.Value) ? Convert.ToInt32(row["flag"]) : 0;
                objXuatKho.Soct = row["soct"] != null && !row["soct"].Equals(DBNull.Value) ? row["soct"].ToString() : "";
                objXuatKho.Description = row["description"] != null && !row["description"].Equals(DBNull.Value) ? row["description"].ToString() : "";
                objXuatKho.CreateBy = row["create_by"] != null && !row["create_by"].Equals(DBNull.Value) ? row["create_by"].ToString() : "";
                objXuatKho.CreateDate = row["create_date"] != null && !row["create_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["create_date"]) : DateTime.MinValue;

                objXuatKho.UpdateBy = row["update_by"] != null && !row["update_by"].Equals(DBNull.Value) ? row["update_by"].ToString() : "";
                objXuatKho.UpdateDate = row["update_date"] != null && !row["update_date"].Equals(DateTime.MinValue) && row["update_date"].ToString() != string.Empty ? Convert.ToDateTime(row["update_date"]) : DateTime.MinValue;
                objXuatKho.ThoigianTraThucte = row["thoigian_tra_thucte"] != null && !row["thoigian_tra_thucte"].Equals(DateTime.MinValue) && row["thoigian_tra_thucte"].ToString() != string.Empty ? Convert.ToDateTime(row["thoigian_tra_thucte"]) : DateTime.MinValue;
            }
            catch (Exception ex)
            {

            }
        }
        private void SetDataFromControl()
        {
            try
            {
                if (objXuatKho == null)
                    objXuatKho = new XuatKho();
                objXuatKho.Description = txtGhiChu.Text;
                objXuatKho.IdLuutru = txtLuuTru.Text;
                objXuatKho.IdTicketHospital = txtTicketHospital.Text;
                objXuatKho.IdKho = searchLookUpEdit1.EditValue != null ? searchLookUpEdit1.EditValue.ToString() : "";
                objXuatKho.CreateBy = DataAccount.User.UserId;
                objXuatKho.CreateDate = DateTime.Now;
                objXuatKho.UpdateDate = DateTime.Now;
                objXuatKho.UpdateBy = DataAccount.User.UserId;
                objXuatKho.Flag = 0;
                objXuatKho.IdHdn = searchLookUpEdit2.EditValue != null ? searchLookUpEdit2.EditValue.ToString() : "";
                objXuatKho.Nguoitiepnhan = txtNguoiNhan.Text;
                objXuatKho.ThoigiangXuattam = txtThoiGianXuatTam.Text == string.Empty ? 0 : Convert.ToInt32(txtThoiGianXuatTam.Text);
                objXuatKho.ThoigianTraDukien = Convert.ToDateTime(dtmThoiGianTraDuKien.EditValue);
                objXuatKho.Soct = txtSoCT.Text;
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
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getXuatKho(); };
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
            try
            {
                if (objNhapKho != null)
                {
                    txtName.Text = objNhapKho.Name;
                    txtLuuTru.Text = objNhapKho.Luutru;
                    txtTicketHospital.Text = objNhapKho.Tickethospital;
                    txtBirthDay.Text = objNhapKho.Birthday;
                    searchLookUpEdit1.EditValue = objNhapKho.Kho.ToUpper();
                    searchLookUpEdit2.EditValue = objNhapKho.Id.ToUpper();
                }

                if (objXuatKho != null)
                {
                    txtNguoiNhan.Text = objXuatKho.Nguoitiepnhan;
                    txtGhiChu.Text = objXuatKho.Description;
                    txtSoCT.Text = objXuatKho.Soct;
                    txtThoiGianXuatTam.Text = objXuatKho.ThoigiangXuattam.ToString();
                    dtmThoiGianTraDuKien.EditValue = objXuatKho.ThoigianTraDukien;
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadNhapKhoToControl(string id)
        {
            dtNhapKho.DefaultView.RowFilter = $"id = '{id}'";
            if (dtNhapKho.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow row = dtNhapKho.DefaultView.ToTable().Rows[0];
                SetDataRowToObjectNhapKho(row);
                LoadDataToControl();
            }
            dtNhapKho.DefaultView.RowFilter = string.Empty;
        }

        private void clearControl()
        {
            txtBirthDay.Text = "";
            txtGhiChu.Text = "";
            txtName.Text = "";
            txtSoCT.Text = "";
            searchLookUpEdit1.EditValue = "";
            searchLookUpEdit2.EditValue = "";
            txtNguoiNhan.Text = "";
            txtGhiChu.Text = "";
            txtSoCT.Text = "";
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

                    txtSoCT.ReadOnly = true;
                    txtName.ReadOnly = true;
                    txtBirthDay.ReadOnly = true;
                    txtLuuTru.ReadOnly = true;
                    txtTicketHospital.ReadOnly = true;
                    searchLookUpEdit1.ReadOnly = true;
                    searchLookUpEdit2.ReadOnly = true;
                    dtmThoiGianTraDuKien.ReadOnly = true;
                    break;
                case ActionStatus.Update:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    searchLookUpEdit2.ReadOnly = true;
                    if (currentAction == CurrentAction.TaiNhapKho)
                    {
                        searchLookUpEdit1.ReadOnly = false;
                    }
                    break;
                case ActionStatus.AddNew:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    searchLookUpEdit2.ReadOnly = false;
                    break;
            }
        }
        private void SetDataRowToObjectNhapKho(DataRow row)
        {
            objNhapKho = new NhapKho();
            try
            {
                objNhapKho.Id = row["id"] != null && !row["id"].Equals(DBNull.Value) ? row["id"].ToString() : "";
                objNhapKho.Name = row["name"] != null && !row["name"].Equals(DBNull.Value) ? row["name"].ToString() : "";
                objNhapKho.Birthday = row["birth_day"] != null && !row["birth_day"].Equals(DBNull.Value) ? row["birth_day"].ToString() : "";
                objNhapKho.Tickethospital = row["id_ticket_hospital"] != null && !row["id_ticket_hospital"].Equals(DBNull.Value) ? row["id_ticket_hospital"].ToString() : "";
                objNhapKho.Luutru = row["id_luu_tru"] != null && !row["id_luu_tru"].Equals(DBNull.Value) ? row["id_luu_tru"].ToString() : "";
                objNhapKho.Kho = row["id_kho"] != null && !row["id_kho"].Equals(DBNull.Value) ? row["id_kho"].ToString() : "";
                objNhapKho.Createby = row["create_by"] != null && !row["create_by"].Equals(DBNull.Value) ? row["create_by"].ToString() : "";
                objNhapKho.Createdate = row["create_date"] != null && !row["create_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["create_date"]) : DateTime.MinValue;
                objNhapKho.Isused = Convert.ToInt16(row["is_used"]);
                objNhapKho.Updateby = row["update_by"] != null && !row["update_by"].Equals(DBNull.Value) ? row["update_by"].ToString() : "";
                objNhapKho.Updatedate = row["update_date"] != null && !row["update_date"].Equals(DateTime.MinValue) ? Convert.ToDateTime(row["update_date"]) : DateTime.MinValue;
            }
            catch (Exception)
            {

            }

        }
        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.AddNew);
            clearControl();
            txtSoCT.Text = QueryData.autoCreatedHandleId("HDX"+DateTime.Now.ToString("yyMMdd"), "soct", QueryData.tableXuatKho);
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
                if (objXuatKho == null || objXuatKho.Id == string.Empty) return;
                //SetDataFromControl();
                objXuatKho.UpdateBy = DataAccount.User.UserId;
                objXuatKho.UpdateDate = DateTime.Now;
                if (BLL.QueryData.getInstance().DeleteXuatKho(objXuatKho))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                    if (gridView1.RowCount == 0)
                    {
                        objNhapKho = new NhapKho();
                        LoadDataToControl();
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.Normal) return;
            if (currentActionStatus == ActionStatus.Update)
            {
                if (currentAction != CurrentAction.TaiNhapKho)
                {
                    if (objXuatKho == null || objXuatKho.Id == string.Empty) return;
                    SetDataFromControl();
                    if (BLL.QueryData.getInstance().UpdateXuatKho(objXuatKho))
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
                else
                {
                    if (objNhapKho == null || objNhapKho.Id == string.Empty) return;
                    objNhapKho.IdHdx = objXuatKho.Id;
                    objNhapKho.Updateby = DataAccount.User.UserId;
                    objNhapKho.Updatedate = DateTime.Now;
                    objNhapKho.Description = txtGhiChu.Text;
                    if (BLL.QueryData.getInstance().UpdateTaiNhapKho(objNhapKho))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentAction = CurrentAction.XuatKho;
                        ChangeControlStatus(ActionStatus.Normal);
                        RefeshData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (currentActionStatus == ActionStatus.AddNew)
            {
                objNhapKho = new NhapKho();
                SetDataFromControl();
                if (BLL.QueryData.getInstance().InsertXuatKho(objXuatKho))
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
                gridView1.FocusedRowHandle = currentHandle;
            }
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            RefeshData();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle != GridControl.AutoFilterRowHandle && e.FocusedRowHandle >= 0 && currentActionStatus == ActionStatus.Normal)
            {
                currentHandle = e.FocusedRowHandle;
                DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
                
                if (row != null )
                {
                    if (row["detail"] != null && row["detail"].ToString().Contains("Đã tái nhập kho:"))
                    {
                        btnNhapKho.Enabled = false;
                    }
                    else
                    {
                        btnNhapKho.Enabled = true;
                    }
                    SetDataRowToObjectXuatKho(row);
                    //LoadDataToControl();
                    LoadNhapKhoToControl(objXuatKho.IdHdn);
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == (Keys.Control |  Keys.S) &&
                (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnSave_Click(new object(), EventArgs.Empty);
            }

            if (keyData == (Keys.Control | Keys.E) && currentActionStatus == ActionStatus.Normal)
            {
                btnEdit_Click(new object(), EventArgs.Empty);
            }

            if (keyData == (Keys.Control | Keys.N) && currentActionStatus == ActionStatus.Normal)
            {
                btnNew_Click(new object(), EventArgs.Empty);
            }

            if (keyData == Keys.Escape &&
                (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnCancle_Click(new object(), EventArgs.Empty);
            }
            else if(keyData == Keys.Escape)
            {
                this.Close();
            }

            if (keyData == Keys.F5 && currentActionStatus == ActionStatus.Normal)
            {
                btnRefesh_Click(new object(), EventArgs.Empty);
            }

            if (keyData == (Keys.Control| Keys.Delete) && currentActionStatus == ActionStatus.Normal)
            {
                btnDelete_Click(new object(), EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            currentAction = CurrentAction.TaiNhapKho;
            ChangeControlStatus(ActionStatus.Update);
        }
        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit2.EditValue != null && currentAction == CurrentAction.XuatKho && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                LoadNhapKhoToControl(searchLookUpEdit2.EditValue.ToString());
            }
        }
        private void txtThoiGianXuatTam_EditValueChanged(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.Normal)
                return;
            int time = txtThoiGianXuatTam.Text == string.Empty ? 0 : Convert.ToInt32(txtThoiGianXuatTam.EditValue);
            dtmThoiGianTraDuKien.EditValue = DateTime.Now.AddDays(time);
        }
    }
}