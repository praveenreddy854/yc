using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Models;
using YC.UIUtils;
using YC.Utils;

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
        [YCAuthorizationFilter]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [YCAuthorizationFilter]
        public YCJsonResult CreateNewProduct(FormCollection prod)
        {
            Product product = new Product
            {
                Name = prod["ProductName"],
                ImageUrl = prod["ImgUrl"],
                CategoryId = int.Parse(prod["SelectedCategory"]),
                AmazonInUrl = prod["AmazonUrl"],
                AmazonInPrice = YCParser.ToDecimal(prod["AmazonPrice"]),
                PaytmUrl = prod["PaytmUrl"],
                PaytmPrice = YCParser.ToDecimal(prod["PaytmPrice"])
            };
            int productId = productDataProvider.CreateNewProduct(product);
            return new YCJsonResult(productId);
        }
    }
}