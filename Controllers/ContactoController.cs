using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labo.Models;
using Labo.Data;

namespace appventas.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;


        public ContactoController(ILogger<ContactoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           
            var listcontactos = _context.DataContactos.ToList();
            ViewData["Message"] = "";
            return View(listcontactos);
        }

        [HttpGet]
        public IActionResult Reserva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserva(Contacto objReserva)
        {
            objReserva.Status = "Registrado";
            ViewData["Message"] = "El contacto ya esta " + objReserva.Status;
            return View();
        }

    }
}