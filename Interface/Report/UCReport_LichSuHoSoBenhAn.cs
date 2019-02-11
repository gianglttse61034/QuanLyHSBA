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
namespace GPP_Application_HL
{

    public partial class UCReport_BaoCaoThuoc_DonGia : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        #region  Khai báo biến toàn cục
        private DataTable dt, dt_Thuoc;
        
        #endregion
        public UCReport_BaoCaoThuoc_DonGia()
        {
            InitializeComponent();
            
        }
        private void LoadLayout()
        {
           
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
            return "Báo Cáo Lịch Sử HSBA";
        }
        void IReport.RefeshData(DateTime tuNgay, DateTime denNgay)
        {

        }
        void IReport.RefeshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate {  };
            bw.DoWork += delegate { };
            bw.RunWorkerCompleted += delegate
            {
                gridControl_CT.DataSource = dt;
                LoadLayout();
            };
            bw.RunWorkerAsync();
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
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { };
            bw.DoWork += delegate {  };

            bw.RunWorkerCompleted += delegate
            {
                gridControl_CT.DataSource = dt;
                LoadLayout();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }
        #endregion

    }
}
