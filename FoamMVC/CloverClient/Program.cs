using System;
using System.Collections.Generic;
using System.Linq;
using CloverClient;
using FoamMVC.BLL.CRUD.StagedItemsOperations;
using FoamMVC.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace CloverClient
{
    public static  class Program
    {
        //private static int offset = 0;
        //private static readonly int limit = 100;
        //private static  readonly RestClient client = new RestClient("https://api.clover.com/v3/merchants/R0YXW6ESBYFNJ/");

        public static void Main(string[] args)
        {
            //RootObject rootObject = new RootObject();
            //StagedItemCRUDBLL _stagedITemCRUD = new StagedItemCRUDBLL();
            //do
            //{
            //    // Get all items in the "Package Beer" category - currently 1,156
            //    var endpointParams = "categories/7C7C30CG8QXM8/items?offset=" + offset + "&limit=" + limit;
            //    var request = new RestRequest(endpointParams, Method.GET) {RequestFormat = DataFormat.Json};
            //    request.AddHeader("Authorization", "Bearer af214874-074a-4ea7-965b-cb085ffe9394");
            //    var response = client.Execute(request);
            //    rootObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
            //    var stagedItems = rootObject.elements.Select(x => new StagedItemDTO()
            //    {
            //        Name = x.Name,
            //        UPC = x.Code,
            //        StockCount = x.StockCount,
            //        ItemPrice = x.Price
            //    }).ToList();

            //    _stagedITemCRUD.ProcessStagedItems(stagedItems);

            //    offset += limit;
            //} while (rootObject.elements.Count != 0);



            //Console.WriteLine("Rekt");
            //Console.ReadKey();
        }
    }
}
