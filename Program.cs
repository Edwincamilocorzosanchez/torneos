using Microsoft.EntityFrameworkCore.Internal;
using torneos.Shared.Context.Helpers;
using torneos.src.Modules.Teams.Application.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Shared.Helpers;

var context = DbContextFactory.Create();
var repo = new TeamRepository(context);
var service = new TeamService(repo);

bool salir = false;
while (!salir)
{
    Console.WriteLine("1. Crear equipo");
    Console.WriteLine("2. Listar equipos");
    Console.WriteLine("3. Actualizar equipo");
    Console.WriteLine("4. Eliminar equipo");
    Console.WriteLine("5. Obtener equipo por ID");
    Console.WriteLine("6. Salir");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            await service.RegistrarEquipoAsync(nombre!);
            Console.WriteLine("✅ Equipo creado.");
            break;
        case "2":
            var lista = await service.ConsultarEquiposAsync();
            foreach (var u in lista)
                Console.WriteLine($"ID:{u.Id} | {u.Nombre}");
            break;
        case "3":
            Console.Write("ID a actualizar: ");
            var idUp = int.Parse(Console.ReadLine()!);
            Console.Write("Nuevo nombre: ");
            var nuevoNombre = Console.ReadLine();
            await service.ActualizarEquipo(idUp, nuevoNombre!);
            Console.WriteLine("✏️ Actualizado.");
            break;
        case "4":
            Console.Write("ID a eliminar: ");
            var idDel = int.Parse(Console.ReadLine()!);
            await service.EliminarEquipo(idDel);
            Console.WriteLine("🗑️ Eliminado.");
            break;
        case "5":
            Console.Write("ID: ");
            var id = int.Parse(Console.ReadLine()!);
            var equipo = await service.ObtenerEquipoPorIdAsync(id);
            if (equipo != null)
                Console.WriteLine($"👤 {equipo.Nombre}");
            else
                Console.WriteLine("❌ No encontrado.");
            break;
        case "6":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}