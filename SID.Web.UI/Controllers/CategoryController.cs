using SID.Data.Model.ORM.Entity;
using SID.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            List<CategoryVM> model = unit.CategoryRepo.GetAllQuery().Select(q => new CategoryVM()
            {
                Name = q.Name,
                Description = q.Description,
                ID = q.ID,
                AddDate = q.AddDate
            }).ToList();

            return View(model);
        }
        public ActionResult AddCategory()
        {
           
            return View(new CategoryVM());
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;

                unit.CategoryRepo.Add(category);
            }
            return View();

        }

        public ActionResult UpdateCategory(int id)
        {
            Category category = unit.CategoryRepo.FirstOrDefault(q => q.ID == id);
            CategoryVM model = new CategoryVM();
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            
            return View(model);

        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = unit.CategoryRepo.FirstOrDefault(q => q.ID == model.ID);
                category.Name = model.Name;
                category.Description = model.Description;
               
                unit.Save();

            }
            return View(model);
        }

        public JsonResult DeleteCategory(int id)
        {
            unit.CategoryRepo.Delete(id);
            return Json("");
        }

    }
}