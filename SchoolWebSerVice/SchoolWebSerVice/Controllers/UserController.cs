﻿using SchoolWebSerVice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SchoolWebSerVice.Controllers
{
    public class UserController : ApiController
    {
        //
        // GET: /User/

        public IEnumerable<User> GetUser(string id)
        {
            return GetHTML.getUser(id);
        }

    }
}
