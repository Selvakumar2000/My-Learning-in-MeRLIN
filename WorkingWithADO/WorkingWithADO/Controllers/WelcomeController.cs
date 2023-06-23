using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithADO.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public WelcomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("HelloUser")]
        public string HelloUser()
        {
            return "Hello User, Welcome To My Page.....";
        }
        
    }
}
