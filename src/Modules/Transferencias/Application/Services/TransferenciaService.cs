using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Application.Interfaces;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Modules.Teams.Application.Interfaces;
using torneos.src.Modules.Transferencias.Application.Interfaces;
using torneos.src.Modules.Transferencias.Domain.Entities;

namespace torneos.src.Modules.Transferencias.Application.Services
{
    public class TransferenciaService : ITransferenciaService
{
    
    private readonly IPlayerRepository _jugadorRepository;
    private readonly ITeamRepository _equipoRepository;
    private readonly ITransferenciaRepository _transferenciaRepository;

    public TransferenciaService(
        IPlayerRepository jugadorRepository,
        ITeamRepository equipoRepository,
        ITransferenciaRepository transferenciaRepository)
    {
        _jugadorRepository = jugadorRepository;
        _equipoRepository = equipoRepository;
        _transferenciaRepository = transferenciaRepository;
    }



        public async Task ComprarJugadorAsync(int jugadorId, int equipoDestinoId, decimal monto)
{
    var jugador = await _jugadorRepository.GetByIdAsync(jugadorId);
    if (jugador == null) throw new Exception("Jugador no encontrado");

    if (jugador.TeamId == equipoDestinoId)
        throw new Exception("El jugador ya pertenece a este equipo");

    var equipoDestino = await _equipoRepository.GetByIdAsync(equipoDestinoId);
    if (equipoDestino == null) throw new Exception("Equipo destino no encontrado");

    var transferencia = new Transferencia
    {
        PlayerId = jugadorId,
        TeamOrigenId = jugador.TeamId ?? null,
        TeamDestinoId = equipoDestinoId,
        Monto = monto,
        Tipo = "Compra",
        Fecha = DateTime.Now
    };

    await _transferenciaRepository.AddAsync(transferencia);
    
    try
    {
        await _transferenciaRepository.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar transferencia: {ex.InnerException?.Message}");
    }

    // Cambiar equipo
            jugador.TeamId = equipoDestinoId;
    await _jugadorRepository.UpdateAsync(jugador);
}

public async Task PrestarJugadorAsync(int jugadorId, int equipoDestinoId, DateTime fechaFin)
{
    var jugador = await _jugadorRepository.GetByIdAsync(jugadorId);
    if (jugador == null) throw new Exception("Jugador no encontrado");

    var equipoDestino = await _equipoRepository.GetByIdAsync(equipoDestinoId);
    if (equipoDestino == null) throw new Exception("Equipo destino no encontrado");

    var transferencia = new Transferencia
    {
        PlayerId = jugadorId,
        TeamOrigenId = jugador.TeamId ?? null,
        TeamDestinoId = equipoDestinoId,
        Tipo = "Préstamo",
        Fecha = DateTime.Now,

    };

    await _transferenciaRepository.AddAsync(transferencia);


}

public async Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorJugadorAsync(int jugadorId)
{
    var transferencias = await _transferenciaRepository.GetAllAsync();
    return transferencias.Where(t => t.PlayerId == jugadorId).ToList();
}

public async Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorEquipoAsync(int equipoId)
{
    var transferencias = await _transferenciaRepository.GetAllAsync();
    return transferencias
        .Where(t => t.TeamDestinoId == equipoId || t.TeamOrigenId == equipoId)
        .ToList();
}

}

}