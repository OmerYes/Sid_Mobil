using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class PostProductDTO:BaseDTO
    {
        public string ProductImagePath { get; set; }

        public int ProductID { get; set; }

        public int PostID { get; set; }

        public string Title { get; set; }

        public string Style { get; set; }

        public string Description { get; set; }
    }
}