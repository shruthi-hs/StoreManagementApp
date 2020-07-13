using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.Model
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string SKU { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
