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
        public ActionResult CreateNewProduct(dynamic _product)
        {
            Product product = new Product
            {
                Name = _product.ProductName,
                ImageUrl = _product.ImgUrl,
                CategoryId = int.Parse(_product.AmazonUrl),
                AmazonInUrl = _product.AmazonUrl,
                AmazonInPrice = decimal.Parse(_product.AmazonPrice),
                PaytmUrl = _product.PaytmUrl,
                PaytmPrice = decimal.Parse(_product.PaytmPrice)
            };

            isSuccess = productDataProvider.CreateNewProduct(product);
            return View();
        }
    }
}