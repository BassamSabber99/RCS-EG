using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RCS.Models;
using System.Data.Entity;
using System.IO;
namespace RCS.Controllers.api
{
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IHttpActionResult GetProducts(string id)
        {
            return Ok(_context.Products.Include(c=>c.Category).Where(x=>x.ownerId==id).ToList());
        }
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(_context.Products.Include(c => c.Category).Where(x => x.status == false).ToList());
        }
       
        

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var images = _context.images.Where(x => x.productId == id).ToList();
            for(int i = 0; i < images.Count; i++)
            {
                if (File.Exists(images[i].ImagePath))
                {
                    File.Delete(images[i].ImagePath);
                }
             
            }
            
            var product = new Product();
            product = _context.Products.Single(x => x.id == id); 
            /*
            var announcement = _context.Announcements.Where(x=>x.advId == product.id).ToList();
            if(announcement.Count != 0)
            {
                for(int i = 0; i < announcement.Count; i++)
                {
                    _context.Announcements.Remove(announcement[i]);
                }
            }
            */
            var announce = new Announcement()
            {
                announceTitle = "Deleted Advertise",
                seen = false,
                Date = DateTime.Now,
                description = "Your Advertise Was Deleted Becuase It's Expiry Date Has Been Finished Without Renew It.",
                OwnerId = product.ownerId,
                advId = id,
                advertiseName = product.name,
                dateAdded = product.DateAdded,
            };
            var messages = _context.Messages.Where(x => x.productId == id).ToList();
            for (int i = 0; i < messages.Count; i++) {
                _context.Messages.Remove(messages[i]);
            }
            _context.Products.Remove(product);
            _context.Announcements.Add(announce);
            _context.SaveChanges();
            return Ok();
        }
    }
}
