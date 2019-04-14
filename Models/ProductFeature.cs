using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int FeatureDescription { get; set; } 

        [NotMapped]
        public Feature Feature { get; set; }

        [NotMapped]
        public Product Product { get; set; }
    }
}
