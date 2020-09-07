using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class PostLike : Base
    {
        public int InfluencerID { get; set; }

        public int PostID { get; set; }

        [ForeignKey("PostID")]
        public virtual InfluencerPost InfluencerPost { get; set; }
    }
}
