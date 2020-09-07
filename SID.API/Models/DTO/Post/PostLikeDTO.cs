using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class PostLikeDTO:BaseDTO
    {
        public int PostID { get; set; }
        public int LikeCount { get; set; }
        public bool IsLiked { get; set; }
    }
}