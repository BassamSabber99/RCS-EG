using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;
using RCS.Models;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace RCS.Filters
{
    public class expiredAdvsAttribute:ActionFilterAttribute
    {
        private readonly ApplicationDbContext _context;
        public expiredAdvsAttribute()
        {
            _context = new ApplicationDbContext();
        }
       
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var product = _context.Products.ToList();
            if(product.Count != 0)
            {
                for (int i = 0; i < product.Count; i++)
                {
                    if (product[i].DateAdded != null && DateTime.Now.Year == Convert.ToDateTime(product[i].DateAdded.ToString()).Year && DateTime.Now.Month > Convert.ToDateTime(product[i].DateAdded.ToString()).Month && DateTime.Now.Day - Convert.ToDateTime(product[i].DateAdded.ToString()).Day == 0)
                    {
                        Delete(product[i].id);

                        var senderEmail = new MailAddress("bassamsabber@gmail.com", "RCS | Resturant And Cafe Services");
                        var receiverEmail = new MailAddress(product[i].owner.Email, product[i].owner.UserName);//bassamsabber@yahoo.com
                        var password = "Ba2589764321";
                        var sub = "Deleted Advertise";
                        string body = string.Empty;
                        using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/AnnouncementPage.html")))
                        {
                            body = sr.ReadToEnd();
                        }
                        body = body.Replace("{name}", product[i].owner.UserName);
                        body = body.Replace("{content}", "I Would Be To Inform You That Your Advertise <b>{advname}</b> Expired And Deleted . With My Besy Wishes RCS");
                        body = body.Replace("{advname}", product[i].name);
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

                    }
                    else if (product[i].DateAdded != null && DateTime.Now.Year == Convert.ToDateTime(product[i].DateAdded.ToString()).Year && DateTime.Now.Month > Convert.ToDateTime(product[i].DateAdded.ToString()).Month && Math.Abs(DateTime.Now.Day - Convert.ToDateTime(product[i].DateAdded.ToString()).Day) <= 7)
                    {
                        /*
                        var announcements = _context.Announcements.Where(x => x.productid == productID && x.announceTitle == "Renew Your Advertise").ToList();
                      
                        if (announcements.Count == 0)
                        {
                            var days =  Convert.ToDateTime(product[i].DateAdded.ToString()).Day - DateTime.Now.Day;
                            var announce = new Announcement();
                            announce.announceTitle = "Renew Your Advertise";
                            announce.description = $"Please Renew Your Advertise Because It Be Deleted in {days}-days.";
                            announce.Date = DateTime.Now;
                            announce.productid = product[i].id;
                            announce.OwnerId = product[i].ownerId;
                            announce.seen = false;
                            _context.Announcements.Add(announce);
                        }*/

                        var productID = product[i].id;
                        var announcements = _context.Announcements.Where(x => x.advId == productID ).ToList();
                        if (announcements.Count == 0)
                        {
                            var days =Math.Abs(Convert.ToDateTime(product[i].DateAdded.ToString()).Day - DateTime.Now.Day);
                            var announce = new Announcement();
                            announce.announceTitle = "Renew Your Advertise";
                            announce.description = $"Please Renew Your Advertise Because It Will Be Deleted in {days}-days.";
                            announce.Date = DateTime.Now;
                            announce.advertiseName = product[i].name;
                            announce.dateAdded = product[i].DateAdded;
                            announce.OwnerId = product[i].ownerId;
                            announce.advId = productID;
                            announce.seen = false;
                            _context.Announcements.Add(announce);

                            var senderEmail = new MailAddress("bassamsabber@gmail.com", "RCS | Resturant And Cafe Services");
                            var receiverEmail = new MailAddress(product[i].owner.Email, product[i].owner.UserName);//bassamsabber@yahoo.com
                            var password = "Ba2589764321";
                            var sub = "Renew Advertise";
                            string body = string.Empty;
                            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/AnnouncementPage.html")))
                            {
                                body = sr.ReadToEnd();
                            }
                            body = body.Replace("{name}",product[i].owner.UserName);
                            body = body.Replace("{content}", "I Would Be To Inform You That Your Advertise <b>{advname}</b> Will Be Expire In {days}-days So Please Renew It Before Removed.<br /> With My Besy Wishes RCS");
                            body = body.Replace("{advname}",product[i].name);
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

                        }
                    }
                    _context.SaveChanges();
                   
                }
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            log("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            log("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            log("OnActionExecuted", filterContext.RouteData);
        }
        private void log(string methodName,RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,controllerName,actionName);
            Debug.WriteLine(message);
        }
        public void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54302/api/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Product/" + id.ToString());
                deleteTask.Wait();
            }
        }
        ~expiredAdvsAttribute()
        {
            _context.Dispose();
        }
    }
}