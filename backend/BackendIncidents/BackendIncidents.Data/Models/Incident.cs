namespace BackendIncidents.Data.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public DateTime CreatedAt { get; set; }

        public int OwnerId { get; set; }
        public Person? Owner { get; set; }
    }
}
