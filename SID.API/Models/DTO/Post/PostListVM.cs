using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class PostListVM : BaseDTO
    {
        public string InfluencerImgPath { get; set; }

        public string PostPath { get; set; }

        public int LikeCount { get; set; }

        public string FullName { get; set; }

        public int InfluencerID { get; set; }
        public bool IsLiked { get; set; }
    }
}