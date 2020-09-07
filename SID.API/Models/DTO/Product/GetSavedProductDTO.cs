using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class GetSavedProductDTO
    {
        public int ProductID { get; set; }
        public string ProductImagePath { get; set; }
    }
}