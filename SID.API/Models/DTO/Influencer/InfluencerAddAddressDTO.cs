using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class InfluencerAddAddressDTO
    {
        public int InfluencerID { get; set; }
        public int RegionID { get; set; }
        public string TypeName { get; set; }
        public string Street { get; set; }
        public string District { get; set; }

    }
}