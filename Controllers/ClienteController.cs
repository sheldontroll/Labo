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
        public ClienteController(ApplicationDbContext context) {
            _context = context;
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

       
         [HttpPost]  
        public ActionResult Reserva(Reserva r)  
        {  
    //    r.horaPrueba = PopulateHora();  
      //  var selectedItem = r.Fruits.Find(p => p.Value == r.FruitId.ToString());  
     //   if (selectedItem != null)  
      //  {  
      //      selectedItem.Selected = true;  
      //      ViewBag.Message = "Fruit: " + selectedItem.Text;  
      //      ViewBag.Message += "\\nQuantity: " + r.Quantity;  
     //   }  
   
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}