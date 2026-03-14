using System.ComponentModel.DataAnnotations.Schema;

namespace BackendIncidents.Data.Models
{
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("email")]
        public string? Email { get; set; }
    }
}
