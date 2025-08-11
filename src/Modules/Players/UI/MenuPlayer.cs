using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Application.Services;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Modules.Players.Infrastructure.Repositories;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Players.UI
{
    public class MenuPlayer
    {
        private readonly AppDbContext _context;
        readonly PlayerRepository repo = null!;
        readonly PlayerService service = null!;
        public MenuPlayer(AppDbContext context)
        {
            _context = context;
            repo = new PlayerRepository(context);
            service = new PlayerService(repo);
        }
        public async Task Menu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1. Crear Jugador");
                Console.WriteLine("2. Listar Jugadores ");
                Console.WriteLine("3. Actualizar Jugador");
                Console.WriteLine("4. Eliminar Jugador");
                Console.WriteLine("5. Buscar Jugador por ID");
                Console.WriteLine("6. Salir");
                Console.Write("Opción: ");
                int op = int.Parse(Console.ReadLine()!);

                switch (op)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string? nombre = Console.ReadLine();
                        await service.RegistrarJugadorAsync(nombre!);
                        Console.WriteLine("✅ Torneo creado.");
                        break;
                    case 2:
                        var lista = await service.ConsultarJugadoresAsync();
                        foreach (var u in lista)
                            Console.WriteLine($"ID:{u.Id} | {u.Nombre}");
                        break;
                    case 3:
                        Console.Write("ID a actualizar: ");
                        int idUp = int.Parse(Console.ReadLine()!);
                        Console.Write("Nuevo nombre: ");
                        string? nuevoNombre = Console.ReadLine();
                        await service.ActualizarJugador(idUp, nuevoNombre!);
                        Console.WriteLine("✏️ Actualizado.");
                        break;
                    case 4:
                        Console.Write("ID a eliminar: ");
                        int idDel = int.Parse(Console.ReadLine()!);
                        await service.EliminarJugador(idDel);
                        Console.WriteLine("🗑️ Eliminado.");
                        break;
                    case 5:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Player? jugador = await service.ObtenerJugadorPorIdAsync(id);
                        if (jugador != null)
                            Console.WriteLine($"👤 {jugador.Nombre}");
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
    
}