using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltHotel_WS.Controllers
{
    public class ProductsController : ApiController
    {
        //public void GetAllProducts()
        //{
        //    ;
        //}


        [HttpGet]
        public Product FindProduct(int id)
        {
            return new Product(1, "Test1");
        }

        public IEnumerable<Product> GetProductById(int id)
        {
            return new List<Product>() { new Product(1, "Test1"), new Product(1, "Test2")};
        }
        //public HttpResponseMessage DeleteProduct(int id) { }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
