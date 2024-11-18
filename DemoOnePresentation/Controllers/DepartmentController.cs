using BLLayer.interFaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoOnePresentation.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Index()
        {
            //var department = _departmentreposatry.GetAll();
            var department = await _unitOFWork.DepartmentReposatory.GetAllAsync();
            await _unitOFWork.compeleteAsync();

            return View(department);
        }
        // GET: departmentController1/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                //_departmentreposatry.Add(department);
                await _unitOFWork.DepartmentReposatory.AddAsync(department);
                await _unitOFWork.compeleteAsync();
                return Redirect(nameof(Index));

            }
            else
            {
                return View(department);
            }
        }
        public async Task<ActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null) return BadRequest();
            //var res = _departmentreposatry.GetById(id.Value);
            var res = await _unitOFWork.DepartmentReposatory.GetByIdAsync(id.Value);
            await _unitOFWork.compeleteAsync();

            if (res == null) return NotFound();
            return View(ViewName, res);

        }
        public Task<ActionResult> Edit(int? id)
        {
            //if (id == null) return BadRequest();
            //var res = _departmentreposatry.GetById(id.Value);
            //if (res == null) return NotFound();
            //return View(res);
            return Details(id, "Edit");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(Department dep, [FromRoute] int id)
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
                    await _unitOFWork.compeleteAsync();

                    return RedirectToAction(nameof(Index));
                };


            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return View(dep);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            //var result = _departmentreposatry.GetById(id.Value);
            var result = await _unitOFWork.DepartmentReposatory.GetByIdAsync(id.Value);
            await _unitOFWork.compeleteAsync();

            if (result == null) return NotFound();
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Department dep, [FromRoute] int id)
        {
            if (id != dep.Id) return BadRequest();
            try
            {
                //_departmentreposatry.Delete(dep);
                _unitOFWork.DepartmentReposatory.Delete(dep);
                await _unitOFWork.compeleteAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dep);
            }


        }

    }
}
