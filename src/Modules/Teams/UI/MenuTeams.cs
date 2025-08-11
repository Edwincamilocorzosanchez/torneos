using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Infraestructure.Repositories;
using torneos.src.Modules.Teams.Application.Services;
using torneos.src.Shared.Context;
using torneos.src.Modules.Teams.Domain.Entities;
using torneos.src.Modules.TechnicalStaff.Application.Services;
using torneos.src.Modules.TechnicalStaff.Infrastructure.Repositories;
using torneos.src.Modules.TechnicalStaff.Application.Interfaces;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;
using torneos.src.Modules.MedicalBody.Infrastructure.Repositories;
using torneos.src.Modules.MedicalBody.Application.Services;
using torneos.src.Modules.MedicalBody.Domain.Entities;
using torneos.src.Modules.InscripcionTorneo.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using torneos.src.Modules.InscripcionTorneo.Infrastructure.Repositories;
using torneos.src.Modules.InscripcionTorneo.Application.Services;
using torneos.Shared.Context.Helpers;

namespace torneos.src.Modules.Teams.UI;

public class MenuTeams
{
    private readonly AppDbContext _context;
    private readonly InscripcionTorneoRepository _repo;
    private readonly InscripcionTorneoService _serviceInscripcion;
    private readonly TeamService _service = null!;
    private readonly TechnicalStaffService _technicalStaffService = null!;
    private readonly MedicalBodyService _medicalBodyService = null!;


    public async Task MenuMostrar()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("--- MENÚ EQUIPOS ---");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Registrar Cuerpo Médico");
            Console.WriteLine("3. Registrar Cuerpo Técnico");
            Console.WriteLine("4. Inscripcion al torneo");
            Console.WriteLine("5. Salir del torneo");
            Console.WriteLine("6. Salir del menú");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine()!);
            switch (op)
            {
                case 1:
                    await CrearEquipoAsync();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    await CrearCuerpoMedicoAsync();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    await CrearCuerpoTecnicoAsync();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    await new MenuInscripcion(_context).MostrarMenuAsync();
                    Console.Clear();
                    break;
                case 5:
                    await SalirDelTorneoAsync();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 6:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private async Task SalirDelTorneoAsync()
    {
        Console.Write("ID de equipo a retirar del torneo: ");
        if (!int.TryParse(Console.ReadLine(), out var equipoId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }
        Console.Write("ID del torneo: ");
        if (!int.TryParse(Console.ReadLine(), out var torneoId))
        {
            Console.WriteLine("ID de torneo inválido.");
            return;
        }
        // Usar el servicio de inscripción para eliminar la inscripción
        var inscripciones = await _repo.GetAllAsync();
        var inscripcionesEquipoTorneo = inscripciones
            .Where(i => i.TeamId == equipoId && i.TournamentId == torneoId)
            .ToList();
        if (!inscripcionesEquipoTorneo.Any())
        {
            Console.WriteLine("No se encontró inscripción para ese equipo en ese torneo.");
            return;
        }
        foreach (var inscripcion in inscripcionesEquipoTorneo)
        {
            await _repo.DeleteAsync(inscripcion.Id);
        }
        Console.WriteLine("El equipo ha sido retirado del torneo.");
    }

    public MenuTeams(AppDbContext context)
    {
        _context = context;
        _repo = new InscripcionTorneoRepository(_context);
        _serviceInscripcion = new InscripcionTorneoService(_repo);

        var teamRepo = new TeamRepository(_context);
        _service = new TeamService(teamRepo);
        var technicalStaffRepository = new TechnicalStaffRepository(_context);
        _technicalStaffService = new TechnicalStaffService(technicalStaffRepository);
        var medicalBodyRepository = new MedicalBodyRepository(_context);
        _medicalBodyService = new MedicalBodyService(medicalBodyRepository);
    }

    private async Task CrearEquipoAsync()
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }

        var team = new Team { Nombre = nombre.Trim() };
        await _service.RegistrarEquipoAsync(team);
        Console.WriteLine("Equipo creado.");
    }
    private async Task CrearCuerpoTecnicoAsync()
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine();
        Console.Write("Rol: ");
        var rol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }
        if (string.IsNullOrWhiteSpace(rol))
        {
            Console.WriteLine("El rol es obligatorio.");
            return;
        }

        var cuerpoTecnico = new CuerpoTecnico { Nombre = nombre.Trim(), Rol = rol.Trim() };
        await _technicalStaffService.RegistrarCuerpoTecnicoAsync(cuerpoTecnico);
        Console.WriteLine("Cuerpo técnico creado.");
    }

    private async Task CrearCuerpoMedicoAsync()
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine();
        Console.Write("Especialidad: ");
        var especialidad = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }
        if (string.IsNullOrWhiteSpace(especialidad))
        {
            Console.WriteLine("La especialidad es obligatoria.");
            return;
        }

        var cuerpoMedico = new CuerpoMedico { Nombre = nombre.Trim(), Especialidad = especialidad.Trim() };
        await _medicalBodyService.RegistrarCuerpoMedicoAsync(cuerpoMedico);
        Console.WriteLine("Cuerpo médico creado.");
    }
    
    private async Task ListarEquiposAsync()
    {
        var equipos = await _service.ConsultarEquiposAsync();
        if (!equipos.Any())
        {
            Console.WriteLine("No hay equipos registrados.");
            return;

        }

        Console.WriteLine("Equipos:");
        foreach (var e in equipos)
            Console.WriteLine($"ID: {e.Id} | Nombre: {e.Nombre}");
    }
    private async Task ActualizarEquipoAsync()
    {
        Console.Write("ID a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var existente = await _service.ObtenerEquipoPorIdAsync(id);
        if (existente is null)
        {
            Console.WriteLine("Equipo no encontrado.");
            return;
        }

        Console.Write($"Nuevo nombre (actual: {existente.Nombre}): ");
        var nuevoNombre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nuevoNombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }
        else
        {
            existente.Nombre = nuevoNombre;
        }

        await _service.ActualizarEquipoAsync(id, existente);
        Console.WriteLine("Equipo actualizado.");
    }
    private async Task EliminarEquipoAsync()
    {
        Console.Write("ID a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var existente = await _service.ObtenerEquipoPorIdAsync(id);
        if (existente is null)
        {
            Console.WriteLine("Equipo no encontrado.");
            return;
        }

        await _service.EliminarEquipoAsync(id);
        Console.WriteLine("🗑️ Equipo eliminado.");

    }
    private async Task BuscarEquipoPorIdAsync()
    {
        Console.Write("ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var equipo = await _service.ObtenerEquipoPorIdAsync(id);
        if (equipo is null)
        {
            Console.WriteLine("No encontrado.");
            return;
        }

        Console.WriteLine($"Equipo: ID={equipo.Id} | Nombre={equipo.Nombre}");
    }

}