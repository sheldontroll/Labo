using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labo.Data;
using Microsoft.EntityFrameworkCore;
using Labo.Models;

namespace Labo.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdministradorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult pruebas()
        {
            var pruebas = _context.DataPruebas.OrderBy(r => r.Id).ToList();
            return View(pruebas);
        }



        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult ListaCliente()
        {
            var clientes = _context.Clientes.OrderBy(r => r.Nombre).ToList();
            return View(clientes);
        }
        [HttpPost]
        public IActionResult BorrarCliente(int Id)
        {
            var clientes = _context.Clientes.Find(Id);
            _context.Remove(clientes);
            _context.SaveChanges();
            return RedirectToAction("ListaCliente");
        }
        [HttpPost]
        public IActionResult ClienteInfo()
        {
            return RedirectToAction("ClienteInfo");
        }
        public IActionResult Mensaje()
        {
            var mensajes = _context.DataContactanos.OrderBy(r => r.nombres).ToList();
            return View(mensajes);
        }

        [HttpPost]
        public IActionResult BorrarMensaje(int ID)
        {
            var mensajes = _context.DataContactanos.Find(ID);
            _context.Remove(mensajes);
            _context.SaveChanges();

            return RedirectToAction("Mensaje");
        }
        public IActionResult OrdenesMedicas()
        {
            return View();
        }
        public IActionResult nuevaPrueba()
        {
            return View();
        }

        [HttpPost]
        public IActionResult nuevaPrueba(Prueba r)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("pruebas");
            }
            return View(r);
        }

        [HttpPost]
        public IActionResult BorrarPrueba(int id)
        {
            var prueba = _context.DataPruebas.Find(id);
            _context.Remove(prueba);
            _context.SaveChanges();

            return RedirectToAction("pruebas");
        }

        public async Task<IActionResult> editarPrueba(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pruebas = await _context.DataPruebas.FindAsync(id);
            if (pruebas == null)
            {
                return NotFound();
            }
            return View(pruebas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editarPrueba(int id, [Bind("Id,Nombre,Cantidad,Price,Status")] Prueba prueba)
        {
            if (id != prueba.Id){
                return NotFound();
            }

            if (ModelState.IsValid){
                try{
                    _context.Update(prueba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException){
                    if (!PruebaExists(prueba.Id))
                    {
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("pruebas");
            }
            return View();
        }

        private bool PruebaExists(int id){
            return _context.DataPruebas.Any(e => e.Id == id);
        }

    }
}
