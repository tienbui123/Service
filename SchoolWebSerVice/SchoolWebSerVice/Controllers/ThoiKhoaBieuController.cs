using SchoolWebSerVice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SchoolWebSerVice.Controllers
{
    public class ThoiKhoaBieuController : ApiController
    {
        //
        // GET: /ThoiKhoaBieu/

       
         public IEnumerable<ThoiKhoaBieu> GetThoiKhoaBieu(string id)
         {
             return GetHTML.getTKB(GetHTML.makeUrlTKB(id));
         }

    }
}
