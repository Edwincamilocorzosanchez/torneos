using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Domain.Entities;

namespace torneos.src.Modules.Teams.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public string? Ciudad { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}