using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RCS.Models;
using Microsoft.AspNet.Identity;

namespace RCS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contex;
        public HomeController()
        {
            _contex = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return Redirect("/Control/index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Announcements()
        {
            var user = User.Identity.GetUserId();
            var announce = _contex.Announcements.Where(x => x.OwnerId == user).ToList();
            if(announce.Count != 0)
            {
                for (int i = 0; i < announce.Count; i++)
                {
                    announce[i].seen = true;
                }
            }
            _contex.SaveChanges();
            List<Announcement> reverse = Enumerable.Reverse(announce).ToList();
            return View(reverse);
        }
        [Authorize]
        public ActionResult myProfile()
        {
            var id = User.Identity.GetUserId();
            var user = _contex.Users.Single(s => s.Id == id);
            return View(user);
        }
    }
}