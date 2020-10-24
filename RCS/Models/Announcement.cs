using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace RCS.Models
{
    public class Announcement
    {
        public int id { get; set; }
        public string announceTitle { get; set; }
        public string description { get; set; }
        public DateTime? Date { get; set; }
        public Boolean seen { get; set; }
        public string OwnerId { get; set; }
        public int advId { get; set; }
        public string advertiseName { get; set; }
        public DateTime? dateAdded { get; set; }
    }
}