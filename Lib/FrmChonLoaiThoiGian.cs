using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_HeThong;
using System.Collections;

namespace Lib
{
    public partial class FrmChonLoaiThoiGian : XtraForm
    {
        #region Khai báo biến (Variable Declare)

        private DateTime m_DenNgay;
        private DateTime m_TuNgay;

        #endregion Khai báo biến (Variable Declare)


        /// <summary>
        /// Constructor
        /// </summary>
        public FrmChonLoaiThoiGian()
        {
            InitializeComponent();
            d_ChonThang.DateTime = DateTime.Now;
            d_ChonNam.DateTime = DateTime.Now;
            d_ChonNgay_1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            d_ChonNgay_2.DateTime = DateTime.Now;
            d_ChonNam.Enabled = false;
            ;
            d_ChonNgay_1.Enabled = false;
            d_ChonNgay_2.Enabled = false;
            m_TuNgay = DateTime.Now;
            m_DenNgay = DateTime.Now;
        }

        /* ==================================================================================================== */

        /// <summary>
        /// From Date
        /// </summary>
        public DateTime TuNgay
        {
            get { return m_TuNgay; }
        }

        /// <summary>
        /// To Date
        /// </summary>
        public DateTime DenNgay
        {
            get { return m_DenNgay; }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d_ChonThang.Enabled = radioGroup1.SelectedIndex == 0;
            d_ChonNam.Enabled = radioGroup1.SelectedIndex == 1;
            d_ChonNgay_1.Enabled = radioGroup1.SelectedIndex == 2;
            d_ChonNgay_2.Enabled = radioGroup1.SelectedIndex == 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    m_TuNgay = new DateTime(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month, 1);
                    m_DenNgay = new DateTime(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month,
                                           DateTime.DaysInMonth(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month));
                    break;
                case 1:
                    m_TuNgay = new DateTime(d_ChonNam.DateTime.Year, 1, 1);
                    m_DenNgay = new DateTime(d_ChonNam.DateTime.Year, 12, 31);
                    break;
                case 2:
                    m_TuNgay = new DateTime(d_ChonNgay_1.DateTime.Year, d_ChonNgay_1.DateTime.Month,
                                          d_ChonNgay_1.DateTime.Day);
                    m_DenNgay = new DateTime(d_ChonNgay_2.DateTime.Year, d_ChonNgay_2.DateTime.Month,
                                           d_ChonNgay_2.DateTime.Day);
                    break;
            }

            m_TuNgay = m_TuNgay.AddHours(-m_TuNgay.Hour);
            m_TuNgay = m_TuNgay.AddMinutes(-m_TuNgay.Minute);
            m_TuNgay = m_TuNgay.AddSeconds(-m_TuNgay.Second);
            m_TuNgay = m_TuNgay.AddMilliseconds(-m_TuNgay.Millisecond);

            m_DenNgay = m_DenNgay.AddHours(23 - m_DenNgay.Hour);
            m_DenNgay = m_DenNgay.AddMinutes(59 - m_DenNgay.Minute);
            m_DenNgay = m_DenNgay.AddSeconds(59 - m_DenNgay.Second);
            m_DenNgay = m_DenNgay.AddMilliseconds(998 - m_DenNgay.Millisecond);
            if (MDDateTime.KiemTraTuNgayDenNgay(m_TuNgay, m_DenNgay))
            {
                XtraMessageBox.Show("Đến ngày >= từ ngày!", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
    }
    public class MDDateTime
    {
        //Constructor

        /// <summary>
        /// Phuong thuc tra ve chuoi thoi gian tu hai ngay nhap vao
        /// </summary>
        /// <param name="tuNgay">Ngày đầu</param>
        /// <param name="denNgay">Ngày cuối</param>
        /// <returns></returns>
        public static String LayChuoiThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            //Hai ngày giống nhau
            if (tuNgay.Day == denNgay.Day && tuNgay.Month == denNgay.Month && tuNgay.Year == denNgay.Year)
                return "Ngày " + tuNgay.Date.ToString("dd/MM/yyyy");
            //Kiểm tra tháng
            if (tuNgay.Month == denNgay.Month && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == DateTime.DaysInMonth(denNgay.Year, denNgay.Month))
                return "Tháng " + tuNgay.Date.ToString("MM/yyyy");
            //Quý 1
            if (tuNgay.Month == 1 && denNgay.Month == 3 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 31)
                return "Quí 1 Năm " + tuNgay.Year;
            //Quý 2
            if (tuNgay.Month == 4 && denNgay.Month == 6 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 30)
                return "Quí 2 Năm " + tuNgay.Year;
            //Quý 3
            if (tuNgay.Month == 7 && denNgay.Month == 9 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 30)
                return "Quí 3 Năm " + tuNgay.Year;
            //Quý 4
            if (tuNgay.Month == 10 && denNgay.Month == 12 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 31)
                return "Quí 4 Năm " + tuNgay.Year;
            //6 tháng đầu năm
            if (tuNgay.Month == 1 && denNgay.Month == 6 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 30)
                return "Sáu tháng đầu năm Năm " + tuNgay.Year;
            //6 tháng cuối năm
            if (tuNgay.Month == 7 && denNgay.Month == 12 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 31)
                return "Sáu tháng cuối năm Năm " + tuNgay.Year;
            //9 tháng đầu năm
            if (tuNgay.Month == 1 && denNgay.Month == 9 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 30)
                return "Chín tháng đầu năm Năm " + tuNgay.Year;
            //Kiểm tra năm
            if (tuNgay.Month == 1 && denNgay.Month == 12 && tuNgay.Year == denNgay.Year && tuNgay.Day == 1 && denNgay.Day == 31)
                return "Năm " + tuNgay.Year;
            //Hai ngày bất kỳ
            return "Từ ngày " + tuNgay.Date.ToString("dd/MM/yyyy") + " đến " + denNgay.Date.ToString("dd/MM/yyyy");

        }
        /// <summary>
        /// Tinh khoảng ngày
        /// </summary>
        /// <param name="tungay">Ngày bat đầu/Trả về ngày bat đầu của tuần</param>
        /// <param name="denngay">Ngày kết thúc/Trả về ngày kết thúc của tuần</param>
        public void TinhKhoangNgaySuDung(ref DateTime tungay, ref DateTime denngay)
        {

            //ngay bat dau
            if (tungay.DayOfWeek == DayOfWeek.Friday)
                tungay = tungay.AddDays(3);
            if (tungay.DayOfWeek == DayOfWeek.Saturday)
                tungay = tungay.AddDays(2);
            if (tungay.DayOfWeek == DayOfWeek.Sunday)
                tungay = tungay.AddDays(1);
            //giam ngay
            if (tungay.DayOfWeek == DayOfWeek.Thursday)
                tungay = tungay.AddDays(-3);
            if (tungay.DayOfWeek == DayOfWeek.Wednesday)
                tungay = tungay.AddDays(-2);
            if (tungay.DayOfWeek == DayOfWeek.Tuesday)
                tungay = tungay.AddDays(-1);
            //ngay ket thuc
            if (denngay.DayOfWeek == DayOfWeek.Thursday)
                denngay = denngay.AddDays(3);
            if (denngay.DayOfWeek == DayOfWeek.Friday)
                denngay = denngay.AddDays(2);
            if (denngay.DayOfWeek == DayOfWeek.Saturday)
                denngay = denngay.AddDays(1);

            //giam ngay

            if (denngay.DayOfWeek == DayOfWeek.Wednesday)
                denngay = denngay.AddDays(-3);
            if (denngay.DayOfWeek == DayOfWeek.Tuesday)
                denngay = denngay.AddDays(-2);
            if (denngay.DayOfWeek == DayOfWeek.Monday)
                denngay = denngay.AddDays(-1);
        }
        public static ArrayList LayDSTuan(ref DateTime tungay, ref DateTime denngay)
        {
            ArrayList ret = new ArrayList();
            MDDateTime dt = new MDDateTime();

            dt.TinhKhoangNgaySuDung(ref tungay, ref denngay);
            DateTime dt1 = tungay;
            DateTime dt2 = denngay;
            for (; dt1 < dt2; dt1 = dt1.AddDays(7))
            {
                ret.Add(new Tuan(dt1, dt1.AddDays(6)));
            }
            return ret;
        }
        public static ArrayList LayDSTuan(DateTime tungay, DateTime denngay)
        {
            ArrayList ret = new ArrayList();
            //  MDDateTime dt = new MDDateTime();

            //  dt.TinhKhoangNgaySuDung(ref tungay, ref denngay);
            DateTime dt1 = tungay;
            DateTime dt2 = denngay;
            //Từ ngày  -> ngày chủ nhat dau tien 
            for (; dt1 < tungay.AddDays(7); dt1 = dt1.AddDays(1))
                if (dt1.DayOfWeek == DayOfWeek.Sunday)
                    break;
            if (tungay.Date.CompareTo(dt1) < 0)
                ret.Add(new Tuan(tungay, dt1));


            //Các tuần tiếp theo
            dt1 = dt1.AddDays(1);//ngày thứ 2
            for (; dt1 <= dt2.AddDays(-7); dt1 = dt1.AddDays(7))
                ret.Add(new Tuan(dt1, dt1.AddDays(6)));



            //Ngày thứ 2 cuối cùng -> đến ngày
            if (dt1.Date.CompareTo(denngay.Date) <= 0)
                ret.Add(new Tuan(dt1, denngay));
            return ret;
        }
        public static Boolean KiemTraTuNgayDenNgay(DateTime tungay, DateTime denngay)
        {
            return (denngay < tungay);
        }
    }
    public class Tuan
    {
        public int Sott;
        public DateTime Tungay, Denngay;
        public Tuan(DateTime tungay, DateTime denngay)
        {
            Tungay = tungay;
            Denngay = denngay;
            Sott = (denngay.DayOfYear - 1) / 7 + 1;
            Tungay = Tungay.AddHours(-Tungay.Hour);
            Tungay = Tungay.AddMinutes(-Tungay.Minute);
            Tungay = Tungay.AddSeconds(-Tungay.Second);
            Tungay = Tungay.AddMilliseconds(-Tungay.Millisecond);

            Denngay = Denngay.AddHours(23 - Denngay.Hour);
            Denngay = Denngay.AddMinutes(59 - Denngay.Minute);
            Denngay = Denngay.AddSeconds(59 - Denngay.Second);
            Denngay = Denngay.AddMilliseconds(998 - Denngay.Millisecond);
        }
    }
}