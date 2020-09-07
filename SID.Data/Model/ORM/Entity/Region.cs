using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
    public class Region : Base
    {
        public string Name { get; set; }

        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual City City { get; set; }
    }
}
