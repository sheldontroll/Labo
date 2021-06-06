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
        public AdministradorController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult pruebas() {
            var pruebas = _context.DataPruebas.OrderBy(r => r.Nombre).ToList();
            return View(pruebas);
        }
        public IActionResult AdminIndex() {
            return View();
        }
        public IActionResult ListaCliente() {
            return View();
        }
        public IActionResult Mensaje() {
            return View();
        }
        public IActionResult OrdenesMedicas() {
            return View();
        }
        public IActionResult nuevaPrueba() {
            return View();
        }

        [HttpPost]
        public IActionResult nuevaPrueba(Prueba r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("pruebas");
            }
            return View(r);
        }


        [HttpPost]
        public IActionResult BorrarPrueba(int id) {
            var prueba = _context.DataPruebas.Find(id);
            _context.Remove(prueba);
            _context.SaveChanges();

            return RedirectToAction("pruebas");
        }

        public IActionResult editarPrueba(int id) {
            var prueba = _context.DataPruebas.Find(id);
            return View(prueba);
        }

        [HttpPost]
        public IActionResult editarPrueba(Prueba r) {
            if (ModelState.IsValid) {
                var prueba = _context.DataPruebas.Find(r.Id);
                prueba.Nombre = r.Nombre;
                _context.SaveChanges();
                return RedirectToAction("pruebas");
            }
            return View(r);
        }

    }
}