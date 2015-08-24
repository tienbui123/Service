using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
namespace SchoolWebSerVice.Models
{
    public class GetHTML
    {
        static string url = "http://thongtindaotao.sgu.edu.vn/default.aspx?";


        public static List<ThoiKhoaBieu> getTKB(string url)
        {

            HtmlWeb htmlWeb = new HtmlWeb();
            List<ThoiKhoaBieu> tkbs = new List<ThoiKhoaBieu>();
            HtmlDocument document = htmlWeb.Load(url);
            // dòng 1 
            HtmlNodeCollection nodes;
            //nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]/table[1]/table[1]/table[1]/table[1]");
            //if (nodes != null)
            //{
            //    ThoiKhoaBieu tkb = new ThoiKhoaBieu();
            //    for (int j = 1; j <= 15; j++)
            //    {

            //        HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]/table[1]/table[1]/table[1]/table[1]/tr/td[" + j + "]");
            //        foreach (var node in nodes1)
            //        {
            //            switch (j)
            //            {
            //                case 1:
            //                    tkb.MaMH = node.InnerText;
            //                    break;
            //                case 2:
            //                    tkb.TenMH = node.InnerText;
            //                    break;
            //                case 3:
            //                    tkb.NhomMH = node.InnerText;
            //                    break;
            //                case 4:
            //                    tkb.SoTC = node.InnerText;
            //                    break;
            //                case 5:
            //                    tkb.MaLop = node.InnerText;
            //                    break;
            //                case 9:
            //                    tkb.ThuTuan = node.InnerText;
            //                    break;
            //                case 10:
            //                    tkb.TietBD = node.InnerText;
            //                    break;
            //                case 11:
            //                    tkb.SoTiet = node.InnerText;
            //                    break;
            //                case 12:
            //                    tkb.Phong = node.InnerText;
            //                    break;
            //                case 13:
            //                    tkb.CBGD = node.InnerText;
            //                    break;
            //                case 14:
            //                    tkb.Tuan = node.InnerText;
            //                    break;
            //            }
            //        }
            //    }
            //    tkbs.Add(tkb);
            //}

             //all
            string s = "/table[1]";
            //int k=1;
            do
            {

                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]"+s);
                //nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]/table["+k+"]");
                if (nodes != null)
                {

                    ThoiKhoaBieu tkb = new ThoiKhoaBieu();
                    for (int j = 1; j <= 15; j++)
                    {

                        HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]"+s+"/tr/td[" + j + "]");
                        //HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]"/table["+k+"] /tr/td[" + j + "]");
                        foreach (var node in nodes1)
                        {
                            switch (j)
                            {
                                case 1:
                                    tkb.MaMH = node.InnerText;
                                    break;
                                case 2:
                                    tkb.TenMH = node.InnerText;
                                    break;
                                case 3:
                                    tkb.NhomMH = node.InnerText;
                                    break;
                                case 4:
                                    tkb.SoTC = node.InnerText;
                                    break;
                                case 5:
                                    tkb.MaLop = node.InnerText;
                                    break;

                                case 9:
                                    tkb.ThuTuan = node.InnerText;
                                    break;
                                case 10:
                                    tkb.TietBD = node.InnerText;
                                    break;
                                case 11:
                                    tkb.SoTiet = node.InnerText;
                                    break;
                                case 12:
                                    tkb.Phong = node.InnerText;
                                    break;
                                case 13:
                                    tkb.CBGD = node.InnerText;
                                    break;
                                case 14:
                                    tkb.Tuan = node.OuterHtml.Substring(node.OuterHtml.IndexOf("tuan('") + 6, 22);
                                    break;
                            }
                        }
                    }
                    tkbs.Add(tkb);
                }
              //  k++;
                s += "/table[1]";
            }
            while (nodes != null);
            return tkbs;
        }




        public static List<LichThi> getLichThi(string url)
        {
            List<LichThi> listlt = new List<LichThi>();
            HtmlWeb htmlWeb = new HtmlWeb();



            HtmlDocument document = htmlWeb.Load(url);

            HtmlNodeCollection nodes;
            int k = 2;
            do
            {
                nodes = null;
                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_gvXem']/tr[" + k + "]");

                if (nodes != null)
                {

                    LichThi lt = new LichThi();
                    lt.HinhThuc = "Tu luan";
                    for (int j = 1; j <= 12; j++)
                    {
                        HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_gvXem']/tr[" + k + "]/td[" + j + "]");
                        foreach (var node in nodes1)
                        {
                            switch (j)
                            {
                                case 2:
                                    lt.MaMH = node.InnerText;
                                    break;
                                case 3:
                                    lt.TenMH = node.InnerText;
                                    break;
                                case 4:
                                    lt.GhepThi = node.InnerText;
                                    break;
                                case 5:
                                    lt.ToThi = node.InnerText;
                                    break;
                                case 6:
                                    lt.SoLuong = node.InnerText;
                                    break;

                                case 7:
                                    lt.NgayThi = node.InnerText;
                                    break;
                                case 8:
                                    lt.GioBD = node.InnerText;
                                    break;
                                case 9:
                                    lt.SoPhut = node.InnerText;
                                    break;
                                case 10:
                                    lt.Phong = node.InnerText;
                                    break;
                               

                            }
                        }
                    }
                    listlt.Add(lt);
                }
                k++;
            }
            while (nodes != null);


            return listlt;
        }

       public static List<DiemThi> getDiemThi(string url)
        {
            List<DiemThi> listdt = new List<DiemThi>();
            DiemThi dT = new DiemThi();
            List<MonHoc> listMH = new List<MonHoc>();
            HtmlWeb htmlWeb = new HtmlWeb();


            HtmlDocument document = htmlWeb.Load(url);

            HtmlNodeCollection nodes;
            int k = 2;
            int i = 0;
            do
            {
                nodes = null;
                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td/span");

                if (nodes != null)
                {
                    

                    if (k == 2)
                    {
                        dT.Thoigian = nodes.First().InnerText;
                    }
                    else if (nodes.Count == 2)
                    {
                        HtmlNodeCollection node = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td/span[2]");
                        i++;
                        switch (i)
                        {
                            case 1:
                                dT.DiemTBHKHM = node.First().InnerText;
                                break;
                            case 2:
                                dT.DiemTBHKHB = node.First().InnerText;
                                break;
                            case 3:
                                dT.DiemTBTLHM = node.First().InnerText;
                                break;
                            case 4:
                                dT.DiemTBTLHB = node.First().InnerText;
                                break;
                            case 5:
                                dT.SoTCD = node.First().InnerText;
                                break;
                            case 6:
                                dT.SoTCTL = node.First().InnerText;
                                break;
                            case 7:
                                dT.DiemRL = node.First().InnerText;
                                break;
                            case 8:
                                dT.LoaiRL = node.First().InnerText;
                                break;
                        }
                    }
                    else
                    {
                        MonHoc mH = new MonHoc();
                        for (int j = 1; j <= 10; j++)
                        {
                            HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td[" + j + "]/span");
                          
                            foreach (var node in nodes1)
                            {
                                switch (j)
                                {
                                    case 2:
                                        mH.MaMH = node.InnerText;
                                        break;
                                    case 3:
                                        mH.TenMH = node.InnerText;
                                        break;
                                    case 4:
                                        mH.SoTC = node.InnerText;
                                        break;
                                    case 5:
                                        mH.PhanTramKT = node.InnerText;
                                        break;
                                    case 6:
                                        mH.PhanTramThi = node.InnerText;
                                        break;
                                    case 7:
                                        mH.DiemKT = node.InnerText;
                                        break;
                                    case 8:
                                        mH.ThiL1 = node.InnerText;
                                        break;
                                    case 9:
                                        mH.TongDiem = node.InnerText;
                                        break;
                                    case 10:
                                        mH.TongDiemChu = node.InnerText;
                                        break;

                                }
                            }
                        }
                        listMH.Add(mH);
                    }
                }
                k++;
            }
            while (nodes != null);
            dT.ListMH = listMH;
            listdt.Add(dT);
            return listdt;
        }

        



        public static string makeUrlTKB(string msv)
        {
            string data = url + "page=thoikhoabieu&sta=1&id=" + msv;

            return data;
        }
        public static string makeUrlDT(string msv)
        {
            string data = url + "page=xemdiemthi&id=" + msv;

            return data;
        }
        public static string makeUrlLT(string msv)
        {
            string data = url + "page=xemlichthi&sta=1&id=" + msv;

            return data;
        }


    }
}