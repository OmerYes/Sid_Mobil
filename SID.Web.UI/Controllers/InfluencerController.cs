using SID.Data.Model.ORM.Entity;
using SID.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Controllers
{
    public class InfluencerController : BaseController
    {
        public ActionResult Index()
        {

            List<InfluencerVM> model = unit.InfluencerRepo.GetAllQuery().Select(q => new InfluencerVM() 
            {
                
                Name = q.Name,
                SurName = q.SurName,
                Email = q.Email,
                Facebook = q.Facebook,
                Instagram = q.Instagram,
                Twitter = q.Twitter,
                ImagePath = q.ImagePath,

            }).ToList();
            return View(model);
        }

        public ActionResult InfluencerSearch(string arama)
        {

            List<InfluencerVM> model = unit.InfluencerRepo.GetAllQuery().Select(q => new InfluencerVM()
            {

                Name = q.Name,
                ImagePath=q.ImagePath,
                SurName=q.SurName


            }).Where(q => q.Name.ToLower() == arama).ToList();

            if (model.Count == 0)
            {
                TempData["AramaSonuc"] = "SonucBulunamadı";
              return  RedirectToAction("Index","Influencer");
            }
            return View("Index",model);

        }
    }
}