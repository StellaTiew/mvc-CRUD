using KeysOnboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeysOnboarding.Controllers
{
    public class CustomerController : Controller
    {
        DatabaseContext dbContext;

        public CustomerController()
        {
            dbContext = new DatabaseContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(dbContext.Customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.Id == id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerDetails = dbContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
            customerDetails.Name = customer.Name;
            customerDetails.Address = customer.Address;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var details = dbContext.Customers.FirstOrDefault(x => x.Id == id);

            return View(details);
        }

        public ActionResult Delete(int id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.Id == id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var customerDetails = dbContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
            dbContext.Customers.Remove(customerDetails);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}