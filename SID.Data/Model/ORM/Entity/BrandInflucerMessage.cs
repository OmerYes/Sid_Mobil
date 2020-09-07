using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class BrandInflucerMessage : Base
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int InfluencerID { get; set; }

        [ForeignKey("InfluencerID")]
        public virtual Influencer Influencer { get; set; }

        public int BrandID { get; set; }

        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }

        public bool IsBrandMessage { get; set; }
    }
}
