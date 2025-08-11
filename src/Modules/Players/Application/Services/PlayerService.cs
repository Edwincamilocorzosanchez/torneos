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

    public async Task RegistrarJugadorAsync(string nombre)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Nombre == nombre))
            throw new Exception("El jugador ya existe.");

        var player = new Player
        {
            Nombre = nombre,
        };

        _repo.Add(player);
        _repo.Update(player); 
    }
    public async Task ActualizarJugador(int id, string nuevoNombre)
    {
        var player = await _repo.GetByIdAsync(id);

        if (player == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");

        player.Nombre = nuevoNombre;

        _repo.Update(player);
        await _repo.SaveAsync();
    }

    public async Task EliminarJugador(int id)
    {
        var player = await _repo.GetByIdAsync(id);
        if (player == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");
        _repo.Remove(player);
        await _repo.SaveAsync();
    }

    public async Task<Player?> ObtenerJugadorPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    }
}