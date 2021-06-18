using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo.Models
{
    public class Prueba
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Por favor ingrese nombre de producto")]
        [Display(Name="Nombre de Producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el precio")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Por favor el estado")]
        public String Status { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
        //public ICollection<ReservaDomicilio> ReservasDomicilio { get; set; }
        
    }
}