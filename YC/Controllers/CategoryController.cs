using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Models;
using Newtonsoft.Json;
using YC.UIUtils;

namespace YC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDataProvider categoryDataProvider;
        private IEnumerable<Category> categories = new List<Category>();

        public CategoryController(ICategoryDataProvider categoryDataProvider)
        {
            this.categoryDataProvider = categoryDataProvider;
        }
        // GET: Category
        public YCJsonResult GetAllCategories()
        {
            categories = categoryDataProvider.GetAll();
            return new YCJsonResult(categories);
        }
    }
}