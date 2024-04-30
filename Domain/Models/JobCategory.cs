﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class JobCategory
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; } = [];
    }
}
