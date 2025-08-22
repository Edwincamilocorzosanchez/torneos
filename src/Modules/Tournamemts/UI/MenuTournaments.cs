using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Infraestructure.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Modules.Teams.Domain.Entities;
using torneos.src.Modules.Tournaments.Infraestructure;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Teams.UI;

public class MenuTournaments
{
    private readonly AppDbContext _context;
    readonly TournamentRepository repo = null!;
    readonly TournamentService service = null!;
    public MenuTournaments(AppDbContext context)
    {
        _context = context;
        repo = new TournamentRepository(context);
        service = new TournamentService(repo);
    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ CRUD ---");
            Console.WriteLine("1. Crear torneo");
            Console.WriteLine("2. Listar torneos ");
            Console.WriteLine("3. Actualizar torneo");
            Console.WriteLine("4. Eliminar torneo");
            Console.WriteLine("5. Buscar torneo por ID");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Fecha de inicio (yyyy-mm-dd): ");
                    DateTime fechaInicio = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Fecha de fin (yyyy-mm-dd): ");
                    DateTime fechaFin = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Ubicación: ");
                    string? ubicacion = Console.ReadLine();
                    await service.RegistrarTorneoAsync(nombre!, fechaInicio, fechaFin, ubicacion!);
                    Console.WriteLine("✅ Torneo creado.");
                    break;
                case 2:
                    var lista = await service.ConsultarTorneosAsync();
                    foreach (var u in lista)
                        Console.WriteLine($"ID:{u.Id} | {u.Nombre}");
                    break;
                case 3:
                    Console.Write("ID a actualizar: ");
                    int idUp = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string? nuevoNombre = Console.ReadLine();
                    Console.Write("Nueva fecha de inicio (yyyy-mm-dd): ");
                    DateTime nuevaFechaInicio = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Nueva fecha de fin (yyyy-mm-dd): ");
                    DateTime nuevaFechaFin = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Nueva ubicación: ");
                    string? nuevaUbicacion = Console.ReadLine();
                    await service.ActualizarTorneo(idUp, nuevoNombre!, nuevaFechaInicio, nuevaFechaFin, nuevaUbicacion!);
                    Console.WriteLine("✏️ Actualizado.");
                    break;
                case 4:
                    Console.Write("ID a eliminar: ");
                    int idDel = int.Parse(Console.ReadLine()!);
                    await service.EliminarTorneo(idDel);
                    Console.WriteLine("🗑️ Eliminado.");
                    break;
                case 5:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Tournament? torneo = await service.ObtenerTorneoPorIdAsync(id);
                    if (torneo != null)
                        Console.WriteLine($"👤 {torneo.Nombre}");
                    else
                        Console.WriteLine("❌ No encontrado.");
                    break;
                case 6:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("❗ Opción inválida.");
                    break;
            }


        }
    }
}