using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    public class SanphamsController : Controller
    {
        private readonly WEBContext _context;

        public SanphamsController(WEBContext context)
        {
            _context = context;
        }

        //
      

        // GET: Sanphams
        public async Task<IActionResult> Index()
        {
            var wEBContext = _context.Sanpham.Include(s => s.HangNavigation);
            return View(await wEBContext.ToListAsync());
        }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.HangNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            ViewData["Hang"] = new SelectList(_context.Hang, "Mahang", "Tenhang");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Tensp,Hang,Mota,Namsx,Gia,Anhdaidien,Manhinh,Cameratruoc,Camerasau,Ram,Bonhotrong,Cpu,Gpu,Pin,Os,Sim")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
               sanpham.Giakhuyenmai = sanpham.Gia;//default value of discount price
                sanpham.Giakhuyenmai = 1;//default value of discount
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hang"] = new SelectList(_context.Hang, "Mahang", "Tenhang", sanpham.Hang);
            return View(sanpham);
        }
      
        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["Hang"] = new SelectList(_context.Hang, "Mahang", "Tenhang", sanpham.Hang);
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masp,Tensp,Hang,Mota,Namsx,Gia,Giakhuyenmai,Anhdaidien,Manhinh,Cameratruoc,Camerasau,Ram,Bonhotrong,Cpu,Gpu,Pin,Os,Sim")] Sanpham sanpham)
        {
            if (id != sanpham.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Masp))
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
            ViewData["Hang"] = new SelectList(_context.Hang, "Mahang", "Tenhang", sanpham.Hang);
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.HangNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanpham.FindAsync(id);
            _context.Sanpham.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanpham.Any(e => e.Masp == id);
        }
    }
}
