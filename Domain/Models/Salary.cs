using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateOnly From { get; set; }
        public DateOnly? To { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
