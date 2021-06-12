using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labo.Data;
using Labo.Models;
namespace Labo.Controllers
{
    public class ContactanosController : Controller
    {
        private readonly ILogger<ContactanosController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactanosController(ILogger<ContactanosController> logger,
            ApplicationDbContext context
            )
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IActionResult Nocliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Nocliente(Contactanos objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "Se ha registrado su mensaje";
            return View();
        }

    }
}