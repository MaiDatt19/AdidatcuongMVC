using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdidatcuongMVC.Data;
using AdidatcuongMVC.Models;

namespace AdidatcuongMVC.Controllers
{
    public class PImagesController : Controller
    {
        private readonly AdidatcuongMVCContext _context;

        public PImagesController(AdidatcuongMVCContext context)
        {
            _context = context;
        }

        // GET: PImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.PImage.ToListAsync());
        }

        // GET: PImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pImage = await _context.PImage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pImage == null)
            {
                return NotFound();
            }

            return View(pImage);
        }

        // GET: PImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Link,ProductID")] PImage pImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pImage);
        }

        // GET: PImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pImage = await _context.PImage.FindAsync(id);
            if (pImage == null)
            {
                return NotFound();
            }
            return View(pImage);
        }

        // POST: PImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Link,ProductID")] PImage pImage)
        {
            if (id != pImage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PImageExists(pImage.ID))
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
            return View(pImage);
        }

        // GET: PImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pImage = await _context.PImage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pImage == null)
            {
                return NotFound();
            }

            return View(pImage);
        }

        // POST: PImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pImage = await _context.PImage.FindAsync(id);
            _context.PImage.Remove(pImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PImageExists(int id)
        {
            return _context.PImage.Any(e => e.ID == id);
        }
    }
}
