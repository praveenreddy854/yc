﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual IList<Product> Products { get; set; }
    }
}
