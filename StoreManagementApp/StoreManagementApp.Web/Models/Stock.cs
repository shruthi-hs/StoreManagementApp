using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.Model
{
    [Table("Stock")]
    public class Stock
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
