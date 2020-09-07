using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class InfluencerAccountDTO
    {
        public string FullName { get; set; }

        public string ImgPath { get; set; }

        public int FollowingUsersCount { get; set; }

        public int FollowerUserCount { get; set; }
    }
}