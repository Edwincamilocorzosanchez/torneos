using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Application.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Modules.Teams.Domain.Entities;
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
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Listar Usuarios");
            Console.WriteLine("3. Actualizar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Buscar Usuario por ID");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string? nombre = Console.ReadLine();
                    await service.RegistrarTorneoAsync(nombre!);
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
                    await service.ActualizarTorneo(idUp, nuevoNombre!);
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