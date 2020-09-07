using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SID.Web.UI.Models.VM
{
    public class ProductVM : BaseVM
    {
        [Required]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; }

        [Display(Name="Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Barkod Numarası")]
        public string BarcrodeNumber { get; set; }
        public double CommissionRate { get; set; }

        public int? CategoryID { get; set; }
        public int? BrandID { get; set; }

        [Display(Name="Stok Adet")]
        public int UnitsInStock { get; set; }

        public List<SelectListItem> drpCategories { get; set; }

        public HttpPostedFileBase[] files { get; set; }

        public List<string> ImgPathList { get; set; }
    }
}