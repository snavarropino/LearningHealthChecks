using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AnotherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post()
        {
            return StatusCode(503);
        }

    }
}
