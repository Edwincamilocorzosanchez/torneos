using Microsoft.EntityFrameworkCore.Internal;
using torneos.Shared.Context.Helpers;
using torneos.src.Modules.Teams.Application.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Modules.Teams.UI;
using torneos.src.Shared.Helpers;

var context = DbContextFactory.Create();
var repo = new TournamentRepository(context);
var service = new TournamentService(repo);

bool salir = false;
while (!salir)
{
    Console.WriteLine("\n--- MENÚ CRUD ---");
    Console.WriteLine("1. Administrar Torneos");
    Console.WriteLine("2. Salir");
    Console.Write("Opción: ");
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 1:
            await new MenuTournaments(context).RenderMenu();
            break;
        case 2:
            salir = true;
            break;
        default:
            Console.WriteLine("❗ Opción inválida.");
            break;
    }
}