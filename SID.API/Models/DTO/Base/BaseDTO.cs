using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class BaseDTO
    {
        public int ID { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }

    }
}