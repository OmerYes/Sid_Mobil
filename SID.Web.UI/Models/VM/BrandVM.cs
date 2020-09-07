using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SID.Web.UI.Models.VM
{
    public class BrandVM:BaseVM
    {
        [Required(ErrorMessage ="Marka Adı Alanı Zorunludur")]
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string BackgroundImagePath { get; set; }

    }
}