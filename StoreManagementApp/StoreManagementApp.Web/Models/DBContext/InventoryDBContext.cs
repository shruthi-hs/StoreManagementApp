using Microsoft.EntityFrameworkCore;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.Web.Models.DBContext
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
        {

        }

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
     : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=HMECL001657;Initial Catalog=Inventory;User ID=test;Password=Password@123;");
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

    }
}
