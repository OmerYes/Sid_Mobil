using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Entity
{
   public class ProductImage:Base
    {

       
        public int? ProductID { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
