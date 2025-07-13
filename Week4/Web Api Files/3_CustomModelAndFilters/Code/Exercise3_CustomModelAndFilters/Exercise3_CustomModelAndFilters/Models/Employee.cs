using System;
using System.Collections.Generic;

namespace Exercise3_CustomModelAndFilters.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;             // initialize
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; } = new();         // initialize
        public List<Skill> Skills { get; set; } = new();            // initialize
        public DateTime DateOfBirth { get; set; }
    }
}
