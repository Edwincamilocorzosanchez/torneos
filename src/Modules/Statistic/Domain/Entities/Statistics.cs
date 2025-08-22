using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Statistic.Domain.Entities
{
    [Keyless]
    public class Statistics
    {


        public string? PlayerName { get; set; }
        public string? TeamName { get; set; }
        public int Value { get; set; }
        public string? Type { get; set; }
    }


    }
