using Newtonsoft.Json;
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
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            List<ProductVM> model = unit.ProductRepo.GetAllQuery().Select(q => new ProductVM()
            {
                BarcrodeNumber = q.BarcrodeNumber,
                Name = q.Name,
                Price = q.Price,
                UnitsInStock = q.UnitsInStock,
                ID = q.ID,
                CommissionRate=q.CommissionRate

            }).ToList();

            return View(model);
        }



        public JsonResult SaveCommissionRateDatabase(ProductVM model)
        {
            var result = false;
            
                    Product product = unit.ProductRepo.FirstOrDefault(q => q.ID == model.ID);
                    product.CommissionRate = model.CommissionRate;
                    unit.Save();
                    result = true;
                
          

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProduct()
        {
            return View(GetProductVM());
        }

        [HttpPost]
        public ActionResult AddProduct(ProductVM model, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryID = model.CategoryID;
                product.BrandID = 1;
                product.UnitsInStock = model.UnitsInStock;

                Product returnentity = unit.ProductRepo.Add(product);

                if (files != null)
                {
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            string GuidKey = Guid.NewGuid().ToString();
                            var filename = GuidKey + InputFileName;


                            var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Products/") + filename);
                            file.SaveAs(ServerSavePath);

                            ProductImage productimage = new ProductImage();
                            productimage.Path = filename;
                            productimage.ProductID = returnentity.ID;

                            unit.ProductImageRepo.Add(productimage);

                        }

                    }
                }

            }
            return View(GetProductVM());
        }

        public ProductVM GetProductVM()
        {
            ProductVM model = new ProductVM();
            model.drpCategories = unit.CategoryRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();

            return model;
        }

        public JsonResult DeleteProduct(int id)
        {
            var entity = unit.ProductRepo.Delete(id);
            return Json("");
        }

        public ActionResult UpdateProduct(int id)
        {
            Product product = unit.ProductRepo.FirstOrDefault(q => q.ID == id); 
            ProductVM model = new ProductVM();
            model.ID = product.ID;
            model.Name = product.Name;
            model.Price = product.Price;
            model.UnitsInStock = product.UnitsInStock;
            model.CategoryID = product.CategoryID;
            model.drpCategories = unit.CategoryRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();
            model.ImgPathList = unit.ProductImageRepo.GetAllQuerableWithQuery(q => q.ProductID == product.ID).Select(q => q.Path).ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductVM model, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                Product product = unit.ProductRepo.FirstOrDefault(q => q.ID == model.ID);
                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryID = model.CategoryID;
                product.BrandID = 1;
                product.UnitsInStock = model.UnitsInStock;

                unit.Save(); ;

                if (files != null)
                {
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            string GuidKey = Guid.NewGuid().ToString();
                            var filename = GuidKey + InputFileName;


                            var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Products/") + filename);
                            file.SaveAs(ServerSavePath);

                            ProductImage productimage = new ProductImage();
                            productimage.Path = filename;
                            productimage.ProductID = product.ID;

                            unit.ProductImageRepo.Add(productimage);

                        }

                    }
                }

            }
            return View(model);
        }
    }
}