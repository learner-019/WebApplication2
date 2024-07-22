using WebApplication2.Models.Domain;

namespace WebApplication2.Models.DTO
{
    public class AddStudentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string DepartmentName { get; set; }

    }
}
