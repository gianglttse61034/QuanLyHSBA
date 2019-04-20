using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_HeThong;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using Lib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace Interface.Report
{

    public partial class UCReport_NhapKho : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        #region  Khai báo biến toàn cục
        private DataTable dt, dt_Thuoc;
        private DateTime tuNgay = DateTime.MinValue;
        private DateTime denNgay = DateTime.MinValue;
        #endregion
        public UCReport_NhapKho(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            tuNgay = fromDate;
            denNgay = toDate;

        }
        private void LoadLayout()
        {
            if (gridViewCT.Columns.Count == 0)
            {
                gridViewCT.BeginUpdate();
                gridViewCT.OptionsSelection.MultiSelect = true;
                gridViewCT.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridViewCT.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
                gridViewCT.Appearance.Row.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridViewCT.Appearance.HeaderPanel.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridViewCT.OptionsView.ColumnAutoWidth = false;
                gridViewCT.Columns.Clear();
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("id", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("soct", "Số chứng từ", GridHelper.GridHelperType.TextEdit));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("soct_xuat", "Số chứng từ Xuất", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("stt", "Số Kho", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("birth_day", "Ngày sinh", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("id_luu_tru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("create_date", "Ngày tạo", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("create_by", "Người tạo", GridHelper.GridHelperType.TextEdit));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("update_date", "Ngày chỉnh sửa", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("update_by", "Người chỉnh sửa", GridHelper.GridHelperType.TextEdit));
                gridViewCT.BestFitColumns();
                gridViewCT.EndUpdate();
            }
        }
        #region IReport
        void IReport.ExportExcel()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
            save.FileName = "Báo cáo lịch sử nhập kho hồ sơ bệnh án";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FilterIndex == 1)
                {
                    gridControl_CT.ExportToXls(save.FileName);
                    System.Diagnostics.Process.Start(save.FileName);
                }
                
                else if (save.FilterIndex == 2)
                {
                    gridControl_CT.ExportToXlsx(save.FileName);
                    System.Diagnostics.Process.Start(save.FileName);
                }
                    
            }
        }
        void IReport.Preview()
        {
            DataTable dt_X = ((DataView)gridViewCT.DataSource).ToTable();
            string strReport = "\\Report\\RptBaoCaoThuocCanDate.repx";
                XtraReport xtra_report = new XtraReport();
                xtra_report.Parameters.Clear();
                string file = Application.StartupPath + strReport;
                xtra_report.LoadLayout(file);
                xtra_report.DataSource = dt_X;
                FrmXtraReportViewer rpt = new FrmXtraReportViewer(xtra_report);
                rpt.ShowDialog();
        }
        string IReport.Title()
        {
            return "Báo Cáo Lịch Sử Nhập Kho Hồ Sơ Bệnh Án";
        }
        void IReport.RefeshData(DateTime tuNgay, DateTime denNgay)
        {

        }
        void IReport.RefeshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frm = new frmWaiting();
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getReportNhapKho(tuNgay, denNgay); };
            bw.RunWorkerCompleted += delegate
            {
                frm.Close();
                gridControl_CT.BeginUpdate();
                gridControl_CT.DataSource = null;
                gridControl_CT.DataSource = dt;
                gridControl_CT.EndUpdate();
                gridViewCT.BestFitColumns();
            };
            bw.RunWorkerAsync();
            frm.ShowDialog();
            bw.Dispose();
        }
        void IReport.ShowDetail()
        {
            throw new NotImplementedException();
        }
        void IReport.Exit()
        {
            if (dt != null)
                dt.Dispose();
            FindForm().Close();
        }
        // Khi khởi tạo.
        void IReport.Load()
        {
            LoadLayout();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frm = new frmWaiting();
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getReportNhapKho(tuNgay, denNgay);};
            bw.RunWorkerCompleted += delegate
            {
                frm.Close();
                gridControl_CT.BeginUpdate();
                gridControl_CT.DataSource = null;
                gridControl_CT.DataSource = dt;
                gridControl_CT.EndUpdate();
                gridViewCT.BestFitColumns();
            };
            bw.RunWorkerAsync();
            frm.ShowDialog();bw.Dispose();
        }
        #endregion

    }
}
