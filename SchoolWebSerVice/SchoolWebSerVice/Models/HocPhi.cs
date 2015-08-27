using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSerVice.Models
{
    public class HocPhi
    {

        private string thoiGian;

        public string ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
        }

        private string tongSoTC;

        public string TongSoTC
        {
            get { return tongSoTC; }
            set { tongSoTC = value; }
        }

        private string tongSoTien;

        public string TongSoTien
        {
            get { return tongSoTien; }
            set { tongSoTien = value; }
        }

        private string tienDongTTLD;

        public string TienDongTTLD
        {
            get { return tienDongTTLD; }
            set { tienDongTTLD = value; }
        }

        private string tienDaDong;

        public string TienDaDong
        {
            get { return tienDaDong; }
            set { tienDaDong = value; }
        }

        private string tienConNo;

        public string TienConNo
        {
            get { return tienConNo; }
            set { tienConNo = value; }
        }

        private List<CTHocPhi> listCTHP;

        public List<CTHocPhi> ListCTHP
        {
            get { return listCTHP; }
            set { listCTHP = value; }
        }
    }
}
