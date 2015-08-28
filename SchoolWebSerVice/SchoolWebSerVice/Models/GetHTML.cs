using HtmlAgilityPack;
using RestSharp;
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
            //all
            //string s = "/table[1]";
            int k=1;
            do
            {

                //nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]" + s);
                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]/table["+k+"]");
                if (nodes != null)
                {

                    ThoiKhoaBieu tkb = new ThoiKhoaBieu();
                    for (int j = 1; j <= 15; j++)
                    {

                       // HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]" + s + "/tr/td[" + j + "]");
                        HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_pnlHeader']/table/tr[2]/td/div[2]/table["+k+"] /tr/td[" + j + "]");
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
                  k++;
                //s += "/table[1]";
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

        public static List<DiemThi> getDiemThi(string id)
        {
            List<DiemThi> listdt = new List<DiemThi>();
            DiemThi dT = new DiemThi();
            List<DiemMon> listDM = new List<DiemMon>();


            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(getAllDiem(id));

            HtmlNodeCollection nodes;
            int k = 2;
            int i = 1;
            do
            {
                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td/span");

                if (nodes != null)
                {


                    if (nodes.Count == 1)
                    {
                        dT.ListDM = listDM;
                        listdt.Add(dT);
                        dT = new DiemThi();
                        listDM = new List<DiemMon>();
                        dT.Thoigian = nodes.First().InnerText;
                    }
                    else if (nodes.Count == 2)
                    {
                        HtmlNodeCollection node = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td/span[2]");

                        switch (i)
                        {
                            case 1:
                                dT.DiemTBHKHM = node.First().InnerText;
                                i++;
                                break;
                            case 2:
                                dT.DiemTBHKHB = node.First().InnerText;
                                i++;
                                break;
                            case 3:
                                dT.DiemTBTLHM = node.First().InnerText;
                                i++;
                                break;
                            case 4:
                                dT.DiemTBTLHB = node.First().InnerText;
                                i++;
                                break;
                            case 5:
                                dT.SoTCD = node.First().InnerText;
                                i++;
                                break;
                            case 6:
                                dT.SoTCTL = node.First().InnerText;
                                i++;
                                break;
                            case 7:
                                dT.DiemRL = node.First().InnerText;
                                i++;
                                break;
                            case 8:
                                dT.LoaiRL = node.First().InnerText;
                                i = 1;

                                break;
                        }

                    }
                    else
                    {
                        DiemMon dm = new DiemMon();
                        for (int j = 1; j <= 10; j++)
                        {
                            HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_div1']/table/tr[" + k + "]/td[" + j + "]/span");

                            foreach (var node in nodes1)
                            {
                                switch (j)
                                {
                                    case 2:
                                        dm.MaMH = node.InnerText;
                                        break;
                                    case 3:
                                        dm.TenMH = node.InnerText;
                                        break;
                                    case 4:
                                        dm.SoTC = node.InnerText;
                                        break;
                                    case 5:
                                        dm.PhanTramKT = node.InnerText;
                                        break;
                                    case 6:
                                        dm.PhanTramThi = node.InnerText;
                                        break;
                                    case 7:
                                        dm.DiemKT = node.InnerText;
                                        break;
                                    case 8:
                                        dm.ThiL1 = node.InnerText;
                                        break;
                                    case 9:
                                        dm.TongDiem = node.InnerText;
                                        break;
                                    case 10:
                                        dm.TongDiemChu = node.InnerText;
                                        break;

                                }
                            }
                        }
                        listDM.Add(dm);
                    }
                }
                k++;
            }
            while (nodes != null);
            dT.ListDM = listDM;
            listdt.Add(dT);
            listdt.Remove(listdt[0]);
            return listdt;
        }
        public static string getAllDiem(string id)
        {

            const string baseUrl = @"http://thongtindaotao.sgu.edu.vn";

            CookieContainer _cookieJar = new CookieContainer();

            var client = new RestClient(baseUrl);
            var request = new RestRequest("/Default.aspx")
            {
                AlwaysMultipartFormData = true,
                Method = Method.GET,
            };

            request.AddParameter("page", "xemdiemthi");
            request.AddParameter("id", id);

            IRestResponse response = client.Execute(request);
            string content = response.Content;
            // get view state
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);
            HtmlNode node = document.DocumentNode.SelectSingleNode("//*[@id='__VIEWSTATE']");
            string viewState = node.Attributes["value"].Value;

            //get cookie
            var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "ASP.NET_SessionId");
            if (sessionCookie != null)
            {
                _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
            }

            request = new RestRequest("/Default.aspx")
            {
                AlwaysMultipartFormData = true,
                Method = Method.POST,
            };

            request.AddParameter("page", "xemdiemthi", ParameterType.QueryString);
            request.AddParameter("id", id, ParameterType.QueryString);
            request.AddParameter("__EVENTTARGET", "ctl00$ContentPlaceHolder1$ctl00$lnkChangeview2", ParameterType.GetOrPost);
            request.AddParameter("__VIEWSTATE", viewState, ParameterType.GetOrPost);

            client.CookieContainer = _cookieJar;

            response = client.Execute(request);
            content = response.Content;

            return content;
        }

        public static HocPhi getHocPhi()
        {
            HocPhi hocPhi = new HocPhi();
            DiemThi dT = new DiemThi();
            List<CTHocPhi> listCT = new List<CTHocPhi>();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(getTrangHocPhi());

            HtmlNode nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblNHHKOnline']");
            hocPhi.ThoiGian = nodeHP.InnerText;
            nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_SoTinChiHP']");
            hocPhi.TongSoTC = nodeHP.InnerText;
            nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblphaiDong']");
            hocPhi.TongSoTien = nodeHP.InnerText;
            nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblDongLanDau1']");
            hocPhi.TienDongTTLD = nodeHP.InnerText;
            nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblDaDongHKOffline']");
            hocPhi.TienDaDong = nodeHP.InnerText;
            nodeHP = document.DocumentNode.SelectSingleNode("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblConNoHocKy']");
            hocPhi.TienConNo = nodeHP.InnerText;

            HtmlNodeCollection nodes;
            int k = 2;
            do
            {

                nodes = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_gvHocPhi']/tr[" + k + "]/td[3]/span");

                if (nodes != null)
                {
                    CTHocPhi ct = new CTHocPhi();
                    MonHoc monHoc = new MonHoc();
                    for (int j = 2; j <= 10; j++)
                    {
                        HtmlNodeCollection nodesChiTiet = document.DocumentNode.SelectNodes("//*[@id='ctl00_ContentPlaceHolder1_ctl00_gvHocPhi']/tr[" + k + "]/td[" + j + "]/span");
                        foreach (HtmlNode node in nodesChiTiet)
                        {
                            switch (j)
                            {
                                case 2:
                                    monHoc.MaMH = node.InnerText;
                                    break;
                                case 3:
                                    monHoc.TenMH = node.InnerText;
                                    break;
                                case 4:
                                    ct.MaNhom = node.InnerText;
                                    break;
                                case 6:
                                    monHoc.SoTC = node.InnerText;
                                    break;
                                case 8:
                                    ct.HocPhi = node.InnerText;
                                    break;
                                case 9:
                                    ct.MienGiam = node.InnerText;
                                    break;
                                case 10:
                                    ct.PhaiDong = node.InnerText;
                                    break;


                            }
                        }
                    }
                    ct.monHoc = monHoc;
                    listCT.Add(ct);
                }
                k++;
            }
            while (nodes != null);

            hocPhi.ListCTHP = listCT;
            return hocPhi;
        }
        public static string getTrangHocPhi()
        {

            const string baseUrl = @"http://thongtindaotao.sgu.edu.vn";

            CookieContainer _cookieJar = new CookieContainer();
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/Default.aspx")
            {
                AlwaysMultipartFormData = true,
                Method = Method.GET,
            };

            request.AddParameter("page", "dangnhap");
            IRestResponse response = client.Execute(request);
            // get view state
            string content = response.Content;
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);
            HtmlNode node = document.DocumentNode.SelectSingleNode("//*[@id='__VIEWSTATE']");
            string viewState = node.Attributes["value"].Value;

            //get cookie
            var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "ASP.NET_SessionId");
            if (sessionCookie != null)
            {
                _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
            }

            request = new RestRequest("/Default.aspx")
           {
               AlwaysMultipartFormData = true,
               Method = Method.POST,
           };

            request.AddParameter("page", "dangnhap", ParameterType.QueryString);


            request.AddParameter("__VIEWSTATE", viewState, ParameterType.GetOrPost);
            request.AddParameter("ctl00$ContentPlaceHolder1$ctl00$txtTaiKhoa", "3111410089", ParameterType.GetOrPost);
            request.AddParameter("ctl00$ContentPlaceHolder1$ctl00$txtMatKhau", "secret01", ParameterType.GetOrPost);
            request.AddParameter("ctl00$ContentPlaceHolder1$ctl00$btnDangNhap", "Đăng Nhập", ParameterType.GetOrPost);
            client.CookieContainer = _cookieJar;
            response = client.Execute(request);

            request = new RestRequest("/Default.aspx")
            {
                AlwaysMultipartFormData = true,
                Method = Method.GET,
            };
            request.AddParameter("page", "xemhocphi", ParameterType.QueryString);
            client.CookieContainer = _cookieJar;

            response = client.Execute(request);
            content = response.Content;

            return content;
        }
        
        public static List<User> getUser(string id)
        {
            List<User> list = new List<User>();
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument document = htmlWeb.Load(makeUrlTKB(id));
            HtmlNodeCollection node1 = document.DocumentNode.SelectNodes(string.Format("//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblContentTenSV']"));
            HtmlNode node = node1.First();
            User user = new User();
            user.Id = id;
            user.Name = node.InnerText.Trim();
            user.Password = "";
            list.Add(user);
            return list;
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