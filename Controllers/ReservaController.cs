using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labo.Data;
using Labo.Models;
using Microsoft.AspNetCore.Identity;

namespace Labo.Controllers
{
    public class ReservaController : Controller
    {        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ReservaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Reserva(Reserva r) {
            var userID = _userManager.GetUserName(User);
            if (ModelState.IsValid) {                
                r.UserID=userID;
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("ValidaCliente");
            }
            return View(r);
        }



    }
}