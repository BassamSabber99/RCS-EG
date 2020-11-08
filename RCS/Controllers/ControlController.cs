using RCS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

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
            var productinDB = _context.Products.Include(s=>s.owner).Single(x => x.id == id);
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

            /*
            var senderEmail = new MailAddress("bassamsabber@gmail.com", "RCS | Resturant And Cafe Services");
            var receiverEmail = new MailAddress(productinDB.owner.Email, productinDB.owner.UserName);//bassamsabber@yahoo.com
            var password = "Ba2589764321";
            var sub = "Deleted Advertise";
            string body = string.Empty;
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/AnnouncementPage.html")))
            {
                body = sr.ReadToEnd();
            }
            body = body.Replace("{name}", productinDB.owner.UserName);
            body = body.Replace("{content}", "I Would Be To Inform You That Your Advertise <b>{advname}</b> Expired And Deleted . With My Besy Wishes RCS");
            body = body.Replace("{advname}", productinDB.name);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail) { Subject = sub, Body = body })
            {
                mess.IsBodyHtml = true;
                smtp.Send(mess);
            }
            */

            _context.SaveChanges();
            return View("index");
        }
    }
}