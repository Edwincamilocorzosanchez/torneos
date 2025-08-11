using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.TechnicalStaff.Domain.Entities
{
    public class CuerpoTecnico
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Rol { get; set; }
    }
}