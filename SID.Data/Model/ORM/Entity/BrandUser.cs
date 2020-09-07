using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class BrandUser:Base
    {
        public string Email { get; set; }
        public string SurName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Name { get; set; }
        public int? BrandID { get; set; }
       
        public virtual Brand Brand { get; set; }
    }
}
