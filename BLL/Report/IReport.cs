using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_HeThong
{
   public interface IReport
    {
        void RefeshData(DateTime tuNgay, DateTime denNgay);
        void RefeshData();
        void ExportExcel();
        void Preview();
        string Title();
        void ShowDetail();
        void Exit();
        void Load();

    }
}
