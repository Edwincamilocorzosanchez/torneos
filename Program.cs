using Microsoft.EntityFrameworkCore.Internal;
using torneos.Shared.Context.Helpers;
using torneos.src.Modules.Teams.Infraestructure.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Modules.Teams.UI;
using torneos.src.Modules.Tournaments.Infraestructure;
using torneos.src.Shared.Helpers;
using torneos.src.Modules.Players.UI;
using System.Diagnostics;
using torneos.src.Modules.Transferencias.UI;
using torneos.src.Modules.Transferencias.Application.Interfaces;
using torneos.src.Modules.Transferencias.Application.Services;
using torneos.src.Modules.Statistic.Application.Interfaces;
using torneos.src.Modules.Statistic.Application.Services;
using torneos.src.Modules.Statistic.UI;
using torneos.src.Modules.Statistic.Infrastructure.Repositories;

var context = DbContextFactory.Create();
var repo = new TournamentRepository(context);
var service = new TournamentService(repo);



bool salir = false;
while (!salir)
{
    Console.WriteLine("\n--- MENÚ CRUD ---");
    Console.WriteLine("0. Crear torneo");
    Console.WriteLine("1. Registro equipos");
    Console.WriteLine("2. Registro Jugadores");
    Console.WriteLine("3. Transferencias (Prestamo, Compra)");
    Console.WriteLine("4. Estadisticas");
    Console.WriteLine("5. Salir");
    Console.Write("Opción: ");
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 0:
            await new MenuTournaments(context).RenderMenu();
            break;
        case 1:
            await new MenuTeams(context).MenuMostrar();
            break;
        case 2:
            await new MenuPlayer(context).Menu();
            break;
        case 3:
            await new TransferenciasMenu(context).MostrarMenuAsync();
            break;
        case 4:
            var statistics = new MenuStatistics(context);
            statistics.Show();
            break;
        case 5:
            salir = true;
            break;
        default:
            Console.WriteLine("❗ Opción inválida.");
            break;
    }
}

