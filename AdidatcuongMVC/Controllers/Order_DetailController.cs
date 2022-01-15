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
    public class Order_DetailController : Controller
    {
        private readonly AdidatcuongMVCContext _context;

        public Order_DetailController(AdidatcuongMVCContext context)
        {
            _context = context;
        }

        // GET: Order_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_Detail.ToListAsync());
        }

        // GET: Order_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Create(string OrderID, string ProductID, int Quantity)
        {
            if (ModelState.IsValid)
            {
                var od = new Order_Detail();
                od.OrderID = OrderID;
                od.ProductID = ProductID;
                od.Quantity = Quantity;
             
                _context.Add(od);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        // GET: Order_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderID,ProductID,Quantity")] Order_Detail order_Detail)
        {
            if (id != order_Detail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_DetailExists(order_Detail.ID))
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
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Detail = await _context.Order_Detail.FindAsync(id);
            _context.Order_Detail.Remove(order_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_DetailExists(int id)
        {
            return _context.Order_Detail.Any(e => e.ID == id);
        }
    }
}
