using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
    public class _DashboardNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
