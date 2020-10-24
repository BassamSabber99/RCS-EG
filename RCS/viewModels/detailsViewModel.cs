using RCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.viewModels
{
    public class detailsViewModel
    {
        public int id { get; set; }
        public string productname { get; set; }
        public Decimal price { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string catName { get; set; }
        public string depName { get; set; }
        public List<string> imagePath { get; set; }
        public ApplicationUser owner { get; set; }
        public Boolean state { get; set; }
        /*
        public string ownername { get; set; }
        public string phone { get; set; }
        public string email { get; set; }*/
    }
}