using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly YCContext YCDBContext;

        public CategoryDataProvider(YCContext dBContext)
        {
            this.YCDBContext = dBContext;
        }
        public ICollection<Category> GetAll()
        {
            return YCDBContext.Categories.ToList();
        }
    }
}
