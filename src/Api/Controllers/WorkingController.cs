using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public WorkingController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return new StatusCodeResult(503);
                }
            }

            return Ok("Healthy");
        }

       
    }
}