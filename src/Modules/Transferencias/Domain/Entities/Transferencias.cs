using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.Transferencias.Domain.Entities
{
    public class Transferencia
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamOrigenId { get; set; }
        public int TeamDestinoId { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.Now;
    }

}