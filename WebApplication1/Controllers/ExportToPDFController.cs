using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DOAN.Controllers
{
    [Route("ExportToPDF")]
    public class ExportToPDFController : Controller
    {
        private readonly WEBContext _context;

        public ExportToPDFController(WEBContext context)
        {
            _context = context;
        }
      
        public IActionResult ExportToPDF(int? id)
        {        
            var get = _context.Chitiethoadon
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                  .Include(c => c.MahdNavigation.IdkhNavigation)
                .Where(p => p.Mahd == id).ToList();
            ViewBag.total = _context.Chitiethoadon.Sum(item => item.Thanhtien);
            return new ViewAsPdf(get);

        }



    }
}