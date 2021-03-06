using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {            
        }
        public DbSet<Labo.Models.Prueba> DataPruebas { get; set; }
        public DbSet<Labo.Models.Cliente> Clientes { get; set; }
        public DbSet<Labo.Models.Reserva> Reservas { get; set; }
        public DbSet<Labo.Models.Contactanos> DataContactanos {get;set;}
        public DbSet<Labo.Models.OrdenMedica> DataOMs {get;set;}
    }
}
