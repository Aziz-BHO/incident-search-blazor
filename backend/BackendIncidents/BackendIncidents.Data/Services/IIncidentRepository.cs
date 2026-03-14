using BackendIncidents.Data.Models;

namespace BackendIncidents.Data.Services
{
    public interface IIncidentRepository
    {
        public Task<List<Incident>> GetIncidentsAsync(
            string? title,
            string? description,
            string? severity,
            string? owner,
            int page,
            int pageSize);
    }
}
