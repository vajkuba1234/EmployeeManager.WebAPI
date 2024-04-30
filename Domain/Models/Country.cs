using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
