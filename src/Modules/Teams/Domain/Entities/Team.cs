using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.Teams.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}