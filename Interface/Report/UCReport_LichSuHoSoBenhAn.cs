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
using BLL_HeThong;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using Lib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace Interface.Report
{

    public partial class UCReport_LichSuHoSoBenhAn : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        #region  Khai báo biến toàn cục
        private DataSet ds;
        private DateTime tuNgay = DateTime.MinValue;
        private DateTime denNgay = DateTime.MinValue;
        #endregion
        public UCReport_LichSuHoSoBenhAn(DateTime fromDate, DateTime toDate)
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
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("id_luutru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("description", "Ghi chú", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("thoigian_tra_dukien", "Thời gian trả dự kiến", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("nguoitiepnhan", "Người tiếp nhận", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("thoigian_tra_thucte", "Thời gian trả thực tế", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("detail", "Chi tiết", GridHelper.GridHelperType.TextEdit));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("soct_nhap", "Số chứng từ nhập", GridHelper.GridHelperType.TextEdit));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("create_date", "Ngày tạo", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridViewCT.Columns.Add(GridHelper.getInstance().Format("create_by", "Người tạo", GridHelper.GridHelperType.TextEdit));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("update_date", "Ngày chỉnh sửa", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                //gridViewCT.Columns.Add(GridHelper.getInstance().Format("update_by", "Người chỉnh sửa", GridHelper.GridHelperType.TextEdit));
                gridViewCT.BestFitColumns();
                gridViewCT.EndUpdate();
            }
            if (gridViewG.Columns.Count == 0)
            {
                gridViewG.BeginUpdate();
                gridViewG.OptionsSelection.MultiSelect = true;
                gridViewG.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridViewG.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
                gridViewG.Appearance.Row.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridViewG.Appearance.HeaderPanel.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
                gridViewG.OptionsView.ColumnAutoWidth = false;
                gridViewG.Columns.Clear();
                gridViewG.Columns.Add(GridHelper.getInstance().Format("id", "Họ và tên", GridHelper.GridHelperType.TextEdit, "", 0, 0, false));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("soct", "Số chứng từ", GridHelper.GridHelperType.TextEdit));
                //gridViewG.Columns.Add(GridHelper.getInstance().Format("soct_xuat", "Số chứng từ Xuất", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("stt", "Số Kho", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("name", "Họ và tên", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("birth_day", "Ngày sinh", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("id_ticket_hospital", "Số vào viện", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("id_luu_tru", "Số lưu trữ", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("kho_name", "Kho", GridHelper.GridHelperType.TextEdit));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("create_date", "Ngày tạo", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                gridViewG.Columns.Add(GridHelper.getInstance().Format("create_by", "Người tạo", GridHelper.GridHelperType.TextEdit));
                //gridViewG.Columns.Add(GridHelper.getInstance().Format("update_date", "Ngày chỉnh sửa", GridHelper.GridHelperType.DateTime, Constants.DateTimeFormat));
                //gridViewG.Columns.Add(GridHelper.getInstance().Format("update_by", "Người chỉnh sửa", GridHelper.GridHelperType.TextEdit));
                gridViewG.BestFitColumns();
                gridViewG.EndUpdate();
            }
        }
        #region IReport
        void IReport.ExportExcel()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
            save.FileName = "Báo cáo lịch sử hồ sơ bệnh án";
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
            //DataTable dt_X = ((DataView)gridViewCT.DataSource).ToTable();
            //string strReport = "\\Report\\RptBaoCaoThuocCanDate.repx";
            //    XtraReport xtra_report = new XtraReport();
            //    xtra_report.Parameters.Clear();
            //    string file = Application.StartupPath + strReport;
            //    xtra_report.LoadLayout(file);
            //    xtra_report.DataSource = dt_X;
            //    FrmXtraReportViewer rpt = new FrmXtraReportViewer(xtra_report);
            //    rpt.ShowDialog();
        }
        string IReport.Title()
        {
            return "Báo Cáo Lịch Sử Hồ Sơ Bệnh Án";
        }
        void IReport.RefeshData(DateTime tuNgay, DateTime denNgay)
        {

        }
        void IReport.RefeshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frm = new frmWaiting();
            bw.DoWork += delegate { ds = BLL.QueryData.getInstance().getReportLichSuHoSoBenhAn(tuNgay, denNgay); };
            bw.RunWorkerCompleted += delegate
            {
                frm.Close();
                gridControl_G.BeginUpdate();
                gridControl_CT.BeginUpdate();
                gridControl_CT.DataSource = null;
                gridControl_G.DataSource = null;

                gridControl_G.DataSource = ds;
                gridControl_G.DataMember = "g";
                gridControl_CT.DataSource = ds;
                gridControl_CT.DataMember = "g.R_ct";
                gridControl_G.EndUpdate();
                gridControl_CT.EndUpdate();
                gridViewG.BestFitColumns();
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
            if (ds != null)
                ds.Dispose();
            FindForm().Close();
        }
        // Khi khởi tạo.
        void IReport.Load()
        {
            LoadLayout();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frm = new frmWaiting();
            bw.DoWork += delegate { ds = BLL.QueryData.getInstance().getReportLichSuHoSoBenhAn(tuNgay,denNgay);};
            bw.RunWorkerCompleted += delegate
            {
                frm.Close();
                gridControl_G.BeginUpdate();
                gridControl_CT.BeginUpdate();
                gridControl_CT.DataSource = null;
                gridControl_G.DataSource = null;

                gridControl_G.DataSource = ds;
                gridControl_G.DataMember = "g";
                gridControl_CT.DataSource = ds;
                gridControl_CT.DataMember = "g.R_ct";
                gridControl_G.EndUpdate();
                gridControl_CT.EndUpdate();
                gridViewG.BestFitColumns();
                gridViewCT.BestFitColumns();
            };
            bw.RunWorkerAsync();
            frm.ShowDialog();
            bw.Dispose();
        }
        #endregion

    }
}
