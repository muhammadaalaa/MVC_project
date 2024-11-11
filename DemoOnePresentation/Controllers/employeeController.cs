using BLLayer.interFaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication.ExtendedProtection;

namespace DemoOnePresentation.Controllers
{
    public class employeeController : Controller
    {
        private readonly IEmployeeReposatory _employeeReposatory;

        public employeeController(IEmployeeReposatory employeeReposatory)   // to enable creating object on CLR we have to enable dependancyinjection
        {
            _employeeReposatory = employeeReposatory;
        }
        public IActionResult Index()
        {
            var res = _employeeReposatory.GetAll();
            //1-viewData
            //PolicyEnforcement type safety
            ViewData["Message"] = "Hello From View Data";
            //dynamic
            ViewBag.Message = "hello from view Bag";
            return View(res);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Employee emp)
        {
            try
            {
                var res = _employeeReposatory.Add(emp);
                if (res > 0)
                {
                    TempData["Message"] = "data is created";
                }
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(emp);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var res = _employeeReposatory.GetById(id.Value);
            if (res == null) return NotFound();
            return View(res);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp, [FromRoute] int id)
        {
            ;
            if (id != emp.Id) return NotFound();
            if (emp == null) return BadRequest();
            try
            {
                _employeeReposatory.Update(emp);
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(emp);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            var res = _employeeReposatory.GetById(id.Value);
            return View(res);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var res = _employeeReposatory.GetById(id.Value);
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            if (emp == null) return NotFound();
            try
            {
                _employeeReposatory.Delete(emp);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(emp);
        }
    }
}
