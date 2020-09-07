using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class ProductDetailDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> ImgPaths { get; set; }
        public bool IsSaved { get; set; }
    }
}