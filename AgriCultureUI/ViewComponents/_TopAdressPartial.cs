using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _TopAdressPartial : ViewComponent
	{
		private readonly IAddressService _adresService;

		public _TopAdressPartial(IAddressService adresService)
		{
			_adresService = adresService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _adresService.GetListAll();
			return View(values);
		}
	}
}
