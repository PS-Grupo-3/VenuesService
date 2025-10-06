using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
