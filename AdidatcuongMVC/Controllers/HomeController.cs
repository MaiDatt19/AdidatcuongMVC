using AdidatcuongMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdidatcuongMVC.Data;
using AdidatcuongMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AdidatcuongMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdidatcuongMVCContext _context;

        public HomeController(AdidatcuongMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var order = new Orders();
            order.AgentEmail = HttpContext.Session.GetString("email");
            order.Status = "Waiting";
            _context.Add(order);
            await _context.SaveChangesAsync();

            var productwithimage = await (from product in _context.Product
                                          join image in _context.PImage on product.ProductID equals image.ProductID
                                          select new ProductViewModel()
                                          {
                                              product = product,
                                              pImage = image
                                          }).ToListAsync();
            var data = _context.Orders.Where(s => s.AgentEmail == (HttpContext.Session.GetString("email"))).ToList();
            var newOrder = data.FirstOrDefault();
            string orderID = newOrder.OrderID;

            HttpContext.Session.SetString("orderID", "OD001");
            return View(productwithimage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
