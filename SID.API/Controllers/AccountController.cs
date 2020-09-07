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
    public class AccountController : BaseController
    {
        public IHttpActionResult PasswordReset(PasswordResetDTO model)
        {
            if (ModelState.IsValid)
            {
                Influencer entity = unit.InfluencerRepo.FirstOrDefault(q => q.ID == model.InfluencerID);
                entity.Password = model.Password;
                unit.InfluencerRepo.SaveChanges();
            }

            return Json("");
        }
    }
}
