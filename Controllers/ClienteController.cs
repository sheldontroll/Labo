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
using Microsoft.AspNetCore.Identity;

namespace Labo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClienteController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public ClienteController(ILogger<ClienteController> logger,
        UserManager<IdentityUser> userManager, 
        ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
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

        public IActionResult ValidaCliente()
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

        public IActionResult Pago()
        {
            return View();
        }
        public async Task<IActionResult> ValidaCliente(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var OM = await _context.DataOMs.FindAsync(Id);
            if (OM == null)
            {
                return NotFound();
            }

            return View(OM);
        }

        public IActionResult Agenda()
        {
            var userID = _userManager.GetUserName(User);
            var agenda = _context.DataOMs;
            Console.WriteLine(" " + userID);
            List<OrdenMedica> lomd = new List<OrdenMedica>();
            foreach (var item in agenda)
            {
                if (item.UserID.Equals(userID))
                {
                    lomd.Add(item);
                }
            }
        
            return View(lomd);
        }   



        [HttpPost]
        public IActionResult ClienteContacto(Cliente objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "Se ha registrado su mensaje";
            return View();
        }     
        [HttpPost]
         public async Task<IActionResult> Add(String PruebaId, String sedePrueba, DateTime fechaPrueba, String horaPrueba)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
            }else{
                var id = Convert.ToInt32(PruebaId);
                var prueba = await _context.DataPruebas.FindAsync(id);
                OrdenMedica OM = new OrdenMedica();
                Reserva reserva = new Reserva();
                OM.Prueba = prueba;
                OM.Precio = prueba.Price;
                OM.Cantidad = 1;
                OM.Resultado = "Pendiente";
                OM.UserID = userID;
                OM.sedePrueba = sedePrueba;
                OM.fechaPrueba = fechaPrueba;
                OM.horaPrueba = horaPrueba;
                reserva.Prueba = prueba;
                reserva.UserID = userID;
                reserva.sedePrueba = sedePrueba;
                reserva.fechaPrueba = fechaPrueba;
                reserva.horaPrueba = horaPrueba;
                _context.Add(reserva);
                _context.Add(OM);
                await ValidaCliente(OM.id);
                await _context.SaveChangesAsync();
                return RedirectToAction("ValidaCliente");
                
            }
            return View();
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
        public IActionResult Resultado(){
            var resultados =  _context.DataOMs.OrderBy(x => x.Resultado).ToList();
            return View(resultados);
    }
}
}