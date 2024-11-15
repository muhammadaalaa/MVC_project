using BLLayer.interFaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoOnePresentation.Controllers
{
    public class departmentController : Controller
    {
        private readonly IUnitOFWork _unitOFWork;
        #region repo
        //private readonly IDepartmentReposatory _departmentreposatry;

        //public departmentController(IDepartmentReposatory departmentreposatry) 
        #endregion
        public departmentController(IUnitOFWork unitOFWork)
        {
            //_departmentreposatry = departmentreposatry;
            _unitOFWork = unitOFWork;
        }



        // GET: departmentController1
        public ActionResult Index()
        {
            //var department = _departmentreposatry.GetAll();
            var department = _unitOFWork.DepartmentReposatory.GetAll();
            _unitOFWork.compelete();

            return View(department);
        }
        // GET: departmentController1/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                //_departmentreposatry.Add(department);
                _unitOFWork.DepartmentReposatory.Add(department);
                _unitOFWork.compelete();
                return Redirect(nameof(Index));

            }
            else
            {
                return View(department);
            }
        }
        public ActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null) return BadRequest();
            //var res = _departmentreposatry.GetById(id.Value);
            var res = _unitOFWork.DepartmentReposatory.GetById(id.Value);
            _unitOFWork.compelete();

            if (res == null) return NotFound();
            return View(ViewName, res);

        }
        public ActionResult Edit(int? id)
        {
            //if (id == null) return BadRequest();
            //var res = _departmentreposatry.GetById(id.Value);
            //if (res == null) return NotFound();
            //return View(res);
            return Details(id, "Edit");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Edit(Department dep, [FromRoute] int id)
        {
            if (id != dep.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    //_departmentreposatry.Update(dep);
                    _unitOFWork.DepartmentReposatory.Update(dep);
                    _unitOFWork.compelete();

                    return RedirectToAction(nameof(Index));
                };


            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return View(dep);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            //var result = _departmentreposatry.GetById(id.Value);
            var result = _unitOFWork.DepartmentReposatory.GetById(id.Value);
            _unitOFWork.compelete();

            if (result == null) return NotFound();
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department dep, [FromRoute] int id)
        {
            if (id != dep.Id) return BadRequest();
            try
            {
                //_departmentreposatry.Delete(dep);
                _unitOFWork.DepartmentReposatory.Delete(dep);
                _unitOFWork.compelete();

                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dep);
            }


        }












        //// GET: departmentController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}


        //// POST: departmentController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: departmentController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: departmentController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: departmentController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: departmentController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
