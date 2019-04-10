using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class YCContext : DbContext
    {
        public YCContext() : base("YCContext")
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
