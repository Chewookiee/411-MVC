using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.BLL.CRUD.StagedItemsOperations;
using FoamMVC.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace FoamMVC.CloverReader
{
    public static class CloverClient
    {
        public static void Run()
        {
            int offset = 0;
            int limit = 100;
            RestClient client = new RestClient("https://api.clover.com/v3/merchants/R0YXW6ESBYFNJ/");
            RootObject rootObject = new RootObject();
            StagedItemBLL _stagedITemCRUD = new StagedItemBLL();
            do
            {
                // Get all items in the "Package Beer" category - currently 1,156
                var endpointParams = "categories/7C7C30CG8QXM8/items?offset=" + offset + "&limit=" + limit;
                var request = new RestRequest(endpointParams, Method.GET) { RequestFormat = DataFormat.Json };
                request.AddHeader("Authorization", "Bearer af214874-074a-4ea7-965b-cb085ffe9394");
                var response = client.Execute(request);
                rootObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
                var stagedItems = rootObject.elements.Select(x => new StagedItemDTO()
                {
                    Name = x.Name,
                    UPC = x.Code,
                    StockCount = x.StockCount,
                    ItemPrice = x.Price
                }).ToList();

                _stagedITemCRUD.ProcessStagedItems(stagedItems);

                offset += limit;
            } while (rootObject.elements.Count != 0);
        }
        public class RootObject
        {
            public List<Element> elements { get; set; }
            public string href { get; set; }
        }

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
}