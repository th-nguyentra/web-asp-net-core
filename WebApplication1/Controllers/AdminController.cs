using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Rotativa.AspNetCore;

namespace DOAN.Controllers
{
    public class AdminController : Controller
    {
        //WEBContext db = new WEBContext();
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public AdminController(WEBContext _context)
        {
            this.Context = _context;
        }
        public IActionResult MasterAD()
        {
            return View();
        }
        public IActionResult TrangChuAD()
        {
            return View();
        }
      

        public IActionResult ReportAD()
        {
            
            return  View();

        }
    }
}