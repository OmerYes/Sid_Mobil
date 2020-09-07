using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
   public class Product:Base
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string BarcrodeNumber { get; set; }
        public int UnitsInStock { get; set; }
        public int? CategoryID { get; set; }
        public double CommissionRate { get; set; }
        public int? BrandID { get; set; }
        public string MainProductImgPath { get; set; }
        public int StartCount { get; set; }
        public virtual Brand Brand { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<InfluencerSaveProduct> InfluencerSaveProducts { get; set; }

    }
}
