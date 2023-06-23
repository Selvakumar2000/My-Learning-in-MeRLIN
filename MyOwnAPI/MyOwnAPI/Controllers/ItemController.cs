using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOwnAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnAPI.Controllers
{

    //[Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        [Route("GetItem")]
        public List<ItemModel> GetItems()
        {
            return LoadList();
        }

        [HttpGet]
        [Route("GetItemByID")]
        public List<ItemModel> GetItemsByID(string ItemId)
        {
            return LoadList().Where(e=>e.ItemId==ItemId).ToList();
        }

        [HttpPost]
        [Route("PostItem")]
        public string PostItem(ItemModel obj)
        {
            List<ItemModel> lstmain = new List<ItemModel>();
            lstmain.Add(obj);
            return "Item Added Successfully";
        }


        private List<ItemModel> LoadList()
        {
            List<ItemModel> lstmain = new List<ItemModel>();
            ItemModel obj1 = new ItemModel();

            obj1.ItemId = "101";
            obj1.ItemName = "MobilePhones";
            obj1.Price=2000;
            lstmain.Add(obj1);

            ItemModel obj2 = new ItemModel();
            obj2.ItemId = "102";
            obj2.ItemName = "Books";
            obj2.Price = 3000;
            lstmain.Add(obj2);

            ItemModel obj3 = new ItemModel();
            obj3.ItemId = "103";
            obj3.ItemName = "Television";
            obj3.Price = 5000;
            lstmain.Add(obj3);

            return lstmain;

            /*ItemModel obj = new ItemModel();
            obj.ItemCode = "101";
            obj.ItemName = "MobilePhones";
            obj.Price = 8000;
            lstmain.Add(obj);*/

        }
    }
}
