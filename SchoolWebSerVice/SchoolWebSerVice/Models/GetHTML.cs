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

       public static List<DiemThi> getDiemThi(string id)
        {
            List<DiemThi> listdt = new List<DiemThi>();
            DiemThi dT = new DiemThi();
            List<MonHoc> listMH = new List<MonHoc>();


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
                        dT.ListMH = listMH;
                        listdt.Add(dT);
                        dT = new DiemThi();
                        listMH = new List<MonHoc>();
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
                                i=1;
                                
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

       public static string getAllDiem(string id)
       {
           //const string baseUrl = @"http://thongtindaotao.sgu.edu.vn/Default.aspx?page=xemdiemthi&id=3110410023";
           const string baseUrl = @"http://thongtindaotao.sgu.edu.vn";

           CookieContainer _cookieJar = new CookieContainer();

           var client = new RestClient(baseUrl);
           var request = new RestRequest("/Default.aspx")
           {
               AlwaysMultipartFormData = true,
               Method = Method.GET,
           };

           //request.AddParameter("page", "test", ParameterType.RequestBody);
           request.AddParameter("page", "xemdiemthi");
           request.AddParameter("id", id);

           //client.CookieContainer = _cookieJar;

           IRestResponse response = client.Execute(request);
           var content = response.Content;

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
           request.AddParameter("__VIEWSTATE", "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", ParameterType.GetOrPost);

           client.CookieContainer = _cookieJar;

           response = client.Execute(request);
           content = response.Content;

           return content;
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