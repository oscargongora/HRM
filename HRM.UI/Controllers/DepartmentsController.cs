using System;
using System.Threading.Tasks;
using HRM.Core.DTO.Department;
using HRM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.UI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.ToList());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.Find<DetailsDepartmentDTO>((Guid) id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] CreateDepartmentDTO department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.Create(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.Find<EditDepartmentDTO>((Guid) id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] EditDepartmentDTO department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.Edit(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.Find<DeleteDepartmentDTO>((Guid) id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _departmentService.Delete(id);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index", "Departments");
        }
    }
}