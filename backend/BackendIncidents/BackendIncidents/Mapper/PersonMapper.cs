using BackendIncidents.Data.Models;
using BackendIncidents.DTOs;

namespace BackendIncidents.Mapper
{
    public static class PersonMapper
    {
        public static PersonDTO ToPersonDTO(this Person person)
        {
            if (person == null)
                return new PersonDTO();

            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            };
        }

        public static List<PersonDTO> ToPersonListDTO(this List<Person> persons)
        {
            if (persons == null)
                return new List<PersonDTO>();

            return persons.Select(p => p.ToPersonDTO()).ToList();
        }
    }
}
