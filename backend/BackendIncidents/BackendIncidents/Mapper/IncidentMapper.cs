using BackendIncidents.Data.Models;
using BackendIncidents.DTOs;

namespace BackendIncidents.Mapper
{
    public static class IncidentMapper
    {
        public static IncidentDTO ToIncidentDTO(this Incident incident)
        {
            if (incident == null)
                return new IncidentDTO();

            return new IncidentDTO
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Severity = incident.Severity,
                OwnerId = incident.OwnerId,
                Owner = incident.Owner?.ToPersonDTO()
            };
        }

        public static List<IncidentDTO> ToIncidentListDTO(this List<Incident> incident)
        {
            if (incident == null)
                return new List<IncidentDTO>();
            return incident.Select(i => i.ToIncidentDTO()).ToList();
        }

    }
}
