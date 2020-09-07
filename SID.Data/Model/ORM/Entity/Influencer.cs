using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
  public class Influencer:Base
    {
        public string Name { get; set; }

        public string Password { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string ImagePath { get; set; }
        public string Phone { get; set; }
        public int ActivationCode { get; set; }
        public bool IsActive { get; set; }

    }
}
