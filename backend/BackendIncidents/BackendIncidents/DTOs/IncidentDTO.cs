namespace BackendIncidents.DTOs
{
    public class IncidentDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Severity { get; set; }
        public int OwnerId { get; set; }
        public PersonDTO? Owner { get; set; }
    }
}
