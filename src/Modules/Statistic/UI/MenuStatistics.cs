using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Statistic.Application.Interfaces;
using torneos.src.Modules.Statistic.Application.Services;
using torneos.src.Modules.Statistic.Infrastructure.Repositories;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Statistic.UI
{
    public class MenuStatistics
    {
    private readonly AppDbContext _context;
    readonly StatisticRepository _repo = null!;
    readonly StatisticService _service = null!;
    public MenuStatistics(AppDbContext context)
    {
        _context = context;
        _repo = new StatisticRepository(context);
        _service = new StatisticService(_repo);
    }

        public void Show()
        {
            int option = -1;
            while (option != 0)
            {
                Console.WriteLine("\n=== Estadísticas ===");
                Console.WriteLine("1. Jugadores con más asistencias");
                Console.WriteLine("2. Equipos con más goles en contra");
                Console.WriteLine("3. Jugadores más caros por equipo");
                Console.WriteLine("4. Jugadores menores al promedio de edad por equipo");
                Console.WriteLine("0. Volver");
                Console.Write("Elige: ");
                option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Jugadores con más asistencias:");
                        ShowPlayersWithMostAssists();
                        break;
                    case 2:
                        Console.WriteLine("Equipos con más goles en contra:");
                        ShowPlayersWithMostOwnGoals();
                        break;
                    case 3:
                        Console.WriteLine("Jugadores más caros por equipo:");
                        ShowMostExpensivePlayersByTeam();
                        break;
                    case 4:
                        Console.WriteLine("Jugadores menores al promedio de edad por equipo:");
                        ShowYoungerPlayersThanAverageByTeam();
                        break;
                }
            }
        }

        private void ShowPlayersWithMostAssists()
        {
            _service.ShowPlayersWithMostAssists();
        }

        private void ShowPlayersWithMostOwnGoals()
        {
            _service.ShowPlayersWithMostOwnGoals();
        }

        private void ShowMostExpensivePlayersByTeam()
        {
            _service.ShowMostValuablePlayersByTeam();
        }

        private void ShowYoungerPlayersThanAverageByTeam()
        {
            _service.ShowYoungPlayersBelowAverageByTeam();
        }
    }
}