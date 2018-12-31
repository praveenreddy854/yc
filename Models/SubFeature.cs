using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SubFeature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MainFeatureId { get; set; }

        public Feature Feature { get; set; }

        public IList<ProductFeature> productFeatures { get; set; }
    }
}
