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

        public async Task<List<Incident>> GetIncidentsAsync(string? title, string? description, string? severity, string? owner,int page, int pageSize)
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

            return await query.AsNoTracking()
             .OrderByDescending(i => i.CreatedAt)
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();    
        }
    }
}
