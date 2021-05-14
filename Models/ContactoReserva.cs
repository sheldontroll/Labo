using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Labo.Models
{
        [Table("t_contacto")]

    public class ContactoReserva
    {
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("email")]
        public string email { get; set; }
                [Column("direc1")]

        public string direc1{ get; set; }
                [Column("direc2")]

        public string direc2{ get; set; }
                [Column("ciudad")]
        public string ciudad { get; set; } 
                [Column("id")]

         public int id { get; set; }

    }
}