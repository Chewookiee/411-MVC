using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DTOs
{
    public class StagedItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }
        public int StockCount { get; set; }
        public double ItemPrice { get; set; }
    }
}