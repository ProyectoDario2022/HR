using HR.API.Data;
using HR.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers
{
    public class MaterialesController:Controller
    {
        private readonly DataContext _context;

        public MaterialesController(DataContext context)
        {
            _context = context;
        }
        // GET: ReclamoTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiales.ToListAsync());
        }

        // GET: ReclamoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReclamoTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(material);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este Tipo de Material");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(material);
        }

        // GET: ReclamoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materiales == null)
            {
                return NotFound();
            }

            Material? material = await _context.Materiales.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: ReclamoTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este Tipo de Material");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(material);
        }

        // GET: Funciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materiales == null)
            {
                return NotFound();
            }

            Material? material = await _context.Materiales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            _context.Materiales.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}