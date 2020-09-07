using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class Brand:Base
    {
        public string LogoPath { get; set; }

        public string BackgroundImagePath { get; set; }
        public string Name { get; set; }
        [ForeignKey("BrandID")]
        public virtual List<BrandUser> BrandUsers { get; set; }
       
        public virtual List<Product> Products { get; set; }
        public virtual List<AdminUser> AdminUsers { get; set; }


    }
}
