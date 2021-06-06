using System.Collections.Generic;

namespace Labo.Models
{
    public class Prueba
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Contactanos> Contactanos { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        
    }
}