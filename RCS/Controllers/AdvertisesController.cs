using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using RCS.viewModels;
using RCS.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Configuration;
using RCS.Filters;

namespace RCS.Controllers
{
    [Authorize]
    [expiredAdvs]
    public class AdvertisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdvertisesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        // GET: Products
        public ActionResult Index()
        {
            var prod = new List<allProduct>();
            foreach(var pro in _context.Products.Include(s=>s.Category).Where(x=>x.status == true).ToList())
            {
                var name = _context.images.First(c => c.productId == pro.id).ImagePath.Split('\\');
                var ins = new allProduct()
                {
                    id = pro.id,
                    name = pro.name,
                    catName = pro.Category.catName,
                    depName = pro.Category.Department.depName,
                    price = pro.price,
                    imagePath = name[name.Length - 1],
                };
                prod.Add(ins);
            };
            return View(prod);
        }
        public ActionResult makeAdvertise()
        {
            string userId = User.Identity.GetUserId();
            var Owner = _context.Users.FirstOrDefault(s => s.Id == userId);
            var viewmode = new productViewModel()
            {

                Departments = _context.Departments.ToList(),
                Categories = null,
                ownerName = Owner.UserName,
                ownerEmail = Owner.Email,
                ownerPhone = Owner.PhoneNumber
            };
            return View("AdvertiseForm", viewmode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult save(productViewModel pvm)
        {
            string userId = User.Identity.GetUserId();
            var Owner = _context.Users.FirstOrDefault(s => s.Id == userId);
            if (pvm.ImageFile[0] != null)
            {
                string Extensions = "png,jpg,jpeg";
                List<string> allowedExtensions = Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int i = 0; i < pvm.ImageFile.Length; i++)
                {
                    if (!allowedExtensions.Any(y => pvm.ImageFile[i].FileName.EndsWith(y)) || pvm.ImageFile[i].ContentLength > 3145728 || pvm.price <= 0)
                    {
                        pvm.Departments = _context.Departments.ToList();
                        pvm.ownerName = Owner.UserName;
                        pvm.ownerEmail = Owner.Email;
                        pvm.ownerPhone = Owner.PhoneNumber;
                        return View("AdvertiseForm", pvm);
                    }
                }
            }
            var product = new Product();
            if (pvm.id == 0)
            {
                product.name = pvm.name;
                product.Category = _context.Categories.SingleOrDefault(x => x.id == pvm.CategoryID);
                product.catid = pvm.CategoryID;
                product.description = pvm.description;
                product.address = pvm.address;
                product.price = pvm.price;
                product.ownerId = userId;
                product.status = false;
                product.DateAdded = null;
                _context.Products.Add(product);
            }
            else
            {
               
                product =  _context.Products.Single(x=>x.id == pvm.id);
                product.name = pvm.name;
                product.Category = _context.Categories.SingleOrDefault(x => x.id == pvm.CategoryID);
                product.catid = pvm.CategoryID;
                product.description = pvm.description;
                product.address = pvm.address;
                product.price = pvm.price;
                product.ownerId = userId;
                product.status = false;
                product.DateAdded = null;
                if (pvm.ImageFile[0] != null)
                {
                    var images = _context.images.Where(x => x.productId == pvm.id).ToList();
                    for (int i = 0; i < images.Count; i++)
                    {
                        if (System.IO.File.Exists(images[i].ImagePath))
                        {
                            System.IO.File.Delete(images[i].ImagePath);
                            _context.images.Remove(images[i]);
                        }
                    }
                }
                            
                
           }

        if (pvm.ImageFile[0] != null)
        {
            for (int i = 0; i < pvm.ImageFile.Length; i++)
            {
                string FileName = Path.GetFileNameWithoutExtension(pvm.ImageFile[i].FileName);
                string FileExtension = Path.GetExtension(pvm.ImageFile[i].FileName);
                var count = i + 1;
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + pvm.name + "-" + count + FileExtension;
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                pvm.ImagePath = UploadPath + FileName;
                pvm.ImageFile[i].SaveAs(pvm.ImagePath);
                var image = new images();
                image.ImagePath = pvm.ImagePath;
                image.productId = product.id;
                _context.images.Add(image);

            }
        }
            
               
            

                _context.SaveChanges();
            return RedirectToAction("myAdvertises");
        }
        public ActionResult showDetails(int id)
        {
          
            try
            {
                
                var pro = _context.Products.Include(x=>x.owner).Single(x => x.id == id);
                var product = new detailsViewModel()
                {
                    id = pro.id,
                    productname = pro.name,
                    address = pro.address,
                    catName = pro.Category.catName,
                    depName = pro.Category.Department.depName,
                    description = pro.description,
                    price = pro.price,
                    owner = pro.owner,
                    imagePath = new List<string>(),
                    state = pro.status,
                };

                var imagesPath = _context.images.Where(x => x.productId == pro.id).Select(x => x.ImagePath).ToList();

                for (int i = 0; i < imagesPath.Count; i++)
                {
                    var file_name = imagesPath[i].Split('\\');
                    product.imagePath.Add(file_name[file_name.Length - 1]);
                }
                if (User.IsInRole("Admin") && pro.status == false)
                {
                    return View(product);
                }
                else if (pro.status == false)
                {
                    return RedirectToAction("index");
                }
                return View(product);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }
        
        public ActionResult Edit(int id)
        {
            string userId = User.Identity.GetUserId();
            var Owner = _context.Users.FirstOrDefault(s => s.Id == userId);
            var product = new Product();
            product = _context.Products.Include(s=>s.Category).Single(i => i.id == id);
            var viewmodel = new productViewModel()
            {
                id = product.id,
                name = product.name,
                price = product.price,
                ownerEmail = Owner.Email,
                ownerName = Owner.UserName,
                ownerPhone = Owner.PhoneNumber,
                address = product.address,
                CategoryID = product.catid,
                DepartmentID = product.Category.depId,
                Categories = null,
                Departments = _context.Departments.ToList(),
                description = product.description,
                
            };
            return View("AdvertiseForm", viewmodel);
        }
        public ActionResult myAdvertises()
        {
            return View();
        }
    }
}

