
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Stocks = new List<Stock>();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string SKU { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
