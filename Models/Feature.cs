using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Feature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ProductFeature> ProductFeatures { get; set; }

        public virtual IList<SubFeature> SubFeatures { get; set; }
    }
}
