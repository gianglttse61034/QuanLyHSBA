using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using BLL_HeThong;


namespace GPP_Application_HL
{
    public partial class FrmReport_WithoutTime : DevExpress.XtraEditors.XtraForm
    {
        private IReport m_IReport;
        public IReport IReport
        {
            get { return m_IReport; }
        }

        public FrmReport_WithoutTime(IReport iReport)
        {
            InitializeComponent();
            //ẩn progressbar
            groupControl_Progress.SendToBack();
            m_IReport = iReport;
        }

        private void FrmReport_WithoutTime_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            SetText("Khởi tạo dữ liệu");
            bw.RunWorkerCompleted += delegate
            {
                //tên hiển thị trên tab
                Text = (m_IReport.Title()).ToUpper();
                //tiêu đề form
                lblTitle.Text = (m_IReport.Title()).ToUpper();
                //add control vào main form
                pnlMain.Controls.Add((Control)m_IReport);
                ((Control)m_IReport).Dock = DockStyle.Fill;
                m_IReport.Load();
                /*---------------------------*/
                SetProgressbar(false);
                Activate();
            };
            bw.RunWorkerAsync();
            SetProgressbar(true);
            bw.Dispose();

        }

        #region phương thức
        
        /// <summary>
        /// hiển thị text cho progressbar
        /// </summary>
        /// <param name="text"></param>
        public void SetText(String text)
        {
            if (prgState.InvokeRequired)
            {
                prgState.Invoke((MethodInvoker)delegate { prgState.Text = text; });
                return;
            }
            prgState.Text = text;
        }

        /// <summary>
        /// ẩn / hiện progressbar
        /// </summary>
        /// <param name="flag"></param>
        public void SetProgressbar(bool flag)
        {
            if (pnlMain.InvokeRequired)
            {
                pnlMain.Invoke((MethodInvoker)delegate
                {
                    //hiện progressbar
                    if (flag)
                    {
                        groupControl_Progress.BringToFront();
                    }
                    else
                        groupControl_Progress.SendToBack();

                    pnlMain.Enabled = !flag;
                });
            }

            //hiện progressbar
            if (flag)
            {
                groupControl_Progress.BringToFront();
            }
            else
                groupControl_Progress.SendToBack();

            pnlMain.Enabled = !flag;
        }

        #endregion

        #region sự kiện

        private void FrmReport_WithoutTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                m_IReport.Exit();
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                m_IReport.ShowDetail();
            }
            else if (e.KeyCode == Keys.F5)
            {
                m_IReport.RefeshData();
            }
        }

        private void FrmReport_WithoutTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
        //lấy dữ liệu
        private void btnThucHien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.RefeshData();
        }

        //xem mẫu in
        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.Preview();
        }

        //xuất excel
        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.ExportExcel();
        }

        //thoát
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.Exit();
        }

        #endregion

    }
}