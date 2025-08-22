using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Statistic.Domain.Entities;

namespace torneos.src.Modules.Statistic.Application.Interfaces
{
    public interface IStatisticRepository
    {
        IEnumerable<Statistics> GetTopAssists();
        IEnumerable<Statistics> GetTopOwnGoals();
        IEnumerable<Statistics> GetMostExpensiveByTeam();
        IEnumerable<Statistics>  GetYoungerThanAverageByTeam();
    }
}