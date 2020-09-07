using SID.Business.Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SID.API.Controllers
{
    public class BaseController : ApiController
    {
        public UnitOfWork unit;
        public BaseController()
        {
            unit = new UnitOfWork();
        }
    }
}
