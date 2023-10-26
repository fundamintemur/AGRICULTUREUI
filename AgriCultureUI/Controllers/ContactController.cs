using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class ContactController : Controller
    {
     
      private readonly IContactService _contactservice;

        public ContactController(IContactService contactservice)
        {
            _contactservice = contactservice;
        }

        public IActionResult Index()
        {
            var values = _contactservice.GetListAll();
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
        public IActionResult DeleteMessage(int id)
        {
            var values = _contactservice.GetById(id);
            _contactservice.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _contactservice.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult MessageDetails(Contact p)
        {
            _contactservice.Update(p);
            return RedirectToAction("Index");
        }
    }
}
    
