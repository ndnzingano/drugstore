using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using drugstore.Data;
using drugstore.Models;

namespace drugstore.Controllers
{
    public class PurchaseRecordsController : Controller
    {
        private readonly drugstoreContext _context;

        public PurchaseRecordsController(drugstoreContext context)
        {
            _context = context;
        }

        // GET: PurchaseRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseRecord.ToListAsync());
        }

        // GET: PurchaseRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }

            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Total")] PurchaseRecord purchaseRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecord.FindAsync(id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }
            return View(purchaseRecord);
        }

        // POST: PurchaseRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Total")] PurchaseRecord purchaseRecord)
        {
            if (id != purchaseRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseRecordExists(purchaseRecord.Id))
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
            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }

            return View(purchaseRecord);
        }

        // POST: PurchaseRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseRecord = await _context.PurchaseRecord.FindAsync(id);
            _context.PurchaseRecord.Remove(purchaseRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseRecordExists(int id)
        {
            return _context.PurchaseRecord.Any(e => e.Id == id);
        }
    }
}
