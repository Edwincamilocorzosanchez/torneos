using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Statistic.Application.Interfaces;
using torneos.src.Modules.Statistic.Infrastructure.Repositories;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Statistic.Application.Services
{
    public class StatisticService : IStatisticService
    {

    private readonly IStatisticRepository _repo;

    public StatisticService(IStatisticRepository repo)
    {
        _repo = repo;
    }



        public void ShowPlayersWithMostAssists()
        {
            var players = _repo.GetTopAssists()
                .OrderByDescending(s => s.Value)
                .ToList();

            foreach (var p in players)
                Console.WriteLine($"{p.PlayerName} - {p.Value} asistencias");
        }

        public void ShowPlayersWithMostOwnGoals()
        {
            var players = _repo.GetTopOwnGoals()
                .OrderByDescending(s => s.Value)
                .ToList();

            foreach (var t in players)
                Console.WriteLine($"{t.TeamName} - {t.Value} goles en contra");
        }

        public void ShowMostValuablePlayersByTeam()
        {
            var players = _repo. GetMostExpensiveByTeam()
                .GroupBy(s => s.TeamName)
                .Select(g => g.OrderByDescending(s => s.Value).FirstOrDefault())
                .ToList();

            foreach (var p in players)
                Console.WriteLine($"{p.TeamName}: {p.PlayerName} - ${p.Value}M");
        }

        public void ShowYoungPlayersBelowAverageByTeam()
        {
            var players = _repo.GetYoungerThanAverageByTeam()
                .GroupBy(s => s.TeamName)
                .Select(g => g.OrderBy(s => s.Value).FirstOrDefault())
                .ToList();

            foreach (var p in players)
                Console.WriteLine($"{p.TeamName}: {p.PlayerName} - {p.Value} años");
        }
    }
}