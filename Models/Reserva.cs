using System.Collections.Generic;

namespace Labo.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string fechaPrueba { get; set; }
        public string horaPrueba { get; set; }
        public Prueba Prueba { get; set; }
        public int PruebaId { get; set; }         
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<OrdenMedica> OrdenMedica { get; set; }
        
    }
}


