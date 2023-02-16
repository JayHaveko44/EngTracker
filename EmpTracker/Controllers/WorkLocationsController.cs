using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpTracker.Data;
using EmpTracker.Models;

namespace EmpTracker.Controllers
{
    public class WorkLocationsController : Controller
    {
        private readonly EmpTrackerContext _context;

        public WorkLocationsController(EmpTrackerContext context)
        {
            _context = context;
        }

        // GET: WorkLocations
        public async Task<IActionResult> Index()
        {
              return View(await _context.WorkLocation.ToListAsync());
        }

        // GET: WorkLocations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.WorkLocation == null)
            {
                return NotFound();
            }

            var workLocation = await _context.WorkLocation
                .FirstOrDefaultAsync(m => m.WorkLocationId == id);
            if (workLocation == null)
            {
                return NotFound();
            }

            return View(workLocation);
        }

        // GET: WorkLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkLocationId,Name")] WorkLocation workLocation)
        {
            if (ModelState.IsValid)
            {
                workLocation.WorkLocationId = Guid.NewGuid();
                _context.Add(workLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workLocation);
        }

        // GET: WorkLocations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.WorkLocation == null)
            {
                return NotFound();
            }

            var workLocation = await _context.WorkLocation.FindAsync(id);
            if (workLocation == null)
            {
                return NotFound();
            }
            return View(workLocation);
        }

        // POST: WorkLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WorkLocationId,Name")] WorkLocation workLocation)
        {
            if (id != workLocation.WorkLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkLocationExists(workLocation.WorkLocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workLocation);
        }

        // GET: WorkLocations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.WorkLocation == null)
            {
                return NotFound();
            }

            var workLocation = await _context.WorkLocation
                .FirstOrDefaultAsync(m => m.WorkLocationId == id);
            if (workLocation == null)
            {
                return NotFound();
            }

            return View(workLocation);
        }

        // POST: WorkLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
         
            var workLocation = await _context.WorkLocation.FindAsync(id);
            if (workLocation != null)
            {
                _context.WorkLocation.Remove(workLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ShowEmployeesAtLocation(Guid id)
        {
            var engineers = await _context.Engineer.Where(e => e.WorkingLocation.WorkLocationId == id).ToListAsync();
            if (engineers.Any())
            {
                return View(engineers);
            }
            return View();
        }
            private bool WorkLocationExists(Guid id)
        {
          return _context.WorkLocation.Any(e => e.WorkLocationId == id);
        }
    }
}
