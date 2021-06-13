using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Labo.Data;
using Labo.Models;
using Microsoft.AspNetCore.Identity;


namespace Labo.Controllers
{
    public class OrdenMedicaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrdenMedicaController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdenMedicaController(ILogger<OrdenMedicaController> logger, 
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Cantidad,Precio,Resultado")] OrdenMedica OM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(OM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });             
            }
        }
    }
}