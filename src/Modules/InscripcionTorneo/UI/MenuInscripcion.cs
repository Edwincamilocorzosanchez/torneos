using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.InscripcionTorneo.Application.Services;
using torneos.src.Modules.InscripcionTorneo.Infrastructure.Repositories;
using torneos.src.Shared.Context;
namespace torneos.src.Modules.InscripcionTorneo.UI
{
    

    public class MenuInscripcion
    {
        readonly InscripcionTorneoService _service = null!;
        public MenuInscripcion(AppDbContext context)
        {
            _service = new InscripcionTorneoService(new InscripcionTorneoRepository(context));
        }

        public async Task MostrarMenuAsync()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("--- MENÚ INSCRIPCIÓN TORNEO ---");
                Console.WriteLine("1. Inscribir equipo");
                Console.WriteLine("2. Inscribir cuerpo médico");
                Console.WriteLine("3. Inscribir cuerpo técnico");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                int op = int.Parse(Console.ReadLine()!);
                switch (op)
                {
                    case 1:
                        await InscribirEquipoAsync();
                        break;
                    case 2:
                        await InscribirCuerpoMedicoAsync();
                        break;
                    case 3:
                        await InscribirCuerpoTecnicoAsync();
                        break;
                    case 4:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private async Task InscribirEquipoAsync()
        {
            Console.Write("ID Equipo: ");
            int equipoId = int.Parse(Console.ReadLine()!);
            Console.Write("ID Torneo: ");
            int torneoId = int.Parse(Console.ReadLine()!);
            await _service.InscribirEquipoAsync(equipoId, torneoId);
            Console.WriteLine("Equipo inscrito.");
        }

        private async Task InscribirCuerpoMedicoAsync()
        {
            Console.Write("ID Equipo: ");
            int equipoId = int.Parse(Console.ReadLine()!);
            Console.Write("ID Torneo: ");
            int torneoId = int.Parse(Console.ReadLine()!);
            Console.Write("ID Cuerpo Médico: ");
            int cuerpoMedicoId = int.Parse(Console.ReadLine()!);
            await _service.InscribirCuerpoMedicoAsync(equipoId, torneoId, cuerpoMedicoId);
            Console.WriteLine("Cuerpo médico inscrito.");
        }

        private async Task InscribirCuerpoTecnicoAsync()
        {
            Console.Write("ID Equipo: ");
            int equipoId = int.Parse(Console.ReadLine()!);
            Console.Write("ID Torneo: ");
            int torneoId = int.Parse(Console.ReadLine()!);
            Console.Write("ID Cuerpo Técnico: ");
            int cuerpoTecnicoId = int.Parse(Console.ReadLine()!);
            await _service.InscribirCuerpoTecnicoAsync(equipoId, torneoId, cuerpoTecnicoId);
            Console.WriteLine("Cuerpo técnico inscrito.");
        }
    }
}