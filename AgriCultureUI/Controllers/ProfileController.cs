using AgriCultureUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		public ProfileController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			//kullanıcı adına göre bulma yaptık.
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Mail = values.Email;
			userEditViewModel.Phone = values.PhoneNumber;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel p)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			//name göre kullanıcıyı bulduk.
			//
			if (p.Password == p.ConfirmPassword)
			{
				values.Email = p.Mail;
				values.PhoneNumber = p.Phone;
				values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
				//şifreyi alamk için hashpassword kullandık.Burdan bizden iki değer istiyor.
				//birisi kullanıcı yanı values diğerl şifre onuda p değişkeninde  geldi.
				var result = await _userManager.UpdateAsync(values);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}
