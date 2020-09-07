using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class InfluencerAdresses : Base
    {
        public string TypeName { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public int RegionID { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }

        public int InfluencerID { get; set; }

        [ForeignKey("InfluencerID")]
        public virtual Influencer Influencer { get; set; }
    }
}
