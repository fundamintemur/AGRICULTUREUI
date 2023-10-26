using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _ContactPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
