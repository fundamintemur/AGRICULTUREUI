using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _SocialMediaPartial:ViewComponent
	{
		private readonly ISocialMediaService _socialmediaService;

		public _SocialMediaPartial(ISocialMediaService socialmediaService)
		{
			_socialmediaService = socialmediaService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialmediaService.GetListAll();
			return View(values);
		}
	}
}
