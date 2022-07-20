﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductEntity
    {
        //[Key]
        //[StringLength(10)]
        public Guid ProductId { get; set; }
        //[Required]
        //[StringLength(100)]
        public string ProductName { get; set; }
        //[StringLength(600)]
        public string ProductDescription { get; set; }
        public int TotalQuantity { get; set; }
        //Relación con categorías (CategoryEntity)
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        //Relación con almacenamiento (StorageEntity)
        public ICollection<StorageEntity> Storages { get; set; }
    }
}
