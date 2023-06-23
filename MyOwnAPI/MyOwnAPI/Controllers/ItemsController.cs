using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyOwnAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnAPI.Controllers
{
    /*..Download it from Nuget Package Manager
     * System.Data.SqlClient
     * Select Query =>Based on output
     * cmd.ExecuteReader() Method
     * cmd.ExecuteScalar() Method
     * https://stackoverflow.com/questions/22143203/what-exactly-does-cmd-executenonquery-do-in-my-program
     * For Handling images ....i used IFormFile Interface
     */
    //[Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetItems")]
        public List<ItemsModel> GetItems()
        {
            return LoadListFromDB();
        }

        [HttpGet]
        [Route("GetItemsByID")]
        public List<ItemsModel> GetItemsByID(int ItemId)
        {
            return LoadListFromDB().Where(e => e.ItemId == ItemId).ToList();
        }

        [HttpPost]
        [Route("PostItems")]
        public string PostItems(ItemsModel obj)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCon"));
            SqlCommand cmd = new SqlCommand("Insert into Items values(' "+obj.ItemId+"','"+obj.ItemName+"','"+obj.Price+" ')", con);
            //SqlCommand cmd = new SqlCommand("Insert into Items values("+obj.ItemId +  obj.ItemName +  obj.Price+")", con); syntax error
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Items Added Successfully";
        }

        [HttpPut]
        [Route("UpdateItems")]
        public string UpdateItems(ItemsModel obj,int ItemIdn)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCon"));
            SqlCommand cmd = new SqlCommand("UPDATE Items SET ItemId='"+obj.ItemId+"',ItemName='"+obj.ItemName+"',Price='"+obj.Price+"' WHERE ItemId = '"+ItemIdn+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Items Updated Successfully";
        }


        [HttpDelete]
        [Route("DeleteItems")]
        public string DeleteItems(int ItemId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCon"));
            SqlCommand cmd = new SqlCommand("Delete from Items where ItemId='"+ItemId+"' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Items Deleted Successfully";
        }

        [HttpPost]
        [Route("SaveFile")]
        public async Task<bool> WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string filename;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks + extension; //create a new file name for security purposes

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files");
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files", filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                isSaveSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isSaveSuccess;
        }


    private List<ItemsModel> LoadListFromDB()
        {
            List<ItemsModel> listmain = new List<ItemsModel>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCon"));
            SqlCommand cmd = new SqlCommand("Select * from Items", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemsModel obj = new ItemsModel();
                obj.ItemId = int.Parse(dt.Rows[i]["ItemId"].ToString());
                obj.ItemName = dt.Rows[i]["ItemName"].ToString();
                obj.Price = int.Parse(dt.Rows[i]["Price"].ToString());
                listmain.Add(obj);
            }
            return listmain;
        }
    }
}
