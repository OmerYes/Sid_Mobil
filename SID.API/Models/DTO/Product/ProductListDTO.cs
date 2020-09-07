using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class ProductListDTO:BaseDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string MainImgPath { get; set; }

        public decimal UnitPrice { get; set; }

        public int StartCount { get; set; }

    }
}