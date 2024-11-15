using AutoMapper;
using BLLayer.interFaces;
using BLLayer.reposatries;
using DAL.Models;
using DemoOnePresentation.helper;
using DemoOnePresentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace DemoOnePresentation.Controllers
{
    public class employeeController : Controller
    {
        #region generic reposatory
        //private readonly IEmployeeReposatory _employeeReposatory;
        //private readonly IDepartmentReposatory _departmentReposatory; 
        //public employeeController(IEmployeeReposatory employeeReposatory, IDepartmentReposatory departmentReposatory, IMapper mapper)   ==> generic reposatory 
        #endregion
        private readonly IUnitOFWork _unitOfwork;  // unit OF work
        private readonly IMapper _mapper;

        public employeeController(IUnitOFWork unitOfwork, IMapper mapper)   // unit of work
        {
            #region generic reposatory
            //_employeeReposatory = employeeReposatory;
            //_departmentReposatory = departmentReposatory; 
            #endregion
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public IActionResult Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                #region repos
                //var res = _employeeReposatory.GetAll(); 
                #endregion
                var res = _unitOfwork.EmployeeReposatory.GetAll();
                var mappedEmloyee = _mapper.Map<IEnumerable<Employee>, IEnumerable<employeeViewModel>>(res);
                return View(mappedEmloyee);
                ///1-viewData
                ///PolicyEnforcement type safety
                ///ViewData["Message"] = "Hello From View Data";
                ///dynamic
                ///ViewBag.Message = "hello from view Bag";
            }
            //var employees = _employeeReposatory.GetEmployeesByName(searchValue);
            var employees = _unitOfwork.EmployeeReposatory.GetEmployeesByName(searchValue);
            var mappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<employeeViewModel>>(employees);
            return View(mappedEmployees);
        }
        [HttpGet]
        public IActionResult create()
        {
            //ViewBag.Department = _departmentReposatory.GetAll();
            ViewBag.Department = _unitOfwork.DepartmentReposatory.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult create(employeeViewModel empVM)
        {
            try
            {
                //any thing dealing with dataBase will be with view model ==> class render at view
                // we have to do mapping or explicit casting or declaring object and give the alues of the viewModels to this object
                // but there is an method doing that automatically
                if (empVM.ImageName is not null)
                {
                    empVM.ImageName = Documentettings.uploadFile(empVM.Image, "images");
                }



                var mappedEmployee = _mapper.Map<employeeViewModel, Employee>(empVM);
                //var res = _employeeReposatory.Add(mappedEmployee);
                _unitOfwork.EmployeeReposatory.Add(mappedEmployee);

                TempData["Message"] = "data is created";
                _unitOfwork.compelete();
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(empVM);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            //var res = _employeeReposatory.GetById(id.Value);
            var res = _unitOfwork.EmployeeReposatory.GetById(id.Value);
            //ViewBag.Department = _departmentReposatory.GetAll();
            ViewBag.Department = _unitOfwork.DepartmentReposatory.GetAll();
            if (res == null) return NotFound();
            var mappedresult = _mapper.Map<Employee, employeeViewModel>(res);
            try
            {
                return View(mappedresult);
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(mappedresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(employeeViewModel empVM, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var map_mapper = _mapper.Map<Employee>(empVM);
                if (id != map_mapper.Id) return NotFound();
                if (map_mapper == null) return BadRequest();
                //_employeeReposatory.Update(map_mapper);
                _unitOfwork.EmployeeReposatory.Update(map_mapper);
                _unitOfwork.compelete();
                return RedirectToAction(nameof(Index));

            }
            return View(empVM);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            //var res = _employeeReposatory.GetById(id.Value);
            var res = _unitOfwork.EmployeeReposatory.GetById(id.Value);

            var mappedElement = _mapper.Map<Employee, employeeViewModel>(res);
            return View(mappedElement);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            //var res = _employeeReposatory.GetById(id.Value);
            var res = _unitOfwork.EmployeeReposatory.GetById(id.Value);

            var mappedElement = _mapper.Map<Employee, employeeViewModel>(res);
            return View(mappedElement);
        }
        [HttpPost]
        public IActionResult Delete(employeeViewModel emp)
        {
            if (emp == null) return NotFound();
            try
            {
                var mappedelement = _mapper.Map<Employee>(emp);
                //_employeeReposatory.Delete(mappedelement);
                _unitOfwork.EmployeeReposatory.Delete(mappedelement);
                var res = _unitOfwork.compelete();
                if (res > 0 && emp.ImageName is not null)
                {
                    Documentettings.deleteFile(emp.ImageName, "Images");
                }
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
