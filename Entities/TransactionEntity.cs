using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TransactionEntity
    {
        [Key]
        [StringLength(50)]
        public string InOutId { get; set; }

        [Required]
        public DateTime InOutDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsInput { get; set; }

        //Relación con almacenamiento (StorageEntity)
        public string StorageId { get; set; }
        public StorageEntity Storage { get; set; }
    }
}
