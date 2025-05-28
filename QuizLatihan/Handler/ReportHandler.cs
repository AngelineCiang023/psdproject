using System.Collections.Generic;
using System.Linq;
using QuizLatihan.Model;

namespace QuizLatihan.Handler
{
    public class ReportHandler
    {
        public class InventoryReport
        {
            public string JewelName { get; set; }
            public int Stock { get; set; }
            public decimal Price { get; set; }
            public decimal TotalValue => Stock * Price;
        }

        public static List<InventoryReport> GetInventoryReport()
        {
            using (var db = new Model1Entities())
            {
                return db.TblJewels
                         .Select(j => new InventoryReport
                         {
                             JewelName = j.JewelName,
                             Stock = j.JewelStock,
                             Price = j.JewelPrice
                         })
                         .ToList();
            }
        }

        public static decimal GetTotalStockValue()
        {
            using (var db = new Model1Entities())
            {
                return db.TblJewels
                         .Select(j => j.JewelStock * j.JewelPrice)
                         .Sum();
            }
        }
    }
}
