using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Tipodocumento { get; set; }
        public string Documento { get; set; }
        public string Sexo { get; set; }
        public DateTime FecNac { get; set; }
        public string Celular { get; set; }
        public ICollection<OrdenMedica> OrdenMedica { get; set; }
        //public ICollection<Reserva> Reserva { get; set; }
    }
}