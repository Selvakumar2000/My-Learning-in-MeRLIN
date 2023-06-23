using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCAuthenticationAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAuthenticationAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public UsersController(IConfiguration config)
        {
            _config = config;
          
        }

        public ActionResult<List<string>> GetUser()
        {
            List<string> names = new List<string>();
            try
            {
                string connectionString = _config.GetConnectionString("MVCAuthenticationAPP");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select FirstName from AspNetUsers;", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader(); //connected architecture
               
                while (sdr.Read())
                {
                    names.Add((string)sdr["FirstName"]);
                }
                con.Close();

                return names;
               
            }
            catch (Exception ex)
            {
                return BadRequest("Operation Failed  " + ex);
            }
        }
    }
}
