using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = context.Customers.Include(x=>x.membershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(x => x.membershipType).SingleOrDefault(x => x.Id == id);

             return View(customer);
        }
    }
}