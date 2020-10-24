using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCS.Dtos
{
    public class MessageDto
    {
        public int productid { get; set; }
        public string senderid { get; set; }
        public string content { get; set; }
    }
}