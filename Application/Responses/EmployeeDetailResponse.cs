﻿using Application.ViewModels;
using Domain.Enums;

namespace Application.Responses
{
    public class EmployeeDetailResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public DateOnly JoinedDate { get; set; }
        public DateOnly? ExitedDate { get; set; }

        public EmployeeViewModel? Superior { get; set; }
        public List<EmployeeViewModel>? Subordinates { get; set; }
        public CountryViewModel Country { get; set; } = null!;
        public List<JobCategoryViewModel> JobCategories { get; set; } = [];
    }
}
