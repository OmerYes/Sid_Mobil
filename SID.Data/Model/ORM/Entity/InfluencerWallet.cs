using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
   public class InfluencerWallet:Base
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int InfluencerID { get; set; }
        [ForeignKey("InfluencerID")]
        public virtual Influencer Influencer { get; set; }
    }
}
