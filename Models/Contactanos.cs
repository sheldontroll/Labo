using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo.Models
{
    [Table("t_contactanos")]

    public class Contactanos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get;set;}

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="Nombre")]
        public string nombres {get;set;}

        public string apellidos {get;set;}

        public string numerocontacto {get;set;}

        public string email {get;set;}

        public string mensaje {get;set;}
    }
}