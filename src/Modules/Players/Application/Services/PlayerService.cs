using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Application.Interfaces;
using torneos.src.Modules.Players.Domain.Entities;

namespace torneos.src.Modules.Players.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repo;

    public PlayerService(IPlayerRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Player>> ConsultarJugadoresAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarJugadorAsync(string nombre, int edad, string posicion, decimal valorMercado, int asistencias, int goles)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Nombre == nombre))
            throw new Exception("El jugador ya existe.");

        var player = new Player
        {
            Nombre = nombre,
            Edad = edad,
            Posicion = posicion,
            ValorMercado = valorMercado,
            Asistencias = asistencias,
            Goles = goles
        };

        await _repo.AddAsync(player);
        await _repo.SaveAsync();
    }
    public async Task ActualizarJugador(int id, string nuevoNombre, int nuevaEdad, string nuevaPosicion, decimal nuevoValorMercado, int nuevasAsistencias, int nuevosGoles)
    {
        var player = await _repo.GetByIdAsync(id);

        if (player == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");

        player.Nombre = nuevoNombre;
        player.Edad = nuevaEdad;
        player.Posicion = nuevaPosicion;
        player.ValorMercado = nuevoValorMercado;
        player.Asistencias = nuevasAsistencias;
        player.Goles = nuevosGoles;

        await _repo.UpdateAsync(player);
        await _repo.SaveAsync();
    }

    public async Task EliminarJugador(int id)
    {
        var player = await _repo.GetByIdAsync(id);
        if (player == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");
        await _repo.RemoveAsync(player);
        await _repo.SaveAsync();
    }

    public async Task<Player?> ObtenerJugadorPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    }
}