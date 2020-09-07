using SID.Business.Manager.Repository;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork unit;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.Email.ToLower() == User.Identity.Name);
            if (adminuser!= null)
            {
                ViewBag.AdminUserID = adminuser.ID;

            }
            ViewBag.AdminUserID = 2;
            ViewBag.AdminUser = User.Identity.Name;
        }

        public BaseController()
        {
            unit = new UnitOfWork();
        }

        protected override void Dispose(bool disposing)
        {
            unit.Dispose();
            base.Dispose(disposing);
        }
    }
}