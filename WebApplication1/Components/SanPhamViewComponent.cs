using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DOAN.Components
{
    public class SanPhamViewComponent : ViewComponent
    {
        private WEBContext _context;

        [ActivatorUtilitiesConstructor]
        public SanPhamViewComponent(WEBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var externalSystems = await _context.Sanpham.ToListAsync();

            return View("Default", externalSystems);
        }
    }
}