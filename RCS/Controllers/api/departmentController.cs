using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RCS.Models;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace RCS.Controllers.api
{
    public class departmentController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public departmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetDepPro(string depName)
        {
            var query = from p in _context.Products.ToList()
                        join i in _context.images.ToList() on
                        p.id equals i.productId
                        select new
                        {
                            id = p.id,
                            nam = p.name,
                            price = p.price,
                            dep = p.Category.Department.depName,
                            cat = p.Category.catName,
                            image = i.ImagePath,
                        };
            if (depName == "All")
            {
                return Ok(query.ToList().DistinctBy(x=>x.id));
            }
            else
            {
                query = from i in _context.images.ToList()
                        join p in _context.Products.ToList() on
                        i.productId equals p.id
                        where p.Category.Department.depName == depName
                        select new
                        {
                            id = p.id,
                            nam = p.name,
                            price = p.price,
                            dep = p.Category.Department.depName,
                            cat = p.Category.catName,
                            image = i.ImagePath
                        };
            }
            return Ok(query.ToList().DistinctBy(x => x.id));

        }


        [HttpGet]
        public IHttpActionResult GetCatPro(string catName)
        {
            
                var query = from i in _context.images.ToList()
                        join p in _context.Products.ToList() on
                        i.productId equals p.id
                        where p.Category.catName == catName
                        select new
                        {
                            id = p.id,
                            nam = p.name,
                            price = p.price,
                            dep = p.Category.Department.depName,
                            cat = p.Category.catName,
                            image = i.ImagePath
                        };
           
            return Ok(query.ToList().DistinctBy(x => x.id));

        }


        [HttpGet]
        public IHttpActionResult getCategory(int depid)
        {
            return Ok(_context.Categories.Where(x=>x.depId == depid).ToList());
        }


    }
}
