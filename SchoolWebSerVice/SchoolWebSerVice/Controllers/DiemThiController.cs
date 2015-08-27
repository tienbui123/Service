using SchoolWebSerVice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolWebSerVice.Controllers
{
    public class DiemThiController : ApiController
    {
        //
        // GET: /DiemThi/


        
        public IEnumerable<DiemThi> GetDiemThi(string id)
        {
            return   GetHTML.getDiemThi(id);
        }
    }
}
