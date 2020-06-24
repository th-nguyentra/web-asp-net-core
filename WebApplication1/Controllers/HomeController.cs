using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DOAN.Models;
using DOAN.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    public class HomeController : Controller
    {
        //  WEBContext db = new WEBContext();
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public HomeController(WEBContext _context)
        {
            this.Context = _context;
        }

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult _Layout()
        {

            return View();
        }

        public IActionResult TrangChu()
        {


            List<Sanpham> hangs = Context.Sanpham.ToList();

            return PartialView(hangs);

        }
      
    
      
        public IActionResult GioHang()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.sanpham.Gia * item.Quantity * item.sanpham.Giakhuyenmai);
            }
            else
            {
                ViewBag.total = 0;

            }


            return View();
        }
        public async Task<IActionResult> Buy(int? id)
        {

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { sanpham = Context.Sanpham.Single(p => p.Masp.Equals(id)), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { sanpham = Context.Sanpham.Single(p => p.Masp.Equals(id)), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
         

            }
           
            return RedirectToAction("GioHang");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");

        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");
        }
        private int isExist(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].sanpham.Masp.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        //Chi tiết sản phẩm
        public async Task<IActionResult> ChiTietSanPham(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await Context.Sanpham
                .Include(h => h.HangNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return PartialView(sanpham);
        }

        // Paah loại sản phẩm
        public async Task<IActionResult> LoaiSP(int? id)
        {

            List<Sanpham> hangs = Context.Sanpham.Where(p => p.Hang == id).ToList();
            return PartialView(hangs);
        }

        //Thanh toan

        public IActionResult ThanhToan()
        {

            return View();
        }

        //Dang ký
        // GET: Home/DangKy
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy([Bind("Id,FullName,Role,Diachi,Sdt,Email,Password,RememberToken,CreatedAt,UpdatedAt")] Users users)
        {
            if (ModelState.IsValid)
            {
                Context.Add(users);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(DangKy));
            }
            return View(users);
        }

        //Acount



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Users model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await Context.Users
                .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("Id", userdetails.Id);
                HttpContext.Session.SetString("Password", userdetails.Password);
                HttpContext.Session.SetString("Email", userdetails.Email);

                HttpContext.Session.SetString("ten", userdetails.FullName);
                 


                HttpContext.Session.SetString("diachi", userdetails.Diachi);
                HttpContext.Session.SetString("sdt", userdetails.Sdt);
               
            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("TrangChu", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> Registration(Users model)
        {

            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    FullName = model.FullName,
                    Diachi = model.Diachi,
                    Email = model.Email,
                    Password = model.Password,
                    Sdt = model.Sdt

                };
                Context.Add(user);
                await Context.SaveChangesAsync();

            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("TrangChu", "Home");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
        // update infomation user
        // GET: Users/Edit/5
        //public async Task<IActionResult> TaiKhoan()
        //{
           
        //    return View("TaiKhoan");
        //}
        public async Task<IActionResult> TaiKhoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await Context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaiKhoan(int id, [Bind("Id,FullName,Diachi,Sdt,Email,Password")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     users.Role = "Khach";
                    Context.Update(users);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TrangChu));
            }
            return View("TaiKhoan");
        }
        public async Task<IActionResult> ThayMatKhau(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await Context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThayMatKhau(int id, [Bind("Password")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    users.Role = "Khach";
                    Context.Update(users);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TrangChu));
            }
            return View("TaiKhoan");
        }

        // GET: Hoadons
        public async Task<IActionResult> LichSuDonHang(int? id)
        {
            var get = Context.Chitiethoadon
              .Include(c => c.MahdNavigation)
              .Include(c => c.MaspNavigation)
                .Include(c => c.MahdNavigation.IdkhNavigation)
              .Where(p => p.MahdNavigation.Idkh == id).ToList();
            ViewBag.total = Context.Chitiethoadon.Sum(item => item.Thanhtien);
            return View (get);

        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        private bool UsersExists(int id)
        {
            return Context.Users.Any(e => e.Id == id);
        }
        //xác nhận đơn hàng, thanh toán

        // GET: Hoadons/Create
        //private IActionResult View(Hoadon hoadon, Chitiethoadon chitiethoadon)
        //{
        //    ViewData["Idkh"] = new SelectList(Context.Khachhang, "Id", "Id");
        //    ViewData["Masp"] = new SelectList(Context.Sanpham, "Masp", "Masp", chitiethoadon.Masp);
        //    return View("TrangChu");
        //}

        public IActionResult HoaDon()
        {
            ViewData["Idkh"] = new SelectList(Context.Khachhang, "Id", "Id");
            ViewData["Mahd"] = new SelectList(Context.Hoadon, "Mahd", "Mahd");
            ViewData["Masp"] = new SelectList(Context.Sanpham, "Masp", "Tensp");
            return View("TrangChu");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HoaDon(int id)
        {
            if (ModelState.IsValid)
            {
                //hóa đơn   
                Hoadon hoadon = new Hoadon();               
                hoadon.Ghichu = null;
                hoadon.Ngayhd = DateTime.Now;
                hoadon.Idkh = id;
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                if (cart != null)
                {
                    hoadon.Tongtien = Convert.ToInt32(cart.Sum(item => item.sanpham.Gia * item.Quantity * item.sanpham.Giakhuyenmai));
                }        
                hoadon.Tinhtrang = "chua";

                Context.Add(hoadon);

                await Context.SaveChangesAsync();

                //chi tiết hóa đơn
                foreach (var item in ViewBag.cart)
                {
                    Chitiethoadon cthd = new Chitiethoadon();


                    cthd.Mahd = hoadon.Mahd;
                    cthd.Masp = item.sanpham.Masp;
                    cthd.Soluong = item.Quantity;
                    cthd.Thanhtien = item.sanpham.Gia * item.sanpham.Giakhuyenmai * item.Quantity;
                    cthd.Gia = item.sanpham.Gia * item.sanpham.Giakhuyenmai;
                    Context.Add(cthd);
                  //  ViewData["Mahd"] = new SelectList(Context.Hoadon, "Mahd", "Mahd", cthd.Mahd);
                   // ViewData["Masp"] = new SelectList(Context.Sanpham, "Masp", "Tensp", cthd.Masp);

                }

              



                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(TrangChu));
              
            }
           
         
            //

          
            return View();
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
