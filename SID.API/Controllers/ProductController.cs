using SID.API.Models.DTO;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SID.API.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            List<ProductListDTO> model = unit.ProductRepo.GetAllQuery().Select(q => new ProductListDTO()
            {
                ID=q.ID,
                Title = q.Name,
                Description=q.Description,
                MainImgPath = q.MainProductImgPath,
                StartCount = q.StartCount,
                UnitPrice = q.Price

                
            }).ToList();

            return Json(model);
        }

       
        [HttpGet]
        public IHttpActionResult GetProductDetail(int id,int id2)
        {
            ProductDetailDTO model = new ProductDetailDTO();
            Product product = unit.ProductRepo.FirstOrDefault(q => q.ID == id);
            model.Title = product.Name;
            model.Description = product.Description;
            model.ImgPaths = unit.ProductImageRepo.GetAllQuerableWithQuery(q => q.ProductID == id).Select(q => q.Path).ToList();
           if(unit.InfluencerSaveProductRepo.FirstOrDefault(q=>q.ProductID==id && q.InfluencerID == id2) != null)
            {
                model.IsSaved = true;
            }
            else
            {
                model.IsSaved = false;
            }
            return Json(model);
        }

        [HttpGet]
        public IHttpActionResult SaveProduct(int id,int id2)
        {
            SaveProductDTO model = new SaveProductDTO();
            InfluencerSaveProduct influencerSaveProduct = unit.InfluencerSaveProductRepo.FirstOrDefaultAll(q => q.ProductID == id && q.InfluencerID == id2);

            if (influencerSaveProduct == null)
            {
                InfluencerSaveProduct saveProduct = new InfluencerSaveProduct();
                saveProduct.ProductID = id;
                saveProduct.InfluencerID = id2;
                unit.InfluencerSaveProductRepo.Add(saveProduct);
                unit.Save();
                model.IsSaved = true;
                return Json(model);

                
            }
            else if (influencerSaveProduct.IsDeleted==true)
            {
                influencerSaveProduct.IsDeleted = false;
                unit.InfluencerSaveProductRepo.Update(influencerSaveProduct);
                unit.Save();
                model.IsSaved = true;
                return Json(model);
            }

            else 
            {
                influencerSaveProduct.IsDeleted = true;
                unit.InfluencerSaveProductRepo.Update(influencerSaveProduct);
                unit.Save();
                model.IsSaved = false;
                return Json(model);
            }
           
            
        }

        [HttpGet]
        public IHttpActionResult GetSaveProduct(int id)
        {
            List<GetSavedProductDTO> model = unit.InfluencerSaveProductRepo.GetAllQuerableWithQuery(q => q.InfluencerID == id).Select(q => new GetSavedProductDTO()
            {
                ProductID = q.ProductID,
                ProductImagePath = q.Product.MainProductImgPath.ToString(),
            }).ToList();

            return Ok(model);
        }
        [HttpGet]
        public IHttpActionResult GetPostproduct(int id)
        {
            PostProductDTO model = new PostProductDTO();
            InfluencerSaveProduct influencerSaveProduct = unit.InfluencerSaveProductRepo.FirstOrDefault(q => q.ProductID == id);
            model.ProductImagePath = influencerSaveProduct.Product.MainProductImgPath.ToString();
            return Ok(model);
                
        }
    }
}
