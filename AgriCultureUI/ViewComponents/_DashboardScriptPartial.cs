using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
    public class _DashboardScriptPartial:ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
