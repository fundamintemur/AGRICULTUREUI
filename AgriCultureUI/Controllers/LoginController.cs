using AgriCultureUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //asp.net core idenntity özelliğiyle geldi
        private readonly UserManager<IdentityUser> _userManager;
        //yukardaki kod sign up içn yazdık kayıt olması için
        private readonly SignInManager<IdentityUser> _signInManager;
        //ındex login için yaptık.
        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //1.false çerezleri kabul etme demek
                //2.false sistemkaç kere hatalı giriş yaptığını tutar biz bunu false yaptık.İstediğimiz kadar girebiliriz.
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.username, loginViewModel.password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            IdentityUser ıdentityUser = new IdentityUser()
            {
                Id = "1",
                UserName = registerViewModel.userName,
                Email = registerViewModel.mail
            };
            if (registerViewModel.password == registerViewModel.passwordConfirm)
            {
                //şifre eşleşmesi sağlandığında yeni bir kullanıcı oluşturmakq için bu koddou yazdık.
                var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    //başarılı değilse bir açıklama göndersin.
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
    }
}
