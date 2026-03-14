using BackendIncidents.Data.Services;
using BackendIncidents.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace BackendIncidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentsController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string? title,
            [FromQuery] string? description,
            [FromQuery] string? severity,
            [FromQuery] string? owner,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            var result = await _incidentRepository.GetIncidentsAsync(title, description, severity, owner,page, pageSize);
            return Ok(result.ToIncidentListDTO());
        }
    }
}
