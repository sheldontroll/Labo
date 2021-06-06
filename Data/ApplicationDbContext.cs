using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Labo.Models;

namespace Labo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
                   
       }
        public DbSet<Labo.Models.Reserva> DataReservas { get; set; }
        public DbSet<Labo.Models.Prueba> DataPruebas { get; set; }
        public DbSet<Labo.Models.Contactanos> DataContactanos { get; set; }
        public DbSet<Labo.Models.Cliente> DataClientes { get; set; }
        public DbSet<Labo.Models.OrdenMedica> DataOMs { get; set; }

    }
}


