﻿using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext agricultureContext= new AgricultureContext();
			var values = agricultureContext.Adresses.Select(x => x.MapInfo).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}
