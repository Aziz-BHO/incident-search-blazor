using BackendIncidents.Data.Models;

namespace BackendIncidents.Data.Services
{
    public interface IIncidentRepository
    {
        public Task<List<Incident>> GetIncidentsAsync(
            string? title = null,
            string? description = null,
            string? severity = null,
            string? owner = null);
    }
}
