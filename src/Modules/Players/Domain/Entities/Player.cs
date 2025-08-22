using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Players.Domain.Entities
{
    public class Player
    {
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string Posicion { get; set; } = string.Empty;
    public decimal ValorMercado { get; set; }
    public int Asistencias { get; set; }
    public int Goles { get; set; }

    // Relación con Team
    public int? TeamId { get; set; }  // clave foránea
    public Team? Team { get; set; }
    }
}