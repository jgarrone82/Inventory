using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalQuantity { get; set; } = 0;
        public Guid CategoryId { get; set; }

    }
}
