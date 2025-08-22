using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Modules.Statistic.Application.Interfaces;
using torneos.src.Modules.Statistic.Domain.Entities;
using torneos.src.Modules.Teams.Domain.Entities;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Statistic.Infrastructure.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly AppDbContext _Context;

        public StatisticRepository(AppDbContext context)
        {
            _Context = context;
        }

    public IEnumerable<Statistics> GetTopAssists()
    {
        return _Context.Players
            .OrderByDescending(p => p.Asistencias)
            .Take(10)
            .Select(p => new Statistics
            {
                PlayerName = p.Nombre,
                TeamName = p.Team.Nombre, // si tienes la relación configurada
                Value = p.Asistencias,
                Type = "Asistencias"
            })
            .ToList();
    }

    public IEnumerable<Statistics> GetMostExpensiveByTeam()
    {
        return _Context.Players
            .GroupBy(p => p.TeamId)
            .Select(g => new Statistics
            {
                PlayerName = g.OrderByDescending(p => p.ValorMercado).First().Nombre,
                TeamName = g.Key != null ? g.First().Team.Nombre : "Sin equipo",
                Value = (int)g.Max(p => p.ValorMercado),
                Type = "MostExpensive"
            })
            .ToList();
    }

    public IEnumerable<Statistics> GetYoungerThanAverageByTeam()
    {
    return _Context.Players
        .Where(p => p.Team != null) // 🔹 solo jugadores con equipo asignado
        .AsEnumerable() // 🔹 fuerza a LINQ-to-Objects (ya no SQL)
        .GroupBy(p => p.TeamId)
        .SelectMany(g =>
        {
            var avgAge = g.Average(p => p.Edad);
            return g.Where(p => p.Edad < avgAge)
                    .Select(p => new Statistics
                    {
                        PlayerName = p.Nombre,
                        TeamName = p.Team?.Nombre ?? "Sin equipo", // null-safe
                        Value = p.Edad,
                        Type = "YoungerThanAverage"
                    });
        })
        .ToList();
    }

        public IEnumerable<Statistics> GetTopOwnGoals()
        {
        return _Context.Teams
            .OrderByDescending(t => t.GolesEnContra)
            .Take(10)
            .Select(t => new Statistics
            {
                TeamName = t.Nombre,
                Value = t.GolesEnContra,
                Type = "OwnGoals"
            })
            .ToList();
        }
    }
}