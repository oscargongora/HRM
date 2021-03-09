using System;
using System.Threading.Tasks;
using HRM.Core.DTO.HumanResource;
using HRM.Core.Entities;
using HRM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRM.UI.Controllers
{
    public class HumanResourcesController : Controller
    {
        private readonly IHumanResourceService _humanResourceService;
        private readonly IDepartmentService _departmentService;

        public HumanResourcesController(IHumanResourceService humanResourceService, IDepartmentService departmentService)
        {
            _humanResourceService = humanResourceService;
            _departmentService = departmentService;
        }

        // GET: HumanResources
        public async Task<IActionResult> Index()
        {
            return View(await _humanResourceService.ToList(hr => hr.Department));
        }

        // GET: HumanResources/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanResource = await _humanResourceService.Find<DetailsHumanResourceDTO>((Guid) id);
            if (humanResource == null)
            {
                return NotFound();
            }

            return View(humanResource);
        }

        private async Task PopulateViewData()
        {
            ViewData["Departments"] = new SelectList(await _departmentService.ToList(), "Id", "Name");
        }

        // GET: HumanResources/Create
        public async Task<IActionResult> Create()
        {
            await PopulateViewData();
            return View();
        }

        // POST: HumanResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,DateOfBirth,DepartmentId,Status,EmployeeNumber")] CreateHumanResourceDTO humanResource)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _humanResourceService.Create(humanResource);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            await PopulateViewData();
            return View(humanResource);
        }

        // GET: HumanResources/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanResource = await _humanResourceService.Find<EditHumanResourceDTO>((Guid) id);

            if (humanResource == null)
            {
                return NotFound();
            }
            await PopulateViewData();
            return View(humanResource);
        }

        // POST: HumanResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,DateOfBirth,DepartmentId,Status,EmployeeNumber")] EditHumanResourceDTO humanResource)
        {
            if (id != humanResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _humanResourceService.Edit(humanResource);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            await PopulateViewData();
            return View(humanResource);
        }

        // GET: HumanResources/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanResource =
                await _humanResourceService
                    .FirstFirstOrDefault<DeleteHumanResourceDTO>(
                        hr => hr.Id == id,
                        hr => hr.Department
                        );

            if (humanResource == null)
            {
                return NotFound();
            }

            return View(humanResource);
        }

        // POST: HumanResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _humanResourceService.Delete(id);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index", "HumanResources");
        }
    }
}