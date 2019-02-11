using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;

namespace Lib
{
    public partial class FrmXtraReportViewer : DevExpress.XtraEditors.XtraForm
    {
        public XtraReport XReport { get; set; }

        public FrmXtraReportViewer(XtraReport xReport)
        {
            InitializeComponent();
            this.XReport = xReport;
            this.documentViewer1.PrintingSystem = xReport.PrintingSystem;
            this.documentViewer1.PrintingSystem.ShowMarginsWarning = false;
            
            xReport.CreateDocument();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             this.XReport.ShowRibbonDesignerDialog();
        }

        private void FrmXtraReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            //ESC: Thoát
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }
        }

    }
}