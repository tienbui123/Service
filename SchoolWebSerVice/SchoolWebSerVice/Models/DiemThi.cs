using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSerVice.Models
{
    public class DiemThi
    {
        string thoigian;

        public string Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }
       
        string diemTBHKHM;

        public string DiemTBHKHM
        {
            get { return diemTBHKHM; }
            set { diemTBHKHM = value; }
        }
        string diemTBHKHB;

        public string DiemTBHKHB
        {
            get { return diemTBHKHB; }
            set { diemTBHKHB = value; }
        }
        string diemTBTLHM;

        public string DiemTBTLHM
        {
            get { return diemTBTLHM; }
            set { diemTBTLHM = value; }
        }
        string diemTBTLHB;

        public string DiemTBTLHB
        {
            get { return diemTBTLHB; }
            set { diemTBTLHB = value; }
        }
        string soTCD;

        public string SoTCD
        {
            get { return soTCD; }
            set { soTCD = value; }
        }
        string soTCTL;

        public string SoTCTL
        {
            get { return soTCTL; }
            set { soTCTL = value; }
        }
        string diemRL;

        public string DiemRL
        {
            get { return diemRL; }
            set { diemRL = value; }
        }
        string loaiRL;

        public string LoaiRL
        {
            get { return loaiRL; }
            set { loaiRL = value; }
        }

        private List<MonHoc> listMH;

        public List<MonHoc> ListMH
        {
            get { return listMH; }
            set { listMH = value; }
        }

    }
}
