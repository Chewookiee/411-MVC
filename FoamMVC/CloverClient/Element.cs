using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloverClient
{
    public class Element
    {
        public string ID { get; set; }
        public bool Hidden { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PriceType { get; set; }
        public bool DefaultTaxRates { get; set; }
        public int Cost { get; set; }
        public bool IsRevenue { get; set; }
        public int StockCount { get; set; }
        public object ModifiedTime { get; set; }
        public string AlternateName { get; set; }
        public string Code { get; set; }
        public string SKU { get; set; }
        public string UnitName { get; set; }
    }
}
