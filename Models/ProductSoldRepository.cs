using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeysOnboarding.Models
{
    public class ProductSoldRepository
    {
        public ProductSold GetSales()
        {
            var product = new Product();
            var customer = new Customer();
            var store = new Store();
            var sales = new ProductSold()
            {
                Customers = customer.GetCustomers(),
                Products = product.GetProducts(),
                Stores = store.GetStores()
            };
            return sales;
        }

        public ProductSold GetSelectedSales(int id, int productId, int customerId, int storeId, DateTime? dateSold)
        {
            var product = new Product();
            var customer = new Customer();
            var store = new Store();
            var sales = new ProductSold()
            {
                Customers = customer.GetCustomers(),
                Products = product.GetProducts(),
                Stores = store.GetStores(),
                ProductId = productId,
                CustomerId = customerId,
                StoreId = storeId,
                DateSold = dateSold
            };
            return sales;

        }
    }
}