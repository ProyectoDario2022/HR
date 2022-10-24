using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR.API.Data;
using HR.API.Data.Entities;

namespace HR.API.Controllers
{
    public class ReclamoTypesController : Controller
    {
        private readonly DataContext _context;

        public ReclamoTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: ReclamoTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ReclamoTypes.ToListAsync());
        }

        // GET: ReclamoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReclamoTypes/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReclamoType reclamoType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamoType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reclamoType);
        }

        // GET: ReclamoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReclamoTypes == null)
            {
                return NotFound();
            }

            var reclamoType = await _context.ReclamoTypes.FindAsync(id);
            if (reclamoType == null)
            {
                return NotFound();
            }
            return View(reclamoType);
        }

        // POST: ReclamoTypes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ReclamoType reclamoType)
        {
            if (id != reclamoType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamoType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamoTypeExists(reclamoType.Id))
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
            return View(reclamoType);
        }

        // GET: ReclamoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReclamoTypes == null)
            {
                return NotFound();
            }

            var reclamoType = await _context.ReclamoTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclamoType == null)
            {
                return NotFound();
            }
            _context.ReclamoTypes.Remove(reclamoType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool ReclamoTypeExists(int id)
        {
          return _context.ReclamoTypes.Any(e => e.Id == id);
        }
    }
}
