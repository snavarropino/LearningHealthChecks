using HealthChecksUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HealthChecksUI.Controllers
{
    public class HomeController : Controller
    {
        public IOptions<WebHooksConfiguration> Options { get; }

        public HomeController(IOptions<WebHooksConfiguration> options)
        {
            Options = options;
        }

        public IActionResult Index()
        {
            ViewData["WebHooks"] = Options.Value.Webhooks;
            return View();
        }
    }
}
