using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.DBc
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double? Salary { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
