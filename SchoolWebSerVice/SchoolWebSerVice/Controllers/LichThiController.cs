using SchoolWebSerVice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SchoolWebSerVice.Controllers
{
    public class LichThiController : ApiController
    {
        //
        // GET: /LichThi/

      
        public IEnumerable<LichThi> GetLichThi(string id)
        {
            return GetHTML.getLichThi(GetHTML.makeUrlLT(id));
        }

    }
}
