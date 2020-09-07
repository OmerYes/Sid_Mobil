using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Controllers
{
    public class FinancialController : BaseController
    {
        // GET: Financial
        public ActionResult Index()
        {
            return View();
        }
    }
}