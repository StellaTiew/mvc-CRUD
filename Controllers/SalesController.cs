using KeysOnboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeysOnboarding.Controllers
{
    public class SalesController : Controller
    {
        DatabaseContext dbContext;

        public SalesController()
        {
            dbContext = new DatabaseContext();
        }

        // GET: Sales
        public ActionResult Index()
        {
            
            return View(dbContext.ProductSold);
        }

        public ActionResult Create()
        {
            var products = new ProductSoldRepository();
            var productsList = products.GetSales();
            return View(productsList);
        }

        [HttpPost]
        public ActionResult Create(ProductSold productSold)
        {
            dbContext.ProductSold.Add(productSold);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var sales = dbContext.ProductSold.FirstOrDefault(x => x.Id == id);
            var products = new ProductSoldRepository();
            var productsList = products.GetSelectedSales(sales.Id, sales.ProductId, sales.CustomerId, sales.StoreId, sales.DateSold);
            return View(productsList);
        }

        [HttpPost]
        public ActionResult Edit(ProductSold productSold)
        {
            var details = dbContext.ProductSold.FirstOrDefault(x => x.Id == productSold.Id);
            details.ProductId = productSold.ProductId;
            details.CustomerId = productSold.CustomerId;
            details.StoreId = productSold.StoreId;
            details.DateSold = productSold.DateSold;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var details = dbContext.ProductSold.FirstOrDefault(x => x.Id == id);

            return View(details);
        }

        public ActionResult Delete(int id)
        {
            var details = dbContext.ProductSold.FirstOrDefault(x => x.Id == id);

            return View(details);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var details = dbContext.ProductSold.FirstOrDefault(x => x.Id == customer.Id);
            dbContext.ProductSold.Remove(details);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}