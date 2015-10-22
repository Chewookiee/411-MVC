using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.ViewModels
{
    public class StagedItemsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }
        public int StockCount { get; set; }
        public string ItemPrice { get; set; }
    }
}