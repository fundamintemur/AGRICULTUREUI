using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class AdressController : Controller
    {
        private readonly IAddressService _adresService;

        public AdressController(IAddressService adresService)
        {
            _adresService = adresService;
        }

        public IActionResult Index()
        {
            var values = _adresService.GetListAll();

            return View(values);
        }
        //[HttpGet]
        //public IActionResult AddAddres()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddAddres(Adress p)
        //{
           
        //    _adresService.Insert(p);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult DeleteAddres(int id)
        //{
        //    var values = _adresService.GetById(id);
        //    _adresService.Delete(values);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult EditAddres(int id)
        {
            var values = _adresService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAddres(Adress p)
        {
            _adresService.Update(p);
            return RedirectToAction("Index");
        }
    }
}
