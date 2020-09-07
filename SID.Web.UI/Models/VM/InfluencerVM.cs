using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.Web.UI.Models.VM
{
    public class InfluencerVM:BaseVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string ImagePath { get; set; }
        public int? BranadID { get; set; }
        public string Brand { get; set; }
    }
}