using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labo.Models;

namespace Labo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult ClienteIndex()
        {
            return View();
        }

        public IActionResult Reserva(ContactoReserva objReserva)
        {           
            return View();
        }
        public IActionResult ReservaDomicilio(ContactoReserva objReserva)
        {
            return View();
        }
        public IActionResult DatosCliente(ContactoReserva objReserva)
        {
            return View();
        }
        public IActionResult Sintomas(ContactoReserva objReserva)
        {
            return View();
        }
        public IActionResult Pago(ContactoReserva objReserva)
        {
            return View();
        }
        public IActionResult ValidaCliente(ContactoReserva objReserva)
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