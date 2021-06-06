using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labo.Models;
using Labo.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

      //  public HomeController(ILogger<HomeController> logger)        {
      //      _logger = logger;
      //  }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contactanos() 
        {
            ViewBag.DataPruebas = _context.DataPruebas.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));  
            return View();
        }

        [HttpPost]
        public IActionResult Contactanos(Contactanos r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("ContactanosConfirmacion");
            }
            return View(r);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
