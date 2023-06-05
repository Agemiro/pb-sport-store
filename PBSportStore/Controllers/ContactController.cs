using Microsoft.AspNetCore.Mvc;

namespace PBSportStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
