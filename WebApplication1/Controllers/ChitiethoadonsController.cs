
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Rotativa.AspNetCore;

namespace DOAN.Controllers
{
    public class ChitiethoadonsController : Controller
    {
        private readonly WEBContext _context;

        public ChitiethoadonsController(WEBContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> HoaDonPDF(int? id)
        {
            var wEBContext = _context.Chitiethoadon
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .Where(p => p.Mahd == id);
            return new ViewAsPdf(await wEBContext.ToListAsync());

        }

        // GET: Chitiethoadons
        public async Task<IActionResult> Index(int? id)
        {
            var wEBContext = _context.Chitiethoadon
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .Where(p=>p.Mahd==id);
            return View(await wEBContext.ToListAsync());
          
        }

        // GET: Chitiethoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // GET: Chitiethoadons/Create
        public IActionResult Create()
        {
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd");
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Tensp");
            return View();
        }

        // POST: Chitiethoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahd,Masp,Thanhtien,Soluong,Gia,CreatedAt,UpdatedAt")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiethoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", chitiethoadon.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Tensp", chitiethoadon.Masp);
            return View(chitiethoadon);
        }

     //   GET: Chitiethoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Tinhtrang", chitiethoadon.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Tensp", chitiethoadon.Masp);
            return View(chitiethoadon);
        }

        //POST: Chitiethoadons/Edit/5
         //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahd,Masp,Thanhtien,Soluong,Gia,CreatedAt,UpdatedAt")] Chitiethoadon chitiethoadon)
        {
            if (id != chitiethoadon.Mahd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiethoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitiethoadonExists(chitiethoadon.Mahd))
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
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Tinhtrang", chitiethoadon.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Tensp", chitiethoadon.Masp);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // POST: Chitiethoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);
            _context.Chitiethoadon.Remove(chitiethoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitiethoadonExists(int id)
        {
            return _context.Chitiethoadon.Any(e => e.Mahd == id);
        }
    }
}
