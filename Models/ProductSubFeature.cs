using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductSubFeature
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SubFeatureId { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }

        public SubFeature SubFeature { get; set; }
    }
}
