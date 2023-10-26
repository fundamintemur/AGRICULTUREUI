using AgriCultureUI.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceservice;

        public ServiceController(IServiceService serviceservice)
        {
            _serviceservice = serviceservice;
        }

        public IActionResult Index()
        {
            var values = _serviceservice.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            //required kontrollü saglıyo model state
            if (ModelState.IsValid)
            {
                _serviceservice.Insert(new Service()
                {
                    Title=model.Title,
                    Image=model.Image,
                    Description=model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
        public IActionResult DeleteService(int id)
        {
            var values=_serviceservice.GetById(id);
            _serviceservice.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceservice.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceservice.Update(service);
            return RedirectToAction("Index");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
}
