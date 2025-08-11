using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.MedicalBody.Domain.Entities
{
    public class CuerpoMedico
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
    }
}