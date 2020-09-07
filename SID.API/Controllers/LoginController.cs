using SID.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SID.API.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        public IHttpActionResult LoginControl(LoginDTO model)
        {
            var result = unit.InfluencerRepo.FirstOrDefault(q => q.Email.ToLower() == model.EMail.ToLower() && q.Password == model.Password );
            if (result!=null)
            {
                return Ok(result.ID);
            }

            return NotFound();
        }
    }
}
