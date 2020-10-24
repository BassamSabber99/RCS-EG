using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.Models
{
    public class Category
    {
        public byte id { get; set; }
        public string catName { get; set; }
        public byte depId { get; set; }
        public virtual Department Department { get; set; }
    }
}