using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace SID.Web.UI.Models.VM
{
    public class AdminUserVM:BaseVM
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email alanı zorunludur")]
        public string Email { get; set; }
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifre alanı zorunludur")]
        public string Password { get; set; }
        [Display(Name ="İsim ve Soyisim")]
        [Required(ErrorMessage ="İsim alanı zorunludur")]
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public int? BrandID { get; set; }
        [Display(Name ="Şifre Tekrarı")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="Şifreler uyuşmamaktadır")]
        public string ConfirmPassword { get; set; }
        public List<SelectListItem> drpBrand { get; set; }
    }
}