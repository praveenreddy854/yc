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
        private readonly YCContext dBContext;

        public CategoryDataProvider(YCContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public ICollection<Category> GetAll()
        {
            return dBContext.Categories.ToList();
        }
    }
}
