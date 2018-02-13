using KeysOnboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeysOnboarding.Controllers
{
    public class ProductController : Controller
    {
        DatabaseContext dbContext;

        public ProductController()
        {
            dbContext = new DatabaseContext();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(dbContext.Products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

            return View(product);
        } 

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var productDetails = dbContext.Products.FirstOrDefault(x => x.Id == product.Id);
            productDetails.Name = product.Name;
            productDetails.Price = product.Price;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var details = dbContext.Products.FirstOrDefault(x => x.Id == id);

            return View(details);
        }

        public ActionResult Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var productDetails = dbContext.Products.FirstOrDefault(x => x.Id == product.Id);
            dbContext.Products.Remove(productDetails);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}