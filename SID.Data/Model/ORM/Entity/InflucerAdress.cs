using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class InflucerAddress : Base
    {
        public string Adress { get; set; }

        public int InflucerID { get; set; }

        [ForeignKey("InflucerID")]
        public virtual Influencer Influencer { get; set; }
    }
}
