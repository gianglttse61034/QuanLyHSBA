using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Interface;
using Lib;
using System.Threading;
using System.IO;
using BLL.DO;
using DevExpress.XtraTabbedMdi;
using Interface.Report;

namespace QuanLyHoSo
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtPermission;
        private List<Permission> arrPermission;
        private int flagLogOff = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        public DataTable DtPermission
        {
            get { return dtPermission; }
            set { dtPermission = value; }
        }


        #region Event


        #region Account
        private void btnManagerAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["frmDanhMucUser"] as frmDanhMucUser    ;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmDanhMucUser frm = new frmDanhMucUser();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (flagLogOff == 0)
                LogOff();
            else if (flagLogOff == 1)
            {
                frmLogin frm = new frmLogin();
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    btnLogOut.Caption = "Đăng xuất";
                    flagLogOff = 0;
                }
            }
        }

        private void btnResetPass_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #endregion

        private void LogOff()
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                var form = Application.OpenForms[i];
                if (form.Name != "frmMain")
                    form.Close();
            }

            btnLogOut.Caption = "Đăng nhập";
            mnuReportXuatKho.Visibility = BarItemVisibility.Never;
            mnuReportNhapKho.Visibility = BarItemVisibility.Never;
            mnuLichSuHoSoBenhAn.Visibility = BarItemVisibility.Never;
            btnNhapKho.Visibility = BarItemVisibility.Never;
            btnXuatKho.Visibility = BarItemVisibility.Never;
            btnDanhMucKho.Visibility = BarItemVisibility.Never;
            btnManagerAccount.Visibility = BarItemVisibility.Never;
            flagLogOff = 1;
            frmLogin frm = new frmLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                flagLogOff = 0;
            }
        }

        private void LoadData()
        {
            txtAccountName.Caption = txtAccountName.Caption + BLL.DataAccount.User.Name;
            arrPermission = new List<Permission>();
            DocGiaoDien_Main();
            DtPermission = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { DtPermission = BLL.QueryData.getInstance().getPermissionUser(BLL.DataAccount.User.UserId); };
            bw.RunWorkerCompleted += delegate
            {
                if (DtPermission != null)
                {
                    arrPermission = ParseListPermissions(DtPermission);
                }
                CheckPermissionUser();
                frmWait.Close();
            };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this;
            LoadData();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

        }

        private void TimerCallback(Object o)
        {
            string result = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtTimer.Caption = "Thời gian đăng nhập: " + result;
        }

        private bool DocGiaoDien_Main()
        {
            try
            {
                string url = String.Format(@"{0}\\QuanLyHoSo.skin", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                //nều file không tồn tại thì bỏ qua
                if (!File.Exists(url)) return false;
                //đọc dữ liệu trong file
                StreamReader file = File.OpenText(url);
                string str = file.ReadLine();
                if (!string.IsNullOrEmpty(str))//nếu có dữ liệu thì đổi skin
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(str);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void LuuGiaoDien_Main()
        {
            try
            {
                string url = String.Format(@"{0}\\QuanLyHoSo.skin", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                //xóa file cũ
                if (File.Exists(url)) File.Delete(url);
                //tạo file mới
                StreamWriter file = File.CreateText(url);
                file.WriteLine(defaultLookAndFeel1.LookAndFeel.SkinName);
                file.Close();
            }
            catch
            {

            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            LuuGiaoDien_Main();
            Application.Exit();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now.AddSeconds(1);
            int minute = current.Minute;
            int second = current.Second;
            this.txtTimer.Caption = String.Format("Ngày: {0} {1}", current.ToString("dd/MM/yyyy"), current.ToString("hh:mm"));
        }

        #region Danh muc - Xuat Nhap Kho
        private void btnDanhMucKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["frmDanhMuc"] as frmDanhMuc;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmDanhMuc frm = new frmDanhMuc();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        private void btnNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["frmNhapKho"] as frmNhapKho;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmNhapKho frm = new frmNhapKho();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        private void btnXuatKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["frmXuatKho"] as frmNhapKho;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmXuatKho frm = new frmXuatKho();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        #endregion

        #region Report
        private void mnuReportNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["UCReport_NhapKho"] as FrmReport_WithoutTime;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                FrmChonLoaiThoiGian frmTime = new FrmChonLoaiThoiGian();
                if (frmTime.ShowDialog() != DialogResult.OK) return;
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_NhapKho(frmTime.TuNgay, frmTime.DenNgay));
                //Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo lịch sử nhập kho hồ sơ bệnh án";
                frm.Name = "UCReport_NhapKho";
                //Display the new form.
                frm.Show();
            }
        }
        private void mnuReportXuatKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["UCReport_XuatKho"] as FrmReport_WithoutTime;

            if (form != null)
            {
                form.Activate();
            }
            else
            {
                FrmChonLoaiThoiGian frmTime = new FrmChonLoaiThoiGian();
                if (frmTime.ShowDialog() != DialogResult.OK) return;
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_XuatKho(frmTime.TuNgay, frmTime.DenNgay));
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo lịch sử xuất kho hồ sơ bệnh án";
                frm.Name = "UCReport_XuatKho";
                // Display the new form.
                frm.Show();
            }
        }
        private void mnuLichSuHoSoBenhAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["UCReport_LichSuHoSoBenhAn"] as FrmReport_WithoutTime;

            if (form != null)
            {
                form.Activate();
            }
            else
            {
                FrmChonLoaiThoiGian frmTime = new FrmChonLoaiThoiGian();
                if (frmTime.ShowDialog() != DialogResult.OK) return;
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_LichSuHoSoBenhAn(frmTime.TuNgay, frmTime.DenNgay));
                //Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo lịch sử nhập kho hồ sơ bệnh án";
                frm.Name = "UCReport_LichSuHoSoBenhAn";
                //Display the new form.
                frm.Show();
            }
        }
        #endregion

        #region Permission

        private void CheckPermissionForm(object control, string nameForm)
        {
            try
            {
                DtPermission.DefaultView.RowFilter = $"permissionName = '{nameForm}'";
                if (DtPermission.DefaultView.ToTable().Rows.Count == 1)
                {
                    ((BarButtonItem)control).Visibility = BarItemVisibility.Always;
                }
                else
                {
                    ((BarButtonItem)control).Visibility = BarItemVisibility.Never;
                }
                DtPermission.DefaultView.RowFilter = string.Empty;
            }
            catch (Exception)
            {

            }
        }
        private void CheckPermissionUser()
        {
            CheckPermissionForm(mnuReportNhapKho, "UCReport_NhapKho");
            CheckPermissionForm(mnuReportXuatKho, "UCReport_XuatKho");
            CheckPermissionForm(mnuLichSuHoSoBenhAn, "UCReport_LichSuHoSoBenhAn");
            CheckPermissionForm(btnNhapKho, "frmNhapKho");
            CheckPermissionForm(btnXuatKho, "frmXuatKho");
            CheckPermissionForm(btnDanhMucKho, "frmDanhMuc");
            CheckPermissionForm(btnManagerAccount, "frmDanhMucUser");
        }
        public List<Permission> ParseListPermissions(DataTable dt)
        {
            List<Permission> lst = new List<Permission>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row != null)
                {
                    Permission per = new Permission();
                    try
                    {
                        per.Id = row["id"].Equals(DBNull.Value) ? "" : row["id"].ToString();
                        per.UserId = row["UserId"].Equals(DBNull.Value) ? "" : row["UserId"].ToString();
                        per.PermissionName = row["PermissionName"].Equals(DBNull.Value) ? "" : row["PermissionName"].ToString();
                        per.AllowEdit = row["AllowEdit"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(row["AllowEdit"]);
                        per.AllowExport = row["AllowExport"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(row["AllowExport"]);
                        per.AllowNew = row["AllowNew"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(row["AllowNew"]);
                        per.AllowPrint = row["AllowPrint"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(row["AllowPrint"]);
                        lst.Add(per);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lst;
        }
        #endregion
    }
}