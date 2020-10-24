using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public Decimal price { get; set; }
        public string ownerId { get; set; }
        public virtual ApplicationUser owner { get; set; }
        public byte catid { get; set; }
        public virtual Category Category { get; set; }
        public Boolean status { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}