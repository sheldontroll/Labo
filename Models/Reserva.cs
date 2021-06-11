using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Labo.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public String UserID { get; set; }

        [Required(ErrorMessage = "Por favor selecciona la fecha")]
        public DateTime fechaPrueba { get; set; }

        [Required(ErrorMessage = "Por favor selecciona la hora")]
        public string horaPrueba { get; set; }

        [Required(ErrorMessage = "Por favor selecciona tu Sede")]
        public string sedePrueba { get; set; }

        [Required(ErrorMessage = "Por favor selecciona el tipo de prueba")]
        public Prueba Prueba { get; set; }
        public int PruebaId { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<OrdenMedica> OrdenMedica { get; set; }

    }
}