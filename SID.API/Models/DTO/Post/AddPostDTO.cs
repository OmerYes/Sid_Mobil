using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class AddPostDTO:BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int InfluencerID { get; set; }
     
    }
}