using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string AmazonInUrl { get; set; }

        public decimal? AmazonInPrice { get; set; }

        public string PaytmUrl { get; set; }

        public decimal? PaytmPrice { get; set; }

        public virtual IList<ProductFeature> ProductFeatures { get; set; }

        public virtual Category Category { get; set; }

        public virtual IList<ProductSubFeature> ProductSubFeatures { get; set; }
    }
}
