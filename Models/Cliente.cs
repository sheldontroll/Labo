using System.Collections.Generic;

namespace Labo.Models
{
    public class Cliente    {

        public int Id { get; set; }
        public ICollection<OrdenMedica> OrdenMedica { get; set; }  
    }
}