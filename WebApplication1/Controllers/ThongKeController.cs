using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    [Route("thongke")]
    public class ThongKeController : Controller
    {
        private readonly WEBContext _context;

        public ThongKeController(WEBContext context)
        {
            _context = context;
        }
       
        public IActionResult ThongKe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult print(string date)
        {
            var get = _context.Hoadon
                 .Where(p => p.CreatedAt.ToString().Contains(date)).ToList();
            return new ViewAsPdf(get);
        }


        [Route("demo/{date}")]
        public IActionResult demo(string date)
        {

            var get = _context.Hoadon
             .Where(p => p.CreatedAt.ToString().Contains(date)).ToList();
            return new JsonResult(get);

        }
       
    }
}