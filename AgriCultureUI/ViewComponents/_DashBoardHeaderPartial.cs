using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
    public class _DashBoardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
