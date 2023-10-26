using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _AboutPartial:ViewComponent
	{
		private readonly IAboutService aboutService;

		public _AboutPartial(IAboutService aboutService)
		{
			this.aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var values = aboutService.GetListAll();
			return View(values);
		}
	}
}
