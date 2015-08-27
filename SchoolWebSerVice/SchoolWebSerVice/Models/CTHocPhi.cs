using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSerVice.Models
{
    public class CTHocPhi
    {
        private string maNhom;

        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
        private string hocPhi;

        public string HocPhi
        {
            get { return hocPhi; }
            set { hocPhi = value; }
        }
        private string mienGiam;

        public string MienGiam
        {
            get { return mienGiam; }
            set { mienGiam = value; }
        }
        private string phaiDong;

        public string PhaiDong
        {
            get { return phaiDong; }
            set { phaiDong = value; }
        }
        public MonHoc monHoc;
    }
}
