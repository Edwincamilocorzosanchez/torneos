using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Infrastructure.Repositories;
using torneos.src.Modules.Teams.Infraestructure.Repositories;
using torneos.src.Modules.Transferencias.Application.Services;
using torneos.src.Modules.Transferencias.Infrastructure.Repositories;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Transferencias.UI
{
    public class TransferenciasMenu
    {
        private readonly TransferenciaService _transferenciaService;

        public TransferenciasMenu(AppDbContext context)
        {
            // Aquí construyes los repositorios con el contexto
            var jugadorRepo = new PlayerRepository(context);
            var equipoRepo = new TeamRepository(context);
            var transferenciaRepo = new TransferenciaRepository(context);

            // Y luego construyes el servicio
            _transferenciaService = new TransferenciaService(jugadorRepo, equipoRepo, transferenciaRepo);
        }

        public async Task MostrarMenuAsync()
        {
            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE TRANSFERENCIAS ===");
                Console.WriteLine("1. Comprar jugador");
                Console.WriteLine("2. Prestar jugador");
                Console.WriteLine("3. Ver transferencias por jugador");
                Console.WriteLine("4. Ver transferencias por equipo");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            await ComprarJugadorAsync();
                            break;
                        case 2:
                            await PrestarJugadorAsync();
                            break;
                        case 3:
                            await VerTransferenciasPorJugadorAsync();
                            break;
                        case 4:
                            await VerTransferenciasPorEquipoAsync();
                            break;
                        case 0:
                            Console.WriteLine("Volviendo al menú principal...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ Error: {ex.Message}");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private async Task ComprarJugadorAsync()
        {
            Console.Write("Ingrese ID del jugador: ");
            int jugadorId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese ID del equipo destino: ");
            int equipoDestinoId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese monto de la compra: ");
            decimal monto = decimal.Parse(Console.ReadLine() ?? "0");

            await _transferenciaService.ComprarJugadorAsync(jugadorId, equipoDestinoId, monto);

            Console.WriteLine("\n✅ Compra realizada con éxito.");
        }

        private async Task PrestarJugadorAsync()
        {
            Console.Write("Ingrese ID del jugador: ");
            int jugadorId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese ID del equipo destino: ");
            int equipoDestinoId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese fecha fin del préstamo (yyyy-MM-dd): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            await _transferenciaService.PrestarJugadorAsync(jugadorId, equipoDestinoId, fechaFin);

            Console.WriteLine("\n✅ Préstamo registrado con éxito.");
        }

        private async Task VerTransferenciasPorJugadorAsync()
        {
            Console.Write("Ingrese ID del jugador: ");
            int jugadorId = int.Parse(Console.ReadLine() ?? "0");

            var transferencias = await _transferenciaService.ObtenerTransferenciasPorJugadorAsync(jugadorId);

            Console.WriteLine("\n=== Transferencias del Jugador ===");
            foreach (var t in transferencias)
            {
                Console.WriteLine($"Jugador: {t?.PlayerId} | Origen: {t?.TeamOrigenId} | Destino: {t?.TeamDestinoId} | Tipo: {t?.Tipo} | Monto: {t?.Monto} | Fecha: {t?.Fecha}");
            }
        }

        private async Task VerTransferenciasPorEquipoAsync()
        {
            Console.Write("Ingrese ID del equipo: ");
            int equipoId = int.Parse(Console.ReadLine() ?? "0");

            var transferencias = await _transferenciaService.ObtenerTransferenciasPorEquipoAsync(equipoId);

            Console.WriteLine("\n=== Transferencias del Equipo ===");
            foreach (var t in transferencias)
            {
                Console.WriteLine($"Jugador: {t?.PlayerId} | Origen: {t?.TeamOrigenId} | Destino: {t?.TeamDestinoId} | Tipo: {t?.Tipo} | Monto: {t?.Monto} | Fecha: {t?.Fecha}");
            }
        }
    }
}