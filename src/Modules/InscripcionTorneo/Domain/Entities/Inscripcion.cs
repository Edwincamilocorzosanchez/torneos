using torneos.src.Modules.Teams.Domain.Entities;

using torneos.src.Modules.TechnicalStaff.Domain.Entities;
using torneos.src.Modules.MedicalBody.Domain.Entities;

namespace torneos.src.Modules.InscripcionTorneo.Domain.Entities
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public int? CuerpoMedicoId { get; set; }
        public int? CuerpoTecnicoId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Team? Team { get; set; }
        public Tournament? Tournament { get; set; }
        public CuerpoMedico? CuerpoMedico { get; set; }
        public CuerpoTecnico? CuerpoTecnico { get; set; }
    }
}