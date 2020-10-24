using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCS.Models;

namespace RCS.viewModels
{
    public class allProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Decimal price { get; set; }
        public string catName { get; set; }
        public string depName { get; set; }
        public string imagePath { get; set; }
    }
  
}