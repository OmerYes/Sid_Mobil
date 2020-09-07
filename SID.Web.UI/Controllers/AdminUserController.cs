using SID.Data.Model.ORM.Entity;
using SID.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Controllers
{
    public class AdminUserController : BaseController
    {
        // GET: AdminUser

            public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddAdminUser()
        {
            return View(GetAdminUserVM());
        }
        [HttpPost]
        public ActionResult AddAdminUser(AdminUserVM model,HttpPostedFileBase AdminUserImage)
        {
            if (ModelState.IsValid && AdminUserImage!=null)
            {
                AdminUser adminUser = new AdminUser();

                string filename = Path.GetFileNameWithoutExtension(AdminUserImage.FileName).ToLower();
                string ex = Path.GetExtension(AdminUserImage.FileName);

                if (AdminUserImage.ContentLength < 2097152)
                {
                    string guid = Guid.NewGuid().ToString();
                    string sqllogo = "/Content/AdminUser/" + guid + ex;
                    filename = Path.Combine(Server.MapPath(sqllogo));
                    AdminUserImage.SaveAs(filename);

                    adminUser.ImagePath = sqllogo;
                    adminUser.Email = model.Email;
                    adminUser.FullName = model.FullName;
                    adminUser.Password = model.Password;
                    adminUser.BrandID = model.BrandID;
                    adminUser.AddDate = DateTime.Now;
                    unit.AdminUserRepo.Add(adminUser);
                    TempData["IslemDurum"] = "Success";
                }

                else
                {
                    ModelState.AddModelError("", "Profil Resmi 7MB boyutunu geçemez");
                    ViewBag.IslemDurum = "ModelStateError";
                }



            }
            else
            {
                ModelState.AddModelError("", "Lütfen zorunlu alanları doldunuruz!");
                ViewBag.IslemDurum = "ModelStateError";
            }

            return View(GetAdminUserVM());
        }

        public ActionResult UpdateAdminUser(int id)
        {
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.ID == id);

            AdminUserVM model = GetAdminUserVM();
            model.Email = adminuser.Email;
            model.FullName = adminuser.FullName;
            model.BrandID = adminuser.BrandID ?? 0;
            model.ID = adminuser.ID;


            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateAdminUser(AdminUserVM model, HttpPostedFileBase AdminUserImage)
        {
            if (ModelState.IsValid && AdminUserImage!=null)
            {

                AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.ID == model.ID);

                System.IO.File.Delete(Server.MapPath(adminuser.ImagePath));
                adminuser.ImagePath = null;
                string filename = Path.GetFileNameWithoutExtension(AdminUserImage.FileName).ToLower();
                string ex = Path.GetExtension(AdminUserImage.FileName);


                if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                {
                    string guid = Guid.NewGuid().ToString();
                    string sqllogo = "/Content/Adminuser/" + guid + ex;
                    filename = Path.Combine(Server.MapPath(sqllogo));
                    AdminUserImage.SaveAs(filename);
                    adminuser.ImagePath = sqllogo;
                    adminuser.FullName = model.FullName;
                    adminuser.Password = model.Password;
                    adminuser.BrandID = model.BrandID;
                    adminuser.Email = model.Email;
                    unit.Save();
                    TempData["IslemDurum"] = "Success";
                    return View(GetAdminUserVM());
                }
                else
                {
                    ModelState.AddModelError("", "Profil Resmi jpeg, png uzantılı eklenebilir. Lütfen değiştiriniz!");
                    ViewBag.IslemDurum = "ModelStateError";
                }


               
            }

            else
            {
                ModelState.AddModelError("", "Lütfen zorunlu alanları doldunuruz!");
                ViewBag.IslemDurum = "ModelStateError";
            }

            
            return View(GetAdminUserVM());
        }
            


   

        public AdminUserVM GetAdminUserVM()
        {
            AdminUserVM model = new AdminUserVM();
            model.drpBrand = unit.BrandRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString(),
                
            }).ToList();
            return model;
        }

       
       
    }
}