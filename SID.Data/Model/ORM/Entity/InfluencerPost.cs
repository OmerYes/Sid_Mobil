using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class InfluencerPost : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostImgPath { get; set; }
        public int InflucerID { get; set; }

        [ForeignKey("InflucerID")]
        public virtual Influencer Influencer { get; set; }

        public virtual List<PostLike> PostLikes { get; set; }
    }
}
