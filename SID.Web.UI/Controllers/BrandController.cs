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
    public class BrandController : BaseController
    {
        // GET: Brand
        public ActionResult Index()
        {
            List<BrandVM> model = unit.BrandRepo.GetAllQuery().Select(q => new BrandVM()
            {
                Name = q.Name,
                ID = q.ID,
                AddDate = q.AddDate,
                LogoPath = q.LogoPath

            }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddBrand()
        {
            //BrandVM model = new BrandVM();
            return View();
        }

        [HttpPost]
        public ActionResult AddBrand(BrandVM model)
        {
            if (ModelState.IsValid )
            {
                Brand brand = new Brand();
               
                        brand.Name = model.Name;
                        brand.AddDate = DateTime.Now;
                        unit.BrandRepo.Add(brand);
                        TempData["IslemDurum"] = "Success";
                        return RedirectToAction("Index");
                    
            }
            else
            {
                ModelState.AddModelError("", "Lütfen zorunlu alanları doldunuruz!");
                ViewBag.IslemDurum = "ModelStateError";
            }
            return View();
           
        }

        public JsonResult DeleteBrand(int id)
        {
            var entity = unit.BrandRepo.Delete(id);
            return Json("");
        }
        [HttpGet]
        public ActionResult UpdateBrand(int id)
        {
            Brand brand = unit.BrandRepo.FirstOrDefault(q => q.ID == id);
            BrandVM model = new BrandVM();
            model.ID = brand.ID;
            model.Name = brand.Name;
            model.LogoPath = brand.LogoPath;

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateBrand(BrandVM model, HttpPostedFileBase logo)
        {
            Brand brand = unit.BrandRepo.FirstOrDefault(q => q.ID == model.ID);

            if ( brand != null)
            {
                if (ModelState.IsValid && logo!=null)
                {
                  
                    
                        System.IO.File.Delete(Server.MapPath(brand.LogoPath));
                        brand.LogoPath = null;

                        string filename = Path.GetFileNameWithoutExtension(logo.FileName).ToLower();
                        string ex = Path.GetExtension(logo.FileName);

                        if (logo.ContentLength < 2097152)
                        {
                            if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                            {
                                string guid = Guid.NewGuid().ToString();
                                string sqllogo = "/Content/Brand/" + guid + ex;
                                filename = Path.Combine(Server.MapPath(sqllogo));
                                logo.SaveAs(filename);

                                brand.LogoPath = sqllogo;
                                brand.Name = model.Name;
                                unit.Save();
                                TempData["IslemDurum"] = "Success";
                                return RedirectToAction("Index");
                            }

                            else
                            {
                                ModelState.AddModelError("", "Logo jpeg, png uzantılı eklenebilir. Lütfen değiştiriniz!");
                                ViewBag.IslemDurum = "ModelStateError";
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Logo 7MB boyutunu geçemez");
                            ViewBag.IslemDurum = "ModelStateError";
                        }
                    
                 

                }

                else
                {
                    ModelState.AddModelError("", "Lütfen zorunlu alanları doldunuruz!");
                    ViewBag.IslemDurum = "ModelStateError";
                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult AddBrandLogo(int id)
        {
            
            return View(GetAdminUserBrand(id));
        }
        [HttpPost]
        public ActionResult AddBrandLogo(BrandVM model,HttpPostedFileBase logo)
        {
            if (logo != null)
            {
                Brand brand = unit.BrandRepo.FirstOrDefault(q => q.ID == model.ID);
                string filename = Path.GetFileNameWithoutExtension(logo.FileName).ToLower();
                string ex = Path.GetExtension(logo.FileName);
                if (logo.ContentLength < 2097152)
                {
                    if(ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqllogo = "/Content/Brand/" + guid + ex;
                        filename = Path.Combine(Server.MapPath(sqllogo));
                        logo.SaveAs(filename);
                        brand.LogoPath = sqllogo;
                        unit.Save();
                        TempData["IslemDurum"] = "Success";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ResimUzanti = "LogoUzanti";
                    }
                }
                else
                {
                    ViewBag.ResimBoyutu = "LogoBoyutu";
                }
            }

            else
            {
                
                ViewBag.ResimDurum = "LogoDurum";
            }

            return View();
        }
        [HttpGet]
        public ActionResult AddBackGroundImage(int id)
        {
            return View(GetAdminUserBrand(id));
        }
        [HttpPost]
        public ActionResult AddBackGroundImage(BrandVM model, HttpPostedFileBase BackgroundImage)
        {
            if (BackgroundImage != null)
            {
                Brand brand = unit.BrandRepo.FirstOrDefault(q => q.ID == model.ID);
                string filename = Path.GetFileNameWithoutExtension(BackgroundImage.FileName).ToLower();
                string ex = Path.GetExtension(BackgroundImage.FileName);
                if (BackgroundImage.ContentLength < 2097152)
                {
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqllogo = "/Content/Brand/" + guid + ex;
                        filename = Path.Combine(Server.MapPath(sqllogo));
                        BackgroundImage.SaveAs(filename);
                        brand.BackgroundImagePath = sqllogo;
                        unit.Save();
                        TempData["IslemDurum"] = "Success";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ResimUzanti = "BackGroundImageUzanti";
                    }
                }
                else
                {
                    ViewBag.ResimBoyutu = "BackGroundImageBoyutu";
                }
            }

            else
            {

                ViewBag.ResimDurum = "BackGroundImageDurum";
            }

            return View();
        }

        public BrandVM GetAdminUserBrand(int id)
        {
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.ID == id);
            BrandVM model = new BrandVM();
            model.ID = adminuser.BrandID;
            return model;
        }
    }

    
}