using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class InfluencerAddressDTO
    {
        public string TypeName { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string ImgPath { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}