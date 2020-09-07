using SID.API.Models.Attributes;
using SID.API.Models.DTO;
using SID.Data.Model.ORM.Entity;
using SID.Sms.DTO;
using SID.Sms.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SID.API.Controllers
{
    public class RegisterController : BaseController
    {
        [ValidateModelAttribute]
        [HttpPost]
        public IHttpActionResult Register(RegisterDTO model)
        {
            if (unit.InfluencerRepo.FirstOrDefault(q => q.Email == model.Email) == null)
            {

                Random rnd = new Random();
                int activationcode = rnd.Next(100000,999999);                 
                Influencer influencer = new Influencer();
                influencer.Email = model.Email;
                influencer.Name = model.Name;
                influencer.SurName = model.Surname;
                influencer.Password = model.Password;
                influencer.IsActive = false;
                influencer.ActivationCode = activationcode;

                unit.InfluencerRepo.Add(influencer);
                unit.Save();

                Influencer influencermodel = unit.InfluencerRepo.FirstOrDefaultCore(q => q.Email == influencer.Email);

                return Ok(influencermodel.ID);

            }

            else
            {
                return NotFound();
            }
        }

        [ValidateModelAttribute]
        [HttpPost]
        public IHttpActionResult Registerwithtel(RegisterwithtelDTO model)
        {
            model.Phone = model.Code + model.Tel;
            if (unit.InfluencerRepo.FirstOrDefault(q => q.Phone == model.Phone) == null)
            {
                Random rnd = new Random();
                int activationcode = rnd.Next(100000, 999999);
                Influencer influencer = new Influencer();
                influencer.Phone = model.Phone;
                influencer.Name = model.Name;
                influencer.SurName = model.Surname;
                influencer.Password = model.Password;
                influencer.IsActive = false;
                influencer.ActivationCode = activationcode;
               
                unit.InfluencerRepo.Add(influencer);
                unit.Save();
                //Sms gönderme alanı
                SMSDTO sMSDTO = new SMSDTO();
                sMSDTO.PhoneNumber = influencer.Phone;
                sMSDTO.Content = (influencer.ActivationCode).ToString();
                SmsManager.SendSMS(sMSDTO);
                Influencer influencermodel = unit.InfluencerRepo.FirstOrDefaultCore(q => q.Phone == influencer.Phone);

                return Ok(influencermodel.ID);

            }

            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult ActivateUser(ActivateuserDTO activateuser)
        {
            Influencer model = unit.InfluencerRepo.FirstOrDefaultCore(q => q.ID == activateuser.ID && q.ActivationCode == activateuser.ActivationCode);
                if (model != null)
            {
                model.IsActive = true;
                unit.InfluencerRepo.Update(model);
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
