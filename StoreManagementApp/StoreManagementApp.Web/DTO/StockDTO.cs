using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.DTO
{
    public class StockDTO
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
