using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
