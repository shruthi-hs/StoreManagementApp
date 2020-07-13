using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementApp.Models
{
    public class ProductModel
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

        public List<StockModel> Stocks { get; set; }
    }
}
