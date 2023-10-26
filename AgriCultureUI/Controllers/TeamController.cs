using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriCultureUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamservice;

        public TeamController(ITeamService teamservice)
        {
            _teamservice = teamservice;
        }

        public IActionResult Index()
        {
            var values = _teamservice.GetListAll();
            if (values.Count() == 0)
            {
                return RedirectToAction("Error");
            }

            return View(values);

        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamservice.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamservice.GetById(id);
            _teamservice.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var value = _teamservice.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamservice.Update(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
