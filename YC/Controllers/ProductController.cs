using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YC.Controllers
{
    public class ProductController : Controller
    {
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
        public ActionResult SaveProduct()
        {
            return View();
        }
    }
}