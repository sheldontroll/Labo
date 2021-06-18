using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo.Models
{

    public class OrdenMedica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        public String UserID { get; set; }
        public Prueba Prueba {get; set;}
        public DateTime fechaPrueba { get; set; }
        public string horaPrueba { get; set; }
        public string sedePrueba { get; set; }
        public int Cantidad {get; set;}
        public Decimal Precio { get; set; }
        public String Resultado { get; set; }

      
    }
}