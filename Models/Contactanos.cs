using System.Collections.Generic;

namespace Labo.Models
{
    public class Contactanos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int numero { get; set; }
        public Prueba Prueba { get; set; }
        public int PruebaId { get; set; } 
        public string Mensaje { get; set; }
        public ICollection<Reserva> Reservas { get; set; }  
    }
}