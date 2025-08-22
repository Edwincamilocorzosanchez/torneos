using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.Statistic.Application.Interfaces
{
    public interface IStatisticService
    {
        void ShowPlayersWithMostAssists();
        void ShowPlayersWithMostOwnGoals();
        void ShowMostValuablePlayersByTeam();
        void ShowYoungPlayersBelowAverageByTeam();
    }
}