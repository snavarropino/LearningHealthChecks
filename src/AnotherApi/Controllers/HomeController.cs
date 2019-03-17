using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AnotherApi.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok("Another Superheroes API");
        }
    }
}
