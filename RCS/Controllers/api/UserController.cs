using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RCS.Models;

namespace RCS.Controllers.api
{
    public class UserController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
            
        }
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = from u in _context.Users.ToList()
                        join p in _context.Products.ToList()
                        on u.Id equals p.ownerId
                        select new
                        {
                            userName = u.UserName,
                            PhoneNumber = u.PhoneNumber,
                            address = u.address,
                            Email = u.Email,
                            id = u.Id,
                            count = _context.Products.Where(x=>x.ownerId == u.Id).ToList().Count,
                        };
            return Ok(users.Distinct());
        }
    }
}
