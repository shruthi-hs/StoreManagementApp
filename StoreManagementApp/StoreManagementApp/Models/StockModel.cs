using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementApp.Models
{
    public class StockModel
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
