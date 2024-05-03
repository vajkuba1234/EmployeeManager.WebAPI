using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public DateOnly JoinedDate { get; set; }
        public DateOnly? ExitedDate { get; set; }

        public int? SuperiorId { get; set; }
        public Employee Superior { get; set; } = null!;
        public List<Employee> Subordinates { get; } = [];

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public List<JobCategory> JobCategories { get; } = [];

        public ICollection<Salary> Salaries { get; } = [];
    }
}
