using System.ComponentModel.DataAnnotations.Schema;

namespace BackendIncidents.Data.Models
{
    [Table("incident")]
    public class Incident
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("severity")]
        public string Severity { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Person Owner { get; set; }
    }
}
