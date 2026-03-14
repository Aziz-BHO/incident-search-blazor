using BackendIncidents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendIncidents.Data.Services
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _context;

        public IncidentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Incident>> GetIncidentsAsync(string? title = null, string? description = null, string? severity = null, string? owner = null)
        {
            var query = _context.Incidents
                        .Include(i => i.Owner)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(i => EF.Functions.Like(i.Title, $"%{title}%"));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(i => EF.Functions.Like(i.Description, $"%{description}%"));

            if (!string.IsNullOrEmpty(severity))
                query = query.Where(i => EF.Functions.Like(i.Severity, $"%{severity}%"));

            if (!string.IsNullOrEmpty(owner))
            {
                query = query.Where(i =>
                    EF.Functions.Like(i.Owner.FirstName, $"%{owner}%") ||
                    EF.Functions.Like(i.Owner.LastName, $"%{owner}%") ||
                    EF.Functions.Like(i.Owner.Email!, $"%{owner}%")
                );
            }

            return await query
             .OrderByDescending(i => i.CreatedAt)
             .Take(100)
             .ToListAsync();    
        }
    }
}
