using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
  public class InfluencerSaveProduct:Base
    {
        public int InfluencerID { get; set; }
        public int ProductID { get; set; }

        [ForeignKey("InfluencerID")]
        public virtual Influencer Influencer { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
