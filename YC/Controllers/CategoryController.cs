using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Models;
using Newtonsoft.Json;

namespace YC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDataProvider categoryDataProvider;
        private Dictionary<int, string> categoryDict = new Dictionary<int, string>();

        public CategoryController(ICategoryDataProvider categoryDataProvider)
        {
            this.categoryDataProvider = categoryDataProvider;
        }
        // GET: Category
        public string GetAllCategories()
        {
            var categories = categoryDataProvider.GetAll();

            foreach(var category in categories)
            {
                categoryDict.Add(category.Id, category.Name);
            }
            return JsonConvert.SerializeObject(categoryDict);
        }
    }
}