using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class InfluencerFollow : Base
    {
        public int InfluencerFollowingID { get; set; }
        public int InfluencerFollowerID { get; set; }
    }
}
