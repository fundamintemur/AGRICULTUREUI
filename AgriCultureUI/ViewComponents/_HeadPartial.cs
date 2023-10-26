using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _HeadPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}

	}
}
