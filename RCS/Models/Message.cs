using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.Models
{
    public class Message
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime? sent_date { get; set; }
        public int productId { get; set; }
        public virtual Product Product { get; set; }
        public string senderId { get; set; }
        public virtual ApplicationUser sender { get; set; }
    }
}