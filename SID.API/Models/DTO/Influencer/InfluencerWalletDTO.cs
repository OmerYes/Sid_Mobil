using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SID.API.Models.DTO
{
    public class InfluencerWalletDTO:BaseDTO
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string ImgPath { get; set; }
    }
}