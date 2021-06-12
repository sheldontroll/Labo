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
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(ILogger<ClienteController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult ClienteIndex()
        {
            return View();
        }

        public IActionResult Reserva()
        {
            ViewBag.DataPruebas = _context.DataPruebas.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));
            return View();
        }
        public IActionResult ReservaDomicilio()
        {
            return View();
        }
        public IActionResult DatosCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DatosCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Reserva");
            }
            return View(c);
        }
        public IActionResult Sintomas()
        {
            return View();
        }
        public IActionResult Pago()
        {
            return View();
        }
        public IActionResult ValidaCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ClienteContacto(Cliente objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "Se ha registrado su mensaje";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}