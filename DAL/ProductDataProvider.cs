using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ProductDataProvider : IProductDataProvider
    {
        private readonly YCContext YCDBContext;
        public ProductDataProvider(YCContext dBContext)
        {
            YCDBContext = dBContext;
        }

        public bool CreateNewProduct(Product product)
        {
            try
            {
                YCDBContext.Products.Add(product);
                YCDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public ICollection<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
