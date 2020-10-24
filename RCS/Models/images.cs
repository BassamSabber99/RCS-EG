using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.Models
{
    public class images
    {
        public int id { get; set; }
        public string ImagePath { get; set; }
        public int productId { get; set; }
        public virtual Product Product { get; set; }
    }
}