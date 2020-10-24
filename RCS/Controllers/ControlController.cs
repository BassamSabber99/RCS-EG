using RCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RCS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ControlController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ControlController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Control
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult allClients()
        {
            return View();
        }
        public ActionResult Reject(int id)
        {
            
            var productinDB = _context.Products.Single(x => x.id == id);
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54302/api/");
            var deleteTask = client.DeleteAsync("Product/" +id.ToString());
            deleteTask.Wait();
            var announce = new Announcement()
            {
                announceTitle = "Rejected Advertise",
                seen = false,
                Date = DateTime.Now,
                description = "Your Advertise Was Rejected.Please Make Sure That Your Information About Advertise Correctly and Try Again",
                OwnerId = productinDB.ownerId,
                advertiseName = productinDB.name,
                dateAdded = productinDB.DateAdded,
                advId = id,
            };
            _context.Announcements.Add(announce);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult Accepted(int id)
        {
            var productinDB = _context.Products.Single(x => x.id == id);
            productinDB.DateAdded = DateTime.Now;
            productinDB.status = true;
            var announce = new Announcement()
            {
                announceTitle = "Accepted Advertise",
                seen = false,
                Date = DateTime.Now,
                description = "Your Advertise Was Accepted.",
                OwnerId = productinDB.ownerId,
                advertiseName = productinDB.name,
                dateAdded = productinDB.DateAdded,
            };
            _context.Announcements.Add(announce);
            _context.SaveChanges();
            return View("index");
        }
    }
}