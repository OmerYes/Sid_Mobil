using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
   public class AdminUser:Base
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public int? BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }

    }
}
