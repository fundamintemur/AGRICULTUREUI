using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ımageservice;

        public ImageController(IImageService ımageservice)
        {
            _ımageservice = ımageservice;
        }

        public IActionResult Index()
        {
            var values = _ımageservice.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image ımage)
        {
            //TeamValidator validationRules = new TeamValidator();
            //ValidationResult result = validationRules.Validate(team);

            //if (result.IsValid)
            //{
                _ımageservice.Insert(ımage);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
        public IActionResult DeleteImage(int id)
        {
            var value = _ımageservice.GetById(id);
            _ımageservice.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var value = _ımageservice.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditImage(Image ımage)
        {
            //TeamValidator validationRules = new TeamValidator();
            //ValidationResult result = validationRules.Validate(team);

            //if (result.IsValid)
            //{
                _ımageservice.Update(ımage);
                return RedirectToAction("Index");
            //}
            //else
            //{
                //foreach (var item in result.Errors)
                //{
                //    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                //}
            //}
            //return View();
        }

    }
}
