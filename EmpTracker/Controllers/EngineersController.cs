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
    public class EngineersController : Controller
    {
        private readonly EmpTrackerContext _context;

        public EngineersController(EmpTrackerContext context)
        {
            _context = context;
        }

        // GET: Engineers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Engineer.ToListAsync());
        }

        // GET: Engineers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Engineer == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer
                .FirstOrDefaultAsync(m => m.EngineerId == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // GET: Engineers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engineers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineerId,FirstName,LastName,IsWorking")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                engineer.EngineerId = Guid.NewGuid();
                _context.Add(engineer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        // GET: Engineers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Engineer == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }
            return View(engineer);
        }

        // POST: Engineers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EngineerId,FirstName,LastName,IsWorking")] Engineer engineer)
        {
            if (id != engineer.EngineerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineerExists(engineer.EngineerId))
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
            return View(engineer);
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(EngineerWorkLocationVM workLocationVM)
        {
            var worklocation = await _context.WorkLocation.FindAsync(workLocationVM.WorkLocationId);
            if (worklocation != null)
            {
                Engineer engineer = await _context.Engineer.FindAsync(workLocationVM.EngineerId);
                engineer.WorkingLocation = worklocation;
                _context.Update(engineer);
                await _context.SaveChangesAsync();
            }
      
            return View("Index", await _context.Engineer.ToListAsync());

        }

        // GET: Engineers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Engineer == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer
                .FirstOrDefaultAsync(m => m.EngineerId == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // POST: Engineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Engineer == null)
            {
                return Problem("Entity set 'EmpTrackerContext.Engineer'  is null.");
            }
            var engineer = await _context.Engineer.FindAsync(id);
            if (engineer != null)
            {
                _context.Engineer.Remove(engineer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> ChangeWorkLocation(Guid id)
        {     
            var worklocation = await _context.WorkLocation.ToListAsync();
            EngineerWorkLocationVM vm = new EngineerWorkLocationVM();
            vm.WorkLocations = worklocation;
            vm.EngineerId = id;
            return View(vm);
                       
        }

        private bool EngineerExists(Guid id)
        {
          return _context.Engineer.Any(e => e.EngineerId == id);
        }
    }
}
