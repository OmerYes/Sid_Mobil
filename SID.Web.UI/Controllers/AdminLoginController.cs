using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SID.Data.Model.ORM.Entity;
using SID.Data.Model.ORM.Context;
using SID.Business.Manager.Repository;
using SID.Web.UI.Models.VM;
using System.Web.Security;

namespace SID.Web.UI.Controllers
{
   
    public class AdminLoginController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(AdminUserVM model)
        {
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.Email.ToLower() == model.Email.ToLower() && q.Password == model.Password);
            if (adminuser != null)
            {
                FormsAuthentication.SetAuthCookie(model.Email,true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
           

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}