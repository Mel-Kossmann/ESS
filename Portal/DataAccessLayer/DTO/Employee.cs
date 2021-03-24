namespace DataAccessLayer.DTO
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double? Salary { get; set; }
        public int CompanyId { get; set; }
    }
}
