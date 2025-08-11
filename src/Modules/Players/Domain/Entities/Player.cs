using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.Players.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}