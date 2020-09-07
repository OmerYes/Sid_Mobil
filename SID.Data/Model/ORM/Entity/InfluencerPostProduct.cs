using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
   public class InfluencerPostProduct:Base
    {
        public int ProductID { get; set; }
        public int InfluencerPostID { get; set; }

        public string Title { get; set; }

        public string Style { get; set; }

        public string Description { get; set; }

        [ForeignKey("InfluencerPostID")]
        public virtual InfluencerPost InfluencerPost { get; set; }
    }
}
