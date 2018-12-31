using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductFeature
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public Product Product { get; set; }
    }
}
