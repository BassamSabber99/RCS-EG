using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RCS.Models;
using RCS.Dtos;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace RCS.Controllers.api
{
    public class MessageController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MessageController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet] 
        public IHttpActionResult GetMessages(int? productId)
        {
            return Ok(_context.Messages.Include(x=>x.sender).Where(x => x.productId == productId).ToList());
        }
        [HttpPost]
        public IHttpActionResult CreateMessage(MessageDto msgDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var sender = _context.Users.Single(x => x.Id == msgDto.senderid);
            var message = new Message();
            message.productId = msgDto.productid;
            message.senderId = msgDto.senderid;
            message.sender = sender;
            message.sent_date = DateTime.Now;
            message.content = msgDto.content;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + message.id), message);
        }
    }
}
