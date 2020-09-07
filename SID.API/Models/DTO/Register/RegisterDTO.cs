using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class RegisterDTO
    {
        [EmailAddress(ErrorMessage ="Email formatında olmalı")]
        [Required(ErrorMessage = "Lütfen email alanını doldurunuz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını doldurunuz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisim alanını doldurunuz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen şifre alanını doldurunuz")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmamaktadır")]
        public string Passwordcompare { get; set; }
    }
}