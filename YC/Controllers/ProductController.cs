using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Models;

namespace YC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDataProvider productDataProvider;
        private bool isSuccess = false;
        public ProductController(IProductDataProvider productDataProvider)
        {
            this.productDataProvider = productDataProvider;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [Route("AddProduct/89696FC7-661E-449E-9884-37915787CF2C")]
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [Route("AddProduct/89696FC7-661E-449E-9884-37915787CF2C")]
        [HttpPost]
        public ActionResult CreateNewProduct(dynamic prod)
        {
            Product product = new Product
            {
                Name = prod.ProductName,
                ImageUrl = prod.ImgUrl,
                CategoryId = int.Parse(prod.SelectedCategory),
                AmazonInUrl = prod.AmazonUrl,
                AmazonInPrice = decimal.Parse(prod.AmazonPrice),
                PaytmUrl = prod.PaytmUrl,
                PaytmPrice = decimal.Parse(prod.PaytmPrice)
            };

            isSuccess = productDataProvider.CreateNewProduct(product);
            return View();
        }
    }
}